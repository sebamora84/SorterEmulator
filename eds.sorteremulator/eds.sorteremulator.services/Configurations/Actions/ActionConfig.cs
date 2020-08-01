using eds.sorteremulator.services.Configurations.Actions.CustomData;
using System;
using System.Collections.Generic;

namespace eds.sorteremulator.services.Configurations.Actions
{
    public class ActionConfig
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid NodeId { get; set; }
        public NodeEvent NodeEvent { get; set; }
        public decimal Occurs { get; set; }
        public decimal Continues { get; set; }
        public bool Disabled { get; set; }
        public bool StopOnExecution { get; set; }
        public string ActionInfo { get; set; }

    }
}
