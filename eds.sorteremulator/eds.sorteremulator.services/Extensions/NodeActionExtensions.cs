using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Model;
using Newtonsoft.Json;

namespace eds.sorteremulator.services.Extensions
{
    public static class NodeActionExtensions
    {
        public static T GetActionInfo<T>(this ActionConfig nodeActionConfig)
        {
            return JsonConvert.DeserializeObject<T>(nodeActionConfig.ActionInfo);
        }
        public static void SetActionInfo<T>(this ActionConfig nodeActionConfig, T actionInfo)
        {
            nodeActionConfig.ActionInfo = JsonConvert.SerializeObject(actionInfo);
        }
    }
}
