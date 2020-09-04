using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.Model.Messages;
using eds.sorteremulator.services.NodeActions.Base;
using eds.sorteremulator.services.Services.Interfaces;

using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Extensions;
using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Configurations.Actions.CustomData;

namespace eds.sorteremulator.services.NodeActions
{
    public class RecirculationCounter: INodeAction
    {
        private readonly IParcelService _parcelsService;

        public RecirculationCounter(IParcelService parcelsService)
        {
            _parcelsService = parcelsService;
        }

        public bool Execute(Tracking tracking, ActionConfig nodeActionConfig)
        {
            var parcel = _parcelsService.GetParcel(tracking.Pic);
            parcel.Recirculations++;
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
