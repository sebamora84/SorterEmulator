using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eds.sorter.emulator.services.Model
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
        public int DestinationId { get; set; }
        public int DestinationResult { get; set; }
        public int DestinationReason { get; set; }
        public int Lenght { get; set; } = 500;
    }
}
