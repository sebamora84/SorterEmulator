using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eds.sorteremulator.services.Configurations
{
    public class PhysicsConfig
    {
        public decimal TimeLapseSpeed { get; set; } = 1.0M;
        public int RefreshRate { get; set; } = 60;
        public decimal SorterProportion { get; set; } = 0.0095M;
        public decimal TranslateX { get; set; } = 0.0M;
        public decimal TranslateY { get; set; } = 0.0M;

        public string ScannerData1 { get; set; } = "1   0";
        public string ScannerData2 { get; set; } = "1   0";
        public string ScannerData3 { get; set; } = "1   0";
        public string ScannerData4 { get; set; } = "1   0";
        public string ScannerData5 { get; set; } = "1   0";
    }
}
