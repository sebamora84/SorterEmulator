using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eds.sorteremulator.Dto
{
    public class NewParcelDto
    {
        public string Id { get; set; }
        public string NodeId { get; set; }
        public string BarcodeToRead { get; set; }
        public int WeightToWeigh { get; set; }
    }
}
