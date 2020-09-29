using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Model.Messages;
using eds.sorteremulator.services.Processors.Base;
using eds.sorteremulator.services.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace eds.sorteremulator.services.Processors
{
    public class RemoteControlMessageProcessor : IMessageProcessor
    {
        private readonly IConfigurationManager _configurationManager;
        private readonly IPhysicsService _physicsService;
        private readonly IParcelService _parcelService;
        private readonly ISorterService _sorterService;
        private readonly INodesService _nodesService;

        private SorterServiceConfig Config
        {
            get => _configurationManager.GetConfig<SorterServiceConfig>();
            set => _configurationManager.SaveConfig(value);
        }

        public RemoteControlMessageProcessor(IConfigurationManager configurationManager, IPhysicsService physicsService, IParcelService parcelService, ISorterService sorterService, INodesService nodesService)
        {
            _configurationManager = configurationManager;
            _physicsService = physicsService;
            _parcelService = parcelService;
            _sorterService = sorterService;
            _nodesService = nodesService;
        }
        public async Task<Message> ProcessAsync(Message message)
        {
            return await Task.FromResult<Message>(null);
        }
    }
}
