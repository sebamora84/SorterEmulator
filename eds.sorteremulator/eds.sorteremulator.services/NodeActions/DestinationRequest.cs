using eds.sorteremulator.services.Configurations.NodeActionConfig;
using eds.sorteremulator.services.Configurations.NodeActionConfig.CustomData;
using eds.sorteremulator.services.Extensions;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.Model.Messages;
using eds.sorteremulator.services.NodeActions.Base;
using eds.sorteremulator.services.Services.Interfaces;
using System.Threading.Tasks;

namespace eds.sorteremulator.services.NodeActions
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
