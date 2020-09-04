using System;
using System.Collections.Generic;
using System.Text;

namespace eds.sorteremulator.services.Configurations.Actions
{
    public enum NodeEvent
    {
        NodeDeviation,
        ScannerDataReader,
        EntryPoint,
        DestinationRequest,
        SortReport,
        DefaulNext,
        NoAction,
        NoNext,
        RemoteControlOut,
        RecirculationCounter
    }
}
