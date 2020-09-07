using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Configurations.Actions.CustomData;
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

        public bool Execute(Tracking tracking, ActionConfig nodeActionConfig)
        {
            var parcel = _parcelsService.GetParcel(tracking.Pic);
            var destinationRequestData = nodeActionConfig.GetActionInfo<DestinationRequestData>();
            var message = new Message
            {
                MessageId = destinationRequestData.MessageId,
                MessageType = MessageType.SortReport,
                Pic = tracking.Pic,
                AlibiId = tracking.Pic.ToString("00000000000000000000000"),
                Hostpic = parcel.HostPic,
                Hostdata = parcel.HostData,
                ParcelLength = parcel.Lenght,
                ParcelOriginalDestination = parcel.OriginalDestination,
                OriginalDestinationState = GetDestinationState(parcel),
                ParcelActualDestination = parcel.ActualDestination,
                DestinationTranslateState = GetDestinationState(parcel),
                ScannerData1 = parcel.ScannerData1,
                ScannerData2 = parcel.ScannerData2,
                ScannerData3 = parcel.ScannerData3,
                ScannerData4 = parcel.ScannerData4,
                ScannerData5 = parcel.ScannerData5,
                UpdateState = "00000000",
                ParcelEntrancePoint = parcel.EntryNode,
                ParcelEntranceState = "1",
                ParcelExitPoint = destinationRequestData.ExitPoint,
                ParcelExitState = "0",
                Recirculations = parcel.Recirculations,
            };

            Task.Run(()=>_messageService.SendMessage(message));
            return true;
        }
        private char GetDestinationState(Parcel parcel)
        {
            if (parcel.OriginalDestination == 900)
            {
                return '2';
            }
            if (parcel.OriginalDestination != parcel.ActualDestination)
            {
                return '3';
            }
            return '1';
        }
    }
}
