using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Configurations.Actions;

namespace eds.sorteremulator.services.Configurations
{
    public class SorterActionsConfig
    {
        public List<ActionConfig> ActionsConfig { get; set; }
    }
}
