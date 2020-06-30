using eds.sorteremulator.services.Model.Messages;
using eds.sorteremulator.services.Processors.Base;
using eds.sorteremulator.services.Services.Interfaces;
using System.Reflection;
using System.Threading.Tasks;

namespace eds.sorteremulator.services.Processors
{
    public class DestinationReplyMessageProcessor : IMessageProcessor
    {
        private readonly IParcelService _parcelService;
        private readonly INodesService _nodesService;
        private readonly IPhysicsService _physicsService;

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
