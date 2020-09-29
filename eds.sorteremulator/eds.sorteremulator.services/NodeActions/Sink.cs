using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.NodeActions.Base;
using eds.sorteremulator.services.Services.Interfaces;

using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Configurations.Actions;


namespace eds.sorteremulator.services.NodeActions
{
    public class Sink: INodeAction
    {
        private readonly IPhysicsService _physicsService;
        private readonly IParcelService _parcelService;

        public Sink(IPhysicsService physicsService, IParcelService parcelService)
        {
            _physicsService = physicsService;
            _parcelService = parcelService;
        }

        public bool Execute(Tracking tracking, ActionConfig nodeActionConfig)
        {
            _physicsService.RemoveTracking(tracking.Id);            
            var trackings = _physicsService.GetAllTrackingByPic(tracking.Pic);
            if (trackings.Count == 0)
            {
                _parcelService.RemoveParcel(tracking.Pic);
            }
            return true;
        }
    }
}
