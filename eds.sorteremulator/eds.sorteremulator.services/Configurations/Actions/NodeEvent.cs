using System;
using System.Collections.Generic;
using System.Text;

namespace eds.sorteremulator.services.Configurations.Actions
{
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
        RemoteControlOut
    }
}
