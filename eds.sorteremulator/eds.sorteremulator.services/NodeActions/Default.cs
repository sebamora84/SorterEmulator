using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.NodeActions.Base;

namespace eds.sorteremulator.services.NodeActions
{
    public class Default: INodeAction, IManualAction
    {
        

        public bool Execute(Tracking tracking, ActionConfig nodeActionConfig)
        {
            return true;
        }

        public bool ExecuteManual(ActionConfig nodeActionConfig)
        {
            return true;
        }
    }
}
