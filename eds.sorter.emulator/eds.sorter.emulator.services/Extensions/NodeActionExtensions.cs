using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Configurations.NodeActionConfig;
using eds.sorter.emulator.services.Model;

namespace eds.sorter.emulator.services.Extensions
{
    public static class NodeActionExtensions
    {
        public static T GetData<T>(this NodeActionConfig nodeActionConfig)
        {
            return (T) nodeActionConfig.Data;
        }
    }
}
