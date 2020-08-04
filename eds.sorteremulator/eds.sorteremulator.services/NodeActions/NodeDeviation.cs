using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Configurations.Actions.CustomData;
using eds.sorteremulator.services.Extensions;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.NodeActions.Base;
using eds.sorteremulator.services.Services.Interfaces;
using System;

namespace eds.sorteremulator.services.NodeActions
{
    public class NodeDeviation: INodeAction
    {
        private readonly IParcelService _parcelsService;
        private readonly IPhysicsService _physicsService;

        public NodeDeviation(IParcelService parcelsService, IPhysicsService physicsService)
        {
            _parcelsService = parcelsService;
            _physicsService = physicsService;
        }
        public bool Execute(Tracking tracking, ActionConfig nodeActionConfig)
        {
            if (!tracking.Present)
            {
                return false;
            }
            var nodeDeviationData = nodeActionConfig.GetActionInfo<NodeDeviationData>();
            var parcel = _parcelsService.GetParcel(tracking.Pic);
            var reachesDestination = parcel.OriginalDestination == nodeDeviationData.DestinationId;

            if (!reachesDestination)
            {
                return false;
            }
            parcel.ActualDestination = nodeDeviationData.DestinationId;
            tracking.Present = false;
            _physicsService.AddTracking(tracking.Pic, nodeDeviationData.NextNodeId, nodeActionConfig.Continues);
            return true;
        }
        
    }
}
