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
        public string ScannerData1 { get; set; }
        public string ScannerData2 { get; set; }
        public string ScannerData3 { get; set; }
        public string ScannerData4 { get; set; }
        public string ScannerData5 { get; set; }
        public string ScannerDataToRead1 { get; set; }
        public string ScannerDataToRead2 { get; set; }
        public string ScannerDataToRead3 { get; set; }
        public string ScannerDataToRead4 { get; set; }
        public string ScannerDataToRead5 { get; set; }
        public int Lenght { get; set; } = 500;
        public int OriginalDestination { get; set; }
        public int ActualDestination { get; set; }
        public int Recirculations { get; set; }
    }
}
