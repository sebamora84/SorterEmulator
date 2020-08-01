using eds.sorteremulator.services.Configurations.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace eds.sorteremulator.services.NodeActions.Base
{
    public interface IManualAction
    {
        bool ExecuteManual(ActionConfig nodeActionConfig);
    }
}
