using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using eds.sorter.emulator.logger;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Configurations.NodeActionConfig;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.Services.Interfaces;
using log4net;

namespace eds.sorter.emulator.services.NodeActions.Base
{
    public class NodeActionFactory : INodeActionFactory
    {
        private readonly List<IService> _services;
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public NodeActionFactory(List<IService> services)
        {
            _services = services;
        }

        public INodeAction GetNodeAction(NodeEvent nodeEvent)
        {
            switch (nodeEvent)
            {
                
                case NodeEvent.NodeDeviation:
                    return new Deviation();
                case NodeEvent.EntryPoint:
                    return new EntryPoint(_services.First(s => s is IParcelService) as IParcelService);
                case NodeEvent.Scale:
                    return new ScaleWeight(
                        _services.First(s => s is IParcelService) as IParcelService);
                case NodeEvent.CameraRead:
                    return new CameraRead(
                        _services.First(s => s is IParcelService) as IParcelService);
                case NodeEvent.DestinationRequest:
                    return new DestinationRequest(
                        _services.First(s => s is IMessageService) as IMessageService, 
                        _services.First(s => s is INodesService) as INodesService,
                        _services.First(s => s is IParcelService) as IParcelService);
                case NodeEvent.SortReport:
                    return new SortReport(
                        _services.First(s => s is IMessageService) as IMessageService,
                        _services.First(s => s is IParcelService) as IParcelService,
                        _services.First(s => s is IPhysicsService) as IPhysicsService);
                case NodeEvent.DefaulNext:
                    return new DefaultNext();
                case NodeEvent.NoNext:
                    return new NoNext();
                default:
                    return new Default();
            }
        }
    }
}
