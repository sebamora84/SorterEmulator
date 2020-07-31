using eds.sorteremulator.communiation;
using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Configurations.NodeActionConfig;
using eds.sorteremulator.services.Configurations.NodeActionConfig.CustomData;
using eds.sorteremulator.services.Hubs;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace eds.sorteremulator.services.Services
{
    public class NodesService : INodesService
    {
       
        private ConcurrentDictionary<Guid, Node> _nodes;
        private ConcurrentDictionary<Guid, List<NodeActionConfig>> _actionsByNode;
        private readonly ILogger<NodesService> _logger;
        private readonly IConfigurationManager _configurationManager;
        private readonly IHubContext<NodesHub> _nodesHubContext;

        private SorterNodesConfig NodesConfig
        {
            get => _configurationManager.GetConfig<SorterNodesConfig>();
            set => _configurationManager.SaveConfig(value);
        }
        private SorterActionsConfig ActionConfig
        {
            get => _configurationManager.GetConfig<SorterActionsConfig>();
            set => _configurationManager.SaveConfig(value);
        }
        public NodesService(ILogger<NodesService> logger, IConfigurationManager configurationManager,
            IHubContext<NodesHub> nodesHubContext)
        {
            _logger = logger;
            _configurationManager = configurationManager;
            _nodesHubContext = nodesHubContext;
        }

        public void Start()
        {
           
            LoadNodes();
            LoadActions();
        }
        public void Stop()
        {
            
        }

        private void LoadNodes()
        {
            _nodes = new ConcurrentDictionary<Guid, Node>(NodesConfig.NodesConfig.ToDictionary(n => n.Id, n => n));
           
        }

        private void LoadActions()
        {
            _actionsByNode = new ConcurrentDictionary<Guid, List<NodeActionConfig>>(ActionConfig.ActionsConfig.GroupBy(a => a.NodeId).ToDictionary(a => a.Key, a => a.ToList()));
        }

        public Node GetNode(Guid nodeId)
        {
            _nodes.TryGetValue(nodeId, out var node);
            return node;
        }

        public Node GetNodeByHostId(int hostId)
        {
            return _nodes.FirstOrDefault(n => n.Value.HostDestinationId == hostId).Value;
        }

        public List<NodeActionConfig> GetActionsByNodeId(Guid nodeId)
        {
            _actionsByNode.TryGetValue(nodeId, out var nodeActions);
            return nodeActions;
        }

        public Node AddNode(Node newNode)
        {
            newNode.Id = Guid.NewGuid();
            _nodes.TryAdd(newNode.Id, newNode);
            var config = NodesConfig;
            config.NodesConfig.Add(newNode);
            NodesConfig = config;

            _nodesHubContext.Clients.All.SendAsync("UpdateNode", newNode);
            return newNode;
        }
        public Node DeleteNode(Guid id)
        {
            _nodes.TryRemove(id, out var removedNode);
            var config = NodesConfig;
            config.NodesConfig.Remove(removedNode);
            NodesConfig = config;
            _nodesHubContext.Clients.All.SendAsync("DeleteNode", removedNode);
            return removedNode;
        }

        public Node UpdateNode(Guid guid, Node node)
        {
            var removedNode = DeleteNode(guid);
            node.Id = removedNode.Id;
            _nodes.TryAdd(node.Id, node);
            var config = NodesConfig;
            config.NodesConfig.Add(node);
            NodesConfig = config;

            _nodesHubContext.Clients.All.SendAsync("UpdateNode", node);
            return node;
        }

        public List<Node> GetAllNodes()
        {
            return NodesConfig.NodesConfig.ToList();
        }

        public List<NodeActionConfig> GetAllActions()
        {
            return ActionConfig.ActionsConfig.ToList();
        }

        public NodeActionConfig GetActionById(Guid guid)
        {
            
            return ActionConfig.ActionsConfig.FirstOrDefault(a=>a.Id.Equals(guid)) ;
        }

        public NodeActionConfig AddAction(NodeActionConfig newAction)
        {
            newAction.Id = Guid.NewGuid();                       
            var config = ActionConfig;
            config.ActionsConfig.Add(newAction);
            ActionConfig = config;

            LoadActions();
            return newAction;
        }
        public NodeActionConfig DeleteAction(Guid id)
        {

            var config = ActionConfig;
            var removedAction = config.ActionsConfig.First(a => a.Id == id);
            config.ActionsConfig.Remove(removedAction);
            ActionConfig = config;
            LoadActions();

            return removedAction;
        }

        public NodeActionConfig UpdateAction(Guid guid, NodeActionConfig action)
        {
            var removedAction = DeleteNode(guid);
            action.Id = removedAction.Id;
            var config = ActionConfig;
            config.ActionsConfig.Add(action);
            ActionConfig = config;
            LoadActions();
            return action;
        }
    }
}
