using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Configurations.Nodes;
using eds.sorteremulator.services.Model;

namespace eds.sorteremulator.services.Services.Interfaces
{
    public interface INodesService:IService
    {
        List<NodeConfig> GetAllNodes();
        NodeConfig GetNode(Guid nodeId);
        NodeConfig AddNode(NodeConfig newNode);
        NodeConfig DeleteNode(Guid id);
        NodeConfig UpdateNode(Guid guid, NodeConfig value);

        List<ActionConfig> GetAllActions();
        List<ActionConfig> GetActionsByNodeId(Guid nodeId);
        ActionConfig GetActionById(Guid guid);
        ActionConfig AddAction(ActionConfig newAction);
        ActionConfig DeleteAction(Guid id);
        ActionConfig UpdateAction(Guid guid, ActionConfig action);
    }
}
