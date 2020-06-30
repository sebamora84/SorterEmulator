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
using eds.sorteremulator.services.Configurations.NodeActionConfig;
using eds.sorteremulator.services.Configurations.NodeActionConfig.CustomData;
using eds.sorteremulator.services.Extensions;


namespace eds.sorteremulator.services.NodeActions
{
    public class MultiRemoteControl : INodeAction
    {
        private readonly ISorterService _sorterService;
        

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
