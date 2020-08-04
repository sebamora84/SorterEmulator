using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eds.sorteremulator.services.Model
{
    public class Parcel
    {
        public int Pic { get; set; }
        public int HostPic { get; set; }
        public string HostData { get; set; }
        public string EntryNode { get; set; }
        public string Barcode { get; set; }
        public string BarcodeToRead { get; set; }
        public string Weight { get; set; }
        public int WeightToWeigh { get; set; }
        public int Lenght { get; set; } = 500;
        public int OriginalDestination { get; set; }
        public int ActualDestination { get; set; }
    }
}
