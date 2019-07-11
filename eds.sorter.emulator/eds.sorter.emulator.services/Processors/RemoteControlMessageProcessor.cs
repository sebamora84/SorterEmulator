using System;
using System.Reflection;
using System.Threading.Tasks;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.Model.Messages;
using eds.sorter.emulator.services.Processors.Base;
using eds.sorter.emulator.services.Services.Interfaces;
using eds.sorter.emulator.logger;
using log4net;

namespace eds.sorter.emulator.services.Processors
{
    public class RemoteControlMessageProcessor : IMessageProcessor
    {
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IPhysicsService _physicsService;
        private readonly IParcelService _parcelService;
        private readonly ISorterService _sorterService;
        private readonly INodesService _nodesService;

        private static SorterServiceConfig Config
        {
            get => ConfigurationManager.GetConfig<SorterServiceConfig>();
            set => ConfigurationManager.SaveConfig(value);
        }

        public RemoteControlMessageProcessor(IPhysicsService physicsService, IParcelService parcelService, ISorterService sorterService, INodesService nodesService)
        {
            _physicsService = physicsService;
            _parcelService = parcelService;
            _sorterService = sorterService;
            _nodesService = nodesService;
        }
        public async Task<Message> ProcessAsync(Message message)
        {
            //CC | PARCEL | NODE | 59

            var messageString = message.StringMessage.Split('|');
            var control = messageString[1].Trim();
            if (control == Config.TrayRequestControl)
            {
                var active = messageString[4].Trim().Equals("Y");
                if (active)
                {
                    _sorterService.StartAddTray();
                }
                else
                {
                    _sorterService.StopAddTray();
                }
                return await Task.FromResult<Message>(null); ;
            }


            switch (control)
            {
                case "PARCEL":
                    var nodeId = messageString[2].Trim();
                    var node = _nodesService.GetNode(new Guid(nodeId));
                    var parcel = _parcelService.AddNewParcel(node);
                    _physicsService.AddTracking(parcel.Pic,node.Id,0);
                    break;
                case "REMOVE":
                    var parcelId = int.Parse(messageString[2].Trim());
                    _parcelService.RemoveParcel(parcelId);
                    break;
                case "STOPPED":
                    nodeId = messageString[2].Trim();
                    node = _nodesService.GetNode(new Guid(nodeId));
                    node.IsStopped = messageString[3].Trim()=="Y";
                    break;
            }
            return await Task.FromResult<Message>(null);
        }
    }
}
