﻿using eds.sorteremulator.services.Configurations.NodeActionConfig.CustomData;
using System;
using System.Collections.Generic;

namespace eds.sorteremulator.services.Configurations.NodeActionConfig
{
    public class NodeActionConfig
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

    public enum NodeEvent
    {
        NodeDeviation,
        Scale,
        CameraRead,
        EntryPoint,
        DestinationRequest,
        SortReport,
        DefaulNext,
        MaxMoved,
        NoNext,
        MultiRemoteControl
    }
}
