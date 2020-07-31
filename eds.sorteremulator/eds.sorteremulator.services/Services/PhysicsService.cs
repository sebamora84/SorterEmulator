﻿using Autofac;
using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Configurations.NodeActionConfig;
using eds.sorteremulator.services.Configurations.NodeActionConfig.CustomData;
using eds.sorteremulator.services.Extensions;
using eds.sorteremulator.services.Hubs;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.NodeActions.Base;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Timers;

namespace eds.sorteremulator.services.Services
{
    public class PhysicsService : IPhysicsService
    {
        private readonly ILifetimeScope _scope;
        private readonly IConfigurationManager _configurationManager;
        private readonly IHubContext<NodesHub> _nodesHubContext;
        private readonly IHubContext<TrackingHub> _trackingHubContext;
        private readonly ILogger<PhysicsService> _logger;
        private readonly INodesService _nodesService;
        private readonly ConcurrentDictionary<Guid, Tracking> _trackings = new ConcurrentDictionary<Guid, Tracking>();

        private DateTime _lastRefresh = DateTime.Now;
        private Timer _sorterActivityTimer;

        private PhysicsConfig Config
        {
            get => _configurationManager.GetConfig<PhysicsConfig>();
            set => _configurationManager.SaveConfig(value);
        }

        public PhysicsService(
            ILifetimeScope scope,
            IConfigurationManager configurationManager,
            IHubContext<NodesHub>nodesHubContext,
            IHubContext<TrackingHub> trackingHubContext,
            ILogger<PhysicsService> logger,
            INodesService nodesService)
        {
            _scope = scope;
            _configurationManager = configurationManager;
            _nodesHubContext = nodesHubContext;
            _trackingHubContext = trackingHubContext;
            _logger = logger;
            _nodesService = nodesService;
        }

        public void Start()
        {
            StopPhysicsActivity();
            StartPhysicsActivity();
        }

        public void Stop()
        {
            StopPhysicsActivity();
        }

        private void StartPhysicsActivity()
        {
            if (_sorterActivityTimer != null)
            {
                return;
            }
            var refreshRate = Config.RefreshRate;
            if (refreshRate == 0)
            {
                throw new Exception($"Refresh Rate cannot be {refreshRate}");
            }
            _sorterActivityTimer = new Timer(refreshRate);
            _sorterActivityTimer.Elapsed += SorterActivityTimerElapsed;
            _sorterActivityTimer.Start();
        }

        private void StopPhysicsActivity()
        {
            if (_sorterActivityTimer == null)
            {
                return;
            }
            _sorterActivityTimer.Stop();
            _sorterActivityTimer.Elapsed -= SorterActivityTimerElapsed;
            _sorterActivityTimer.Dispose();
            _sorterActivityTimer = null;
        }


