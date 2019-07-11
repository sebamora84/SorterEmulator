using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.NodeActions.Base;
using eds.sorter.emulator.services.Services.Interfaces;
using eds.sorter.emulator.logger;
using eds.sorter.emulator.services.Configurations.NodeActionConfig;
using eds.sorter.emulator.services.Configurations.NodeActionConfig.CustomData;
using eds.sorter.emulator.services.Extensions;
using log4net;

namespace eds.sorter.emulator.services.Services
{
    public class PhysicsService : IPhysicsService
    {
        private readonly INodesService _nodesService;
        private readonly INodeActionFactory _nodeActionFactory;
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ConcurrentDictionary<Guid, Tracking> _trackings = new ConcurrentDictionary<Guid, Tracking>();

        private DateTime _lastRefresh = DateTime.Now;
        private Timer _sorterActivityTimer;

        private static PhysicsConfig Config
        {
            get => ConfigurationManager.GetConfig<PhysicsConfig>();
            set => ConfigurationManager.SaveConfig(value);
        }

        public PhysicsService( 
            INodesService nodesService,
            INodeActionFactory nodeActionFactory)
        {
            _nodesService = nodesService;
            _nodeActionFactory = nodeActionFactory;
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
                _log.Debug($"Time elapsed since last refresh is {timeElapsed}");
                return;
            }
            var timeLapseSpeed = Config.TimeLapseSpeed;
            if (timeLapseSpeed == 0)
                return;
            foreach (var trackingPosition in _trackings.Values.ToList())
            {
                UpdateTracking(trackingPosition, timeElapsed, timeLapseSpeed);
                //_log.Debug($"{tracking.Pic} in {tracking.CurrentNodeId.Name} at {tracking.CurrentPosition}mm");
            }
        }
        private void UpdateTracking(Tracking tracking, decimal timeElapsed, decimal timeLapseSpeed)
        {
            var currentNode = _nodesService.GetNode(tracking.CurrentNodeId);
            if (currentNode == null)
            {
                _log.Error($"Parcel pic{tracking.Pic} has no current node. It will be removed");
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
                _log.Error($"No next NodeActionConfig found for tracking pic {tracking.Pic} on node {currentNode.Name}. Review configuration");
                return;
            }

            if (nextAction.StopOnExecution)
            {
                currentNode.IsStopped = true;
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
                    if (! reachesDestination)
                    {
                        break;
                    }
                    INodeAction action = _nodeActionFactory.GetNodeAction(nextActionConfig.NodeEvent);
                    action.Execute(tracking, nextActionConfig);
                    tracking.Present = false;
                    var newTracking = AddTracking(tracking.Pic,nextActionConfig.GetData<NodeDeviationData>().NextNodeId,nextActionConfig.Continues);
                    SetDestination(newTracking.Id, tracking.DestinationNodeId);

                    break;
                case NodeEvent.DefaulNext:
                    action = _nodeActionFactory.GetNodeAction(nextActionConfig.NodeEvent);
                    action.Execute(tracking, nextActionConfig);
                    tracking.CurrentNodeId = nextActionConfig.GetData<NodeDeviationData>().NextNodeId;
                    tracking.CurrentPosition = nextActionConfig.Continues;
                    if (!tracking.Present)
                    {
                        RemoveTracking(tracking.Id);
                    }
                    break;
                default:
                    action = _nodeActionFactory.GetNodeAction(nextActionConfig.NodeEvent);
                    action.Execute(tracking, nextActionConfig);
                    tracking.CurrentPosition = nextActionConfig.Continues;
                    break;
            }
            
        }

        private NodeActionConfig GetNextAction(Node currentNode, decimal totalDistance, decimal parcelCurrentPosition)
        {
            var nextAction = _nodesService.GetActions(currentNode.Id)?.OrderBy(a=>a.Occurs).FirstOrDefault(a=>
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
                                 Data = new NodeDeviationData { NextNodeId = currentNode.Id }
                             };

            var defaultNext = currentNode.DefaultNextId == Guid.Empty
                ? new NodeActionConfig
                {
                    NodeId = currentNode.Id,
                    Occurs = currentNode.Size,
                    Continues = currentNode.Size,
                    NodeEvent = NodeEvent.NoNext,
                    StopOnExecution = false,
                    Data = new NodeDeviationData { NextNodeId = currentNode.Id }
                }
                : new NodeActionConfig
                {
                    NodeId = currentNode.Id,
                    Occurs = currentNode.DefaultNextOccurs,
                    Continues = currentNode.DefaultNextContinues,
                    NodeEvent = NodeEvent.DefaulNext,
                    StopOnExecution = false,
                    Data = new NodeDeviationData { NextNodeId = currentNode.DefaultNextId }
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
