using Autofac;
using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Model.Messages;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace eds.sorteremulator.services.Processors.Base
{
    public class ProcessorFactory : IProcessorFactory
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<ProcessorFactory> _logger;


        public ProcessorFactory(ILifetimeScope scope, ILogger<ProcessorFactory> logger)
        {
            _scope = scope;
            _logger = logger;
        }

        public IMessageProcessor Create(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.DestinationReply:
                    return _scope.Resolve<DestinationReplyMessageProcessor>();

                case MessageType.RemoteControl:
                    return _scope.Resolve<RemoteControlMessageProcessor>();

                case MessageType.KeepAliveRequest:
                    return _scope.Resolve<KeepAliveRequestMessageProcessor>();

                case MessageType.KeepAliveReply:
                    return _scope.Resolve<KeepAliveReplyMessageProcessor>();
                default:
                    _logger.LogWarning($"No processor registered with name {messageType}. Using NullProcessor instead");
                    return _scope.Resolve<NullMessageProcessor>();

            }
        }
    }
}
