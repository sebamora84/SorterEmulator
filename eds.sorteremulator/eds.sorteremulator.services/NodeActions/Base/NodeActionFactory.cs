﻿using Autofac;
using eds.sorteremulator.services.Configurations.NodeActionConfig;
using eds.sorteremulator.services.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace eds.sorteremulator.services.NodeActions.Base
{
    public class NodeActionFactory : INodeActionFactory
    {
        private readonly List<IService> _services;
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
                    return _scope.Resolve<Deviation>();
                case NodeEvent.EntryPoint:
                    return _scope.Resolve<EntryPoint>();
                case NodeEvent.Scale:
                    return _scope.Resolve<ScaleWeight>();
                case NodeEvent.CameraRead:
                    return _scope.Resolve<CameraRead>();
                case NodeEvent.DestinationRequest:
                    return _scope.Resolve<DestinationRequest>();
                case NodeEvent.SortReport:
                    return _scope.Resolve<SortReport>();
                case NodeEvent.MultiRemoteControl:
                    return _scope.Resolve<MultiRemoteControl>();
                case NodeEvent.DefaulNext:
                    return _scope.Resolve<DefaultNext>();
                case NodeEvent.NoNext:
                    return _scope.Resolve<NoNext>();
                default:
                    return _scope.Resolve<Default>();
            }
        }
    }
}