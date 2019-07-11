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
    public class SortReport : INodeAction
    {
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IMessageService _messageService;
        private readonly IParcelService _parcelsService;
        private readonly IPhysicsService _physicsService;

        public SortReport(IMessageService messageService, IParcelService parcelsService, IPhysicsService physicsService)
        {
            _messageService = messageService;
            _parcelsService = parcelsService;
            _physicsService = physicsService;
        }

        public bool Execute(Tracking tracking, NodeActionConfig nodeActionConfig)
        {
            var parcel = _parcelsService.GetParcel(tracking.Pic);
            var sortReportData = nodeActionConfig.GetData<SortReportData>();
            var message = new Message
            {
                MessageId = sortReportData.MessageId,
                MessageType = MessageType.SortReport,
                Pic = tracking.Pic,
                Hostpic = parcel.HostPic,
                Hostdata = parcel.HostData,
                ParcelLength = parcel.Lenght,
                ParcelOriginalDestination = parcel.DestinationId,
                OriginalDestinationState = GetDestinationState(tracking, parcel),
                ParcelActualDestination = parcel.DestinationId,
                DestinationTranslateState = GetDestinationState(tracking, parcel),
                ScannerData1 = parcel.Barcode,
                ScannerData2 = "1   0",
                ScannerData3 = parcel.Weight,
                ScannerData4 = "1   0",
                UpdateState = "00000000",
                ParcelEntrancePoint = parcel.EntryNode,
                ParcelEntranceState = "1",
                ParcelExitPoint = sortReportData.ExitPoint,
                ParcelExitState = "1",
                Recirculations = 0,
            };

            Task.Run(() => _messageService.SendMessage(message));

            return true;
        }

        private char GetDestinationState(Tracking tracking, Parcel parcel)
        {
            if (parcel.DestinationId == 900)
            {
                return '2';
            }
            if (!tracking.Present)
            {
                tracking = _physicsService.GetTrackingByPic(tracking.Pic);
            }
            if (tracking.CurrentNodeId != tracking.DestinationNodeId)
            {
                return '3';
            }
            return '1';
        }
    }
}
