using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.services.Model;

namespace eds.sorter.emulator.services.Configurations
{
    public class SorterNodesConfig
    {
        public List<Node> NodesConfig { get; set; }
    }
}
