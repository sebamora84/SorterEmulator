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
    public class NoNext: INodeAction
    {
       public bool Execute(Tracking tracking, ActionConfig nodeActionConfig)
        {
            return true;
        }
    }
}
