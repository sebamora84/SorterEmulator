using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.communiation;
using eds.sorter.emulator.logger;
using eds.sorter.emulator.services.NodeActions;
using eds.sorter.emulator.services.NodeActions.Base;
using eds.sorter.emulator.services.Processors.Base;
using eds.sorter.emulator.services.Services;
using eds.sorter.emulator.services.Services.Interfaces;
using eds.sorter.emulator.web;
using log4net;

namespace eds.sorter.emulator.core
{
    public class EmulatorCore: IEmulatorCore
    {
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        private readonly List<IService> _services = new List<IService>();
      

        public async Task Start()
        {

            _log.Info("Starting EmulatorCore");


            var nodesService = new NodesService();
            var parcelService = new ParcelService();
            var physicsService = new PhysicsService(nodesService, new NodeActionFactory(_services));
            var messageService = new MessageService(new CommunicationManager(), new ProcessorFactory(_services));
            var sorterService = new SorterService(physicsService, parcelService, nodesService, messageService);
            var webService = new WebService(_services);
            _services.Add(nodesService);
            _services.Add(parcelService);
            _services.Add(sorterService);
            _services.Add(messageService);
            _services.Add(physicsService);
            _services.Add(webService);

            foreach (var emulationService in _services)
            {
                _log.Info($"Starting {emulationService.GetType().Name}");
                emulationService.Start();
                _log.Info($"Started {emulationService.GetType().Name}");
            }

            


            _log.Info("Started EmulatorCore");
            await Task.FromResult(0);
        }

        public async Task Stop()
        {
            _log.Info("Stopping EmulatorCore");
            foreach (var emulationService in _services)
            {
                _log.Info($"Stopping {emulationService.GetType().Name}");
                emulationService.Stop();
                _log.Info($"Stopped {emulationService.GetType().Name}");
            }
            _log.Info("Stopped EmulatorCore");
            await Task.FromResult(0);
        }
    }
}
