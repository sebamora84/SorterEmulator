namespace eds.sorter.emulator.services.Model.Messages
{
    public enum MessageType
    {
        Input,
        Output,
        HostpicRequest,
        DestinationRequest,
        DestinationReply,
        SortReport,
        RecirculationReport,
        Event,
        KeepAliveRequest,
        KeepAliveReply,
        RemoteControl,
        Statistics,
    }
}
