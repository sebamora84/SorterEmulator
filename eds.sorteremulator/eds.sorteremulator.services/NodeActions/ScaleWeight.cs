using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.NodeActions.Base;

using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Configurations.NodeActionConfig;
using eds.sorteremulator.services.Services.Interfaces;


namespace eds.sorteremulator.services.NodeActions
{
    public class ScaleWeight: INodeAction
    {
        private readonly IParcelService _parcelsService;
        

        public ScaleWeight(IParcelService parcelsService)
        {
            _parcelsService = parcelsService;
        }

        public bool Execute(Tracking tracking, NodeActionConfig nodeActionConfig)
        {
            var parcel = _parcelsService.GetParcel(tracking.Pic);
            parcel.Weight = $"6  18#  1;    {(parcel.WeightToWeigh/1000m).ToString("0.0##", CultureInfo.InvariantCulture)} kg;#";
            return true;
        }
    }
}
