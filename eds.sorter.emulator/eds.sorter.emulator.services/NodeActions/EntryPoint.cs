using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.NodeActions.Base;
using eds.sorter.emulator.logger;
using eds.sorter.emulator.services.Configurations.NodeActionConfig;
using eds.sorter.emulator.services.Configurations.NodeActionConfig.CustomData;
using eds.sorter.emulator.services.Extensions;
using eds.sorter.emulator.services.Services.Interfaces;
using log4net;

namespace eds.sorter.emulator.services.NodeActions
{
    public class EntryPoint: INodeAction
    {
        private readonly IParcelService _parcelsService;
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
