using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eds.sorteremulator.services.Model
{
    public class Node
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int HostDestinationId { get; set; }
        public decimal Speed { get; set; }
        public decimal Size { get; set; }
        public decimal PositionX { get; set; }
        public decimal PositionY { get; set; }
        public decimal Rotation { get; set; }
        public decimal Curvature { get; set; }
        public Guid DefaultNextId { get; set; }
        public decimal DefaultNextOccurs { get; set; }
        public decimal DefaultNextContinues { get; set; }
        public bool IsStopped { get; set; }
    }
}
