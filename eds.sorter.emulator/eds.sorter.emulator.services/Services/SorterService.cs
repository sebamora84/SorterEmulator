using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.Services.Interfaces;
using eds.sorter.emulator.logger;
using log4net;

namespace eds.sorter.emulator.services.Services
{
    public class SorterService :ISorterService
    {
        private readonly IPhysicsService _physicsService;
        private readonly IParcelService _parcelService;
        private readonly INodesService _nodesService;

        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Timer _addTrayTimer;

        public SorterService(IPhysicsService physicsService, IParcelService parcelService, INodesService nodesService)
        {
            _physicsService = physicsService;
            _parcelService = parcelService;
            _nodesService = nodesService;
        }

        private static SorterServiceConfig Config
        {
            get => ConfigurationManager.GetConfig<SorterServiceConfig>();
            set => ConfigurationManager.SaveConfig(value);
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
            var parcel = _parcelService.AddNewParcel(node);
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
    }
}
