using eds.sorteremulator.services.Configurations.NodeActionConfig;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.NodeActions.Base;

namespace eds.sorteremulator.services.NodeActions
{
    public class Default: INodeAction
    {
        

        public bool Execute(Tracking tracking, NodeActionConfig nodeActionConfig)
        {
            return true;
        }
    }
}
