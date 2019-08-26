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
    public class MultiRemoteControl : INodeAction
    {
        private readonly ISorterService _sorterService;
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public MultiRemoteControl(ISorterService sorterService)
        {
            _sorterService = sorterService;
        }

        public bool Execute(Tracking tracking, NodeActionConfig nodeActionConfig)
        {
            var remoteControl = nodeActionConfig.GetData<MultiRemoteControlData>();
            _sorterService.AddMultiRemoteControl(remoteControl.Name, tracking.Pic, remoteControl.ActivateDelay, remoteControl.DeactivateDelay);
            return true;
        }
    }
}
