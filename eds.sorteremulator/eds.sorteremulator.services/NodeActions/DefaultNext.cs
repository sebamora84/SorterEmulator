using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Configurations.Actions.CustomData;
using eds.sorteremulator.services.Extensions;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.NodeActions.Base;
using eds.sorteremulator.services.Services.Interfaces;

namespace eds.sorteremulator.services.NodeActions
{
    public class DefaultNext: INodeAction
    {
        private readonly IPhysicsService _physicsService;

        public DefaultNext(IPhysicsService physicsService)
        {
            _physicsService = physicsService;
        }
    
        public bool Execute(Tracking tracking, ActionConfig nodeActionConfig)
        {
            tracking.CurrentNodeId = nodeActionConfig.GetActionInfo<DefaultNextData>().NextNodeId;
            if (!tracking.Present)
            {
                _physicsService.RemoveTracking(tracking.Id);
            }
            return true;
        }
    }
}
