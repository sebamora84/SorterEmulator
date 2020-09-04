using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;

namespace eds.sorteremulator.services.Services
{
    public class SorterService :ISorterService
    {
        private readonly ILogger<SorterService> _logger;
        private readonly IConfigurationManager _configurationManager;
        private readonly IPhysicsService _physicsService;
        private readonly IParcelService _parcelService;
        private readonly INodesService _nodesService;
        private readonly IMessageService _messageService;

        private Timer _addTrayTimer;

        public SorterService(
            ILogger<SorterService> logger, 
            IConfigurationManager configurationManager, 
            IPhysicsService physicsService,
            IParcelService parcelService, 
            INodesService nodesService, 
            IMessageService messageService)
        {
            _logger = logger;
            _configurationManager = configurationManager;
            _physicsService = physicsService;
            _parcelService = parcelService;
            _nodesService = nodesService;
            _messageService = messageService;
        }

        private SorterServiceConfig Config
        {
            get => _configurationManager.GetConfig<SorterServiceConfig>();
            set => _configurationManager.SaveConfig(value);
        }

        public void Start()
        {
            
            StartTraysActivity();
        }

        

        public void Stop()
        {
            StopTraysActivity();
        }
        

        private void StartTraysActivity()
        {
            _addTrayTimer = new Timer(5000);
            _addTrayTimer.Elapsed += AddTrayTimerElapsed;
        }

        private void AddTrayTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var node = _nodesService.GetNode(Config.TraysNode);
            var parcel = _parcelService.AddNewParcel(node, "", "", "", "", "");
            _physicsService.AddTracking(parcel.Pic,node.Id, 0);
        }
        private void StopTraysActivity()
        {
            _addTrayTimer.Stop();
            _addTrayTimer.Elapsed -= AddTrayTimerElapsed;
            _addTrayTimer.Dispose();
        }
        public void StartAddTray()
        {
            _addTrayTimer.Start();
        }

        public void StopAddTray()
        {
           _addTrayTimer.Stop();
        }
        
        private class RemoteControlParcel
        {
            public int Pic { get; set; }
            public bool Active  { get; set; }
            public int ActivateDelay { get; set; }
            public int DeactivateDelay { get; set; }
            public DateTime Updated { get; set; }

        }

    }    
}
