using System.Reflection;
using System.Threading.Tasks;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.Model.Messages;
using eds.sorter.emulator.services.Processors.Base;
using eds.sorter.emulator.services.Services.Interfaces;
using eds.sorter.emulator.logger;
using log4net;

namespace eds.sorter.emulator.services.Processors
{
    public class DestinationReplyMessageProcessor : IMessageProcessor
    {
        private readonly IParcelService _parcelService;
        private readonly INodesService _nodesService;
        private readonly IPhysicsService _physicsService;
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public DestinationReplyMessageProcessor(IParcelService parcelService, INodesService nodesService, IPhysicsService physicsService)
        {
            _parcelService = parcelService;
            _nodesService = nodesService;
            _physicsService = physicsService;
        } 
        public async Task<Message> ProcessAsync(Message message)
        {
            var parcel = _parcelService.GetParcel(message.Pic);
            parcel.HostPic = message.Hostpic;
            parcel.HostData = message.Hostdata;
            parcel.DestinationId = message.ParcelOriginalDestination;
            
            if (message.ParcelOriginalDestination == 998 || message.ParcelOriginalDestination == 999)
            {            
                return await Task.FromResult<Message>(null);
            }
            var tracking = _physicsService.GetTrackingByPic(parcel.Pic);
            if (message.ParcelOriginalDestination == 900)
            {
                _nodesService.GetNode(tracking.CurrentNodeId).IsStopped = false;
                return await Task.FromResult<Message>(null);
            }
            var destinationNode = _nodesService.GetNodeByHostId(message.ParcelOriginalDestination);
            _physicsService.SetDestination(tracking.Id, destinationNode.Id);
            return await Task.FromResult<Message>(null);
        }
    }
}