        private void SorterActivityTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _sorterActivityTimer.Enabled = false;
            RefreshParcels();
            _sorterActivityTimer.Enabled = true;
        }
        private void RefreshParcels()
        {
            var timeElapsed = Convert.ToDecimal((DateTime.Now - _lastRefresh).TotalMilliseconds);
            _lastRefresh = DateTime.Now;
            if (timeElapsed <= 0)
            {
                _logger.LogDebug($"Time elapsed since last refresh is {timeElapsed}");
                return;
            }
            var timeLapseSpeed = Config.TimeLapseSpeed;
            if (timeLapseSpeed == 0)
                return;
            foreach (var trackingPosition in _trackings.Values)
            {
                UpdateTracking(trackingPosition, timeElapsed, timeLapseSpeed);
                _trackingHubContext.Clients.All.SendAsync("UpdateTracking", trackingPosition);
            }
        }
        private void UpdateTracking(Tracking tracking, decimal timeElapsed, decimal timeLapseSpeed)
        {
            var currentNode = _nodesService.GetNode(tracking.CurrentNodeId);
            if (currentNode == null)
            {
                _logger.LogError($"Parcel pic{tracking.Pic} has no current node. It will be removed");
                _trackings.TryRemove(tracking.Id, out tracking);
                return;
            }
            if (currentNode.IsStopped)
            {
                //TODO:Add fallback
                return;
            }
            var currentNodeSpeed = currentNode.Speed;
            var parcelCurrentPosition = tracking.CurrentPosition;
            var totalDistance = parcelCurrentPosition + GetDistance(timeElapsed, currentNode.Speed, timeLapseSpeed);

            var nextAction = GetNextAction(currentNode, totalDistance, parcelCurrentPosition);

            if (nextAction == null)
            {
                _logger.LogError($"No next NodeActionConfig found for tracking pic {tracking.Pic} on node {currentNode.Name}. Review configuration");
                return;
            }

            if (nextAction.StopOnExecution)
            {
                currentNode.IsStopped = true;
                _nodesHubContext.Clients.All.SendAsync("UpdateNode", currentNode);

            }

            ExecuteAction(tracking, nextAction);
            
            var distanceRemaining = nextAction.NodeEvent==NodeEvent.NoNext ? 0: totalDistance - nextAction.Occurs;
            var timeRemaining = GetTimeLapse(distanceRemaining, currentNodeSpeed, timeLapseSpeed);
            if (timeRemaining > 0)
            {
                UpdateTracking(tracking, timeRemaining, timeLapseSpeed);
            }
        }

        private void ExecuteAction(Tracking tracking, NodeActionConfig nextActionConfig)
        {
            tracking.CurrentPosition = nextActionConfig.Occurs;
            switch (nextActionConfig.NodeEvent)
            {
                case NodeEvent.NodeDeviation:
                    {
                        if (!tracking.Present)
                        {
                            break;
                        }

                        var destinationNode = _nodesService.GetNode(tracking.DestinationNodeId);
                        if (destinationNode == null)
                        {
                            break;
                        }

                        var reachesDestination = ReachesDestination(nextActionConfig, destinationNode, new Dictionary<Guid, Node>());
                        if (!reachesDestination)
                        {
                            break;
                        }

                        ExecuteActionConfig(nextActionConfig, tracking);

                        tracking.Present = false;
                        var newTracking = AddTracking(tracking.Pic, nextActionConfig.GetData<NodeDeviationData>().NextNodeId, nextActionConfig.Continues);
                        SetDestination(newTracking.Id, tracking.DestinationNodeId);
                    }
                    break;
                case NodeEvent.DefaulNext:

                    ExecuteActionConfig(nextActionConfig, tracking);
                    tracking.CurrentNodeId = nextActionConfig.GetData<NodeDeviationData>().NextNodeId;
                    tracking.CurrentPosition = nextActionConfig.Continues;
                    if (!tracking.Present)
                    {
                        RemoveTracking(tracking.Id);
                    }
                    break;
                default:

                    ExecuteActionConfig(nextActionConfig, tracking);
                    tracking.CurrentPosition = nextActionConfig.Continues;
                    break;
            }
            
        }

        private void ExecuteActionConfig(NodeActionConfig nextActionConfig, Tracking tracking)
        {
            using (var scope = _scope.BeginLifetimeScope())
            {
                INodeAction action = _scope.Resolve<INodeActionFactory>().GetNodeAction(nextActionConfig.NodeEvent);
                action.Execute(tracking, nextActionConfig);
            }
        }

