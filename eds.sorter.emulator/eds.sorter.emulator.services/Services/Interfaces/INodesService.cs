using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Configurations.NodeActionConfig;
using eds.sorter.emulator.services.Model;

namespace eds.sorter.emulator.services.Services.Interfaces
{
    public interface INodesService:IService
    {
        List<Node> GetAllNodes();
        Node GetNode(Guid nodeId);
        Node GetNodeByHostId(int hostId);
        List<NodeActionConfig> GetActions(Guid nodeId);
        Node AddNode(Node newNode);
        Node DeleteNode(Guid id);
        Node UpdateNode(Guid guid, Node value);
    }
}
