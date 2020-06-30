using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eds.sorteremulator.communiation
{
    public class CommunicationConfig
    {
        public string LocalIp { get; set; }
        public int LocalEndPoint { get; set; }
        public string RemoteIp { get; set; }
        public int RemoteEndPoint { get; set; }
        public string ServiceIp { get; set; }
        public int ServiceEndPoint { get; set; }
        public string StartChar { get; set; }
        public string EndChar { get; set; }
    }
}
