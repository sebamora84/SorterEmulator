using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Model;

namespace eds.sorteremulator.services.Configurations
{
    public class SorterNodesConfig
    {
        public List<Node> NodesConfig { get; set; }
    }
}
