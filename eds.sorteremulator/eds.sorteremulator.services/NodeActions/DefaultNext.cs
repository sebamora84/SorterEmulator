using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.NodeActions.Base;

namespace eds.sorteremulator.services.NodeActions
{
    public class DefaultNext: INodeAction
    {
        
        public bool Execute(Tracking tracking, ActionConfig nodeActionConfig)
        {
            return true;
        }
    }
}
