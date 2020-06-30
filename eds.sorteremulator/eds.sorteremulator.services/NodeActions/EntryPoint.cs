using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.NodeActions.Base;

using eds.sorteremulator.services.Configurations.NodeActionConfig;
using eds.sorteremulator.services.Configurations.NodeActionConfig.CustomData;
using eds.sorteremulator.services.Extensions;
using eds.sorteremulator.services.Services.Interfaces;


namespace eds.sorteremulator.services.NodeActions
{
    public class EntryPoint: INodeAction
    {
        private readonly IParcelService _parcelsService;
        

        public EntryPoint(IParcelService parcelsService)
        {
            _parcelsService = parcelsService;
        }

        public bool Execute(Tracking tracking, NodeActionConfig nodeActionConfig)
        {
            var parcel = _parcelsService.GetParcel(tracking.Pic);
            parcel.EntryNode = nodeActionConfig.GetData<EntryPointData>().EntryPoint;
            return false;
        }
    }
}
