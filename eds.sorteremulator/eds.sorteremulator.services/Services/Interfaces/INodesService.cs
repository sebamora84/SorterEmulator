using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Configurations.NodeActionConfig;
using eds.sorteremulator.services.Model;

namespace eds.sorteremulator.services.Services.Interfaces
{
    public interface INodesService:IService
    {
        List<Node> GetAllNodes();
        Node GetNode(Guid nodeId);
        Node GetNodeByHostId(int hostId);
        Node AddNode(Node newNode);
        Node DeleteNode(Guid id);
        Node UpdateNode(Guid guid, Node value);

        List<NodeActionConfig> GetAllActions();
        List<NodeActionConfig> GetActionsByNodeId(Guid nodeId);
        NodeActionConfig GetActionById(Guid guid);
        NodeActionConfig AddAction(NodeActionConfig newAction);
        NodeActionConfig DeleteAction(Guid id);
        NodeActionConfig UpdateAction(Guid guid, NodeActionConfig action);
    }
}
