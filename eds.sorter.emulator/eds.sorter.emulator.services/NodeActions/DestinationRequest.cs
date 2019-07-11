using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.Model.Messages;
using eds.sorter.emulator.services.NodeActions.Base;
using eds.sorter.emulator.services.Services.Interfaces;
using eds.sorter.emulator.logger;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Configurations.NodeActionConfig;
using eds.sorter.emulator.services.Configurations.NodeActionConfig.CustomData;
using eds.sorter.emulator.services.Extensions;
using log4net;

namespace eds.sorter.emulator.services.NodeActions
{
    public class DestinationRequest : INodeAction
    {
        private readonly IMessageService _messageService;
        private readonly INodesService _nodesService;
        private readonly IParcelService _parcelsService;
       
        public DestinationRequest(IMessageService messageService, INodesService nodesService, IParcelService parcelsService)
        {
            _messageService = messageService;
            _nodesService = nodesService;
            _parcelsService = parcelsService;
        }

        public bool Execute(Tracking tracking, NodeActionConfig nodeActionConfig)
        {
            var parcel = _parcelsService.GetParcel(tracking.Pic);
            var destinationRequestData = nodeActionConfig.GetData<DestinationRequestData>();
            var message = new Message
            {
                MessageId = destinationRequestData.MessageId,
                MessageType = MessageType.DestinationRequest,
                Pic = tracking.Pic,
                Hostpic = parcel.HostPic,
                Hostdata = parcel.HostData,
                ParcelLength = parcel.Lenght,
                ParcelOriginalDestination = _nodesService.GetNode(tracking.DestinationNodeId)?.HostDestinationId??0,
                OriginalDestinationState = '1',
                ParcelActualDestination = _nodesService.GetNode(tracking.DestinationNodeId)?.HostDestinationId ?? 0,
                DestinationTranslateState = '1',
                ScannerData1 = parcel.Barcode,
                ScannerData2 = "1   0",
                ScannerData3 = parcel.Weight,
                ScannerData4 = "1   0",
                UpdateState = "00000000",
                ParcelEntrancePoint = parcel.EntryNode,
                ParcelEntranceState = "1",
                ParcelExitPoint = destinationRequestData.ExitPoint,
                ParcelExitState = "1",
                Recirculations = 0,
            };

            Task.Run(()=>_messageService.SendMessage(message));
            return false;
        }
    }
}
