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
using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Configurations.Actions.CustomData;
using eds.sorteremulator.services.Extensions;


namespace eds.sorteremulator.services.NodeActions
{
    public class RemoteControlOut : INodeAction, IManualAction
    {
        private readonly INodesService _nodesService;
        private readonly IMessageService _messageService;

        public RemoteControlOut(INodesService nodesService, IMessageService messageService)
        {
            _nodesService = nodesService;
            _messageService = messageService;
        }

        public bool Execute(Tracking tracking, ActionConfig nodeActionConfig)
        {
            return true;
        }

        public bool ExecuteManual(ActionConfig actionConfig)
        {
            var remoteControl = actionConfig.GetActionInfo<RemoteControlOutData>();
            remoteControl.IsActive = !remoteControl.IsActive;
            actionConfig.SetActionInfo(remoteControl);
            _nodesService.UpdateAction(actionConfig.Id, actionConfig);


            var name = remoteControl.Name;
            var active = remoteControl.IsActive ? "Y" : "N";
            var message = $"CC|       {name}|attrval|        active|{active}|3F";
            Task.Run(() => _messageService.SendMessage(message));
            return true;
        }
    }
}
