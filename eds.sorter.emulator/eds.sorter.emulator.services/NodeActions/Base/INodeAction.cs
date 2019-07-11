using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Configurations.NodeActionConfig;
using eds.sorter.emulator.services.Model;

namespace eds.sorter.emulator.services.NodeActions.Base
{
    public interface INodeAction
    {
        bool Execute(Tracking tracking, NodeActionConfig nodeActionConfig);
    }
}
