using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using eds.sorter.emulator.services.Model.Messages;
using eds.sorter.emulator.services.Services.Interfaces;
using eds.sorter.emulator.logger;
using log4net;

namespace eds.sorter.emulator.services.Processors.Base
{
    public class ProcessorFactory : IProcessorFactory
    {
        private readonly List<IService> _services;
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ProcessorFactory(List<IService> services)
        {
            _services = services;
        }

        public IMessageProcessor Create(MessageType messageType)
        {
            IMessageProcessor processor = null;
            switch (messageType)
            {
                case MessageType.DestinationReply:
                    processor = new DestinationReplyMessageProcessor(
                        _services.First(s => s is IParcelService) as IParcelService,
                        _services.First(s => s is INodesService) as INodesService,
                        _services.First(s => s is IPhysicsService) as IPhysicsService);
                    break;
                case MessageType.RemoteControl:
                    processor = new RemoteControlMessageProcessor(
                        _services.First(s => s is IPhysicsService) as IPhysicsService,
                        _services.First(s => s is IParcelService) as IParcelService, 
                        _services.First(s => s is ISorterService) as ISorterService,
                        _services.First(s => s is INodesService) as INodesService);
                    break;
                case MessageType.KeepAliveRequest:
                    processor = new KeepAliveRequestMessageProcessor(
                        _services.First(s => s is IMessageService) as IMessageService);
                    break;
                case MessageType.KeepAliveReply:
                    processor = new KeepAliveReplyMessageProcessor();
                    break;
                default:
                    _log.Warn($"No processor registered with name {messageType}. Using NullProcessor instead");
                    processor = new NullMessageProcessor();
                    break;
            }

            return processor;
        }
    }
}