        private NodeActionConfig GetNextAction(Node currentNode, decimal totalDistance, decimal parcelCurrentPosition)
        {
            var nextAction = _nodesService.GetActions(currentNode.Id)?.OrderBy(a => a.Occurs).FirstOrDefault(a =>
                                   !a.Disabled &&
                                   a.Occurs > parcelCurrentPosition &&
                                   a.Occurs <= totalDistance
                             ) ?? new NodeActionConfig
                             {
                                 NodeId = currentNode.Id,
                                 Occurs = totalDistance,
                                 Continues = totalDistance,
                                 NodeEvent = NodeEvent.MaxMoved,
                                 StopOnExecution = false,
                                 ActionInfo = JsonConvert.SerializeObject(new NodeDeviationData { NextNodeId = currentNode.Id })
                             };

            var defaultNext = currentNode.DefaultNextId == Guid.Empty
                ? new NodeActionConfig
                {
                    NodeId = currentNode.Id,
                    Occurs = currentNode.Size,
                    Continues = currentNode.Size,
                    NodeEvent = NodeEvent.NoNext,
                    StopOnExecution = false,
                    ActionInfo = JsonConvert.SerializeObject(new NodeDeviationData { NextNodeId = currentNode.Id })
                }
                : new NodeActionConfig
                {
                    NodeId = currentNode.Id,
                    Occurs = currentNode.DefaultNextOccurs,
                    Continues = currentNode.DefaultNextContinues,
                    NodeEvent = NodeEvent.DefaulNext,
                    StopOnExecution = false,
                    ActionInfo = JsonConvert.SerializeObject(new NodeDeviationData { NextNodeId = currentNode.DefaultNextId })
                };

            return nextAction.Occurs >= defaultNext.Occurs ? defaultNext : nextAction;
        }

        private decimal GetDistance(decimal timeElapsed, decimal speed, decimal speedFactor)
        {
            return (speedFactor * speed / 1000m) * timeElapsed;
        }

        private decimal GetTimeLapse(decimal distance, decimal speed, decimal speedFactor)
        {
            return distance / (speedFactor * speed / 1000m);
        }

        private bool ReachesDestination(NodeActionConfig nodeActionConfig, Node originalDestination, Dictionary<Guid, Node> dictionary)
        {
            var node = _nodesService.GetNode(nodeActionConfig.GetData<NodeDeviationData>().NextNodeId);
            dictionary.Add(node.Id, node);
            if (node == originalDestination)
            {
                return true;
            }

            foreach (var nodeActionChild in _nodesService.GetActions(node.Id)?.Where(a=>a.NodeEvent==NodeEvent.NodeDeviation))
            {
                if (dictionary.ContainsKey(nodeActionChild.GetData<NodeDeviationData>().NextNodeId))
                {
                    continue;
                }
                var childNode = _nodesService.GetNode(nodeActionChild.GetData<NodeDeviationData>().NextNodeId);
                if(childNode == null)
                {
                    continue;
                }

                if (childNode == originalDestination)
                {
                    dictionary.Add(childNode.Id, childNode);
                    return true;
                }
                if (ReachesDestination(nodeActionChild, originalDestination, dictionary))
                {
                    return true;
                }
            }
            dictionary.Remove(node.Id);
            return false;
        }

        public Tracking AddTracking(int pic, Guid nodeId, decimal position)
        {
            var tracking = new Tracking
            {
                Id = Guid.NewGuid(),
                Pic = pic,
                CurrentNodeId = nodeId,
                CurrentPosition = position,
                Present = true
            };
            _trackings.TryAdd(tracking.Id, tracking);
            _trackingHubContext.Clients.All.SendAsync("UpdateTracking", tracking);
            return tracking;
        }

        public void SetDestination(Guid id, Guid nodeId)
        {
            _trackings.TryGetValue(id, out var tracking);
            if (tracking != null) tracking.DestinationNodeId = nodeId;
        }

        public Tracking GetTracking(Guid id)
        {
            _trackings.TryGetValue(id, out var tracking);
            return tracking;
        }

        public Tracking GetTrackingByPic(int pic)
        {
           return _trackings.Values.FirstOrDefault(tp => tp.Pic == pic && tp.Present);
        }

        public List<Tracking> GetAllTracking()
        {
            return _trackings.Values.ToList();
        }

        public void RemoveTracking(Guid id)
        {
            _trackings.TryRemove(id, out var tracking);
            if (tracking == null)
                return;
            _trackingHubContext.Clients.All.SendAsync("DeleteTracking", tracking);
        }
        public void RemoveTrackingByPic(int pic)
        {
            var trackings = _trackings.Values.Where(tp => tp.Pic == pic);
            foreach (var tracking in trackings)
            {
                RemoveTracking(tracking.Id);
            }
        }
    }
}
