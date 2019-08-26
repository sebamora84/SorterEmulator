using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.logger;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Configurations.NodeActionConfig;
using eds.sorter.emulator.services.Configurations.NodeActionConfig.CustomData;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.NodeActions;
using eds.sorter.emulator.services.Services.Interfaces;
using log4net;

namespace eds.sorter.emulator.services.Services
{
    public class NodesService : INodesService
    {
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private ConcurrentDictionary<Guid, Node> _nodes;
        private ConcurrentDictionary<Guid, List<NodeActionConfig>> _actionsByNode;

        private static SorterNodesConfig NodesConfig
        {
            get => ConfigurationManager.GetConfig<SorterNodesConfig>();
            set => ConfigurationManager.SaveConfig(value);
        }
        private static SorterActionsConfig ActionConfig
        {
            get => ConfigurationManager.GetConfig<SorterActionsConfig>(new[] { typeof(SortReportData), typeof(DestinationRequestData), typeof(NodeDeviationData), typeof(EntryPointData), typeof(MultiRemoteControlData) });
            set => ConfigurationManager.SaveConfig(value, new[] { typeof(SortReportData), typeof(DestinationRequestData), typeof(NodeDeviationData), typeof(EntryPointData), typeof(MultiRemoteControlData) });
        }


        public void Start()
        {
            //var sorterActionsConfig = ActionConfig;
            //foreach (var nodeConfig in NodesConfig.NodesConfig.Where(n=>n.Name.StartsWith("SOT")))
            //{
            //    var chuteNumber = nodeConfig.Name.Substring(3, 2);
            //    sorterActionsConfig.ActionsConfig.Add(
            //        new NodeActionConfig
            //        {
            //            Id =  Guid.NewGuid(),
            //            Name = $"{nodeConfig.Name}_MultiRemoteControl",
            //            NodeId = nodeConfig.Id,
            //            NodeEvent = NodeEvent.MultiRemoteControl,
            //            Occurs = nodeConfig.Size -10,
            //            Continues = nodeConfig.Size - 10,
            //            Data = new MultiRemoteControlData { Name = $"MULTI{chuteNumber}", ActivateDelay = 0, DeactivateDelay = 2},
            //        }
                    
            //        );
            //}
            //ActionConfig = sorterActionsConfig;

            LoadNodes();        

        }
        public void Stop()
        {
            
        }

        private void LoadNodes()
        {
            _nodes = new ConcurrentDictionary<Guid, Node>(NodesConfig.NodesConfig.ToDictionary(n => n.Id, n => n));
            _actionsByNode =new ConcurrentDictionary<Guid, List<NodeActionConfig>>(ActionConfig.ActionsConfig.GroupBy(a=>a.NodeId).ToDictionary(a => a.Key, a => a.ToList()));
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

        public List<NodeActionConfig> GetActions(Guid nodeId)
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
            return newNode;
        }
        public Node DeleteNode(Guid id)
        {
            _nodes.TryRemove(id, out var removedNode);
            var config = NodesConfig;
            config.NodesConfig.Remove(removedNode);
            NodesConfig = config;
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
            return node;
        }

        public List<Node> GetAllNodes()
        {
            return NodesConfig.NodesConfig.ToList();
        }
    }
}
