using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eds.sorteremulator.services.Model
{
    public class Tracking
    {
        public Guid Id { get; set; }
        public int Pic { get; set; }
        public bool Present { get; set; }
        public Guid CurrentNodeId { get; set; }
        public Guid DestinationNodeId { get; set; }
        public decimal CurrentPosition { get; set; }
    }
}
