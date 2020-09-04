using Autofac;
using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace eds.sorteremulator.services.NodeActions.Base
{
    public class NodeActionFactory : INodeActionFactory
    {
        private readonly ILifetimeScope _scope;

        public NodeActionFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public INodeAction GetNodeAction(NodeEvent nodeEvent)
        {
            switch (nodeEvent)
            {

                case NodeEvent.NodeDeviation:
                    return _scope.Resolve<NodeDeviation>();
                case NodeEvent.EntryPoint:
                    return _scope.Resolve<EntryPoint>();
                case NodeEvent.ScannerDataReader:
                    return _scope.Resolve<ScannerDataReader>();
                case NodeEvent.DestinationRequest:
                    return _scope.Resolve<DestinationRequest>();
                case NodeEvent.SortReport:
                    return _scope.Resolve<SortReport>();
                case NodeEvent.RemoteControlOut:
                    return _scope.Resolve<RemoteControlOut>();
                case NodeEvent.DefaulNext:
                    return _scope.Resolve<DefaultNext>();
                case NodeEvent.NoNext:
                    return _scope.Resolve<NoNext>();
                case NodeEvent.RecirculationCounter:
                    return _scope.Resolve<RecirculationCounter>();
                default:
                    return _scope.Resolve<Default>();
            }
        }
        public IManualAction GetManualAction(NodeEvent nodeEvent)
        {
            switch (nodeEvent)
            {
                case NodeEvent.RemoteControlOut:
                    return _scope.Resolve<RemoteControlOut>();
                default:
                    return _scope.Resolve<Default>();
            }
        }
    }
}
