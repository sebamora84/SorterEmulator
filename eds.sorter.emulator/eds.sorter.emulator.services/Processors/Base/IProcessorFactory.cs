using eds.sorter.emulator.services.Model.Messages;

namespace eds.sorter.emulator.services.Processors.Base
{
    public interface IProcessorFactory
    {
        IMessageProcessor Create(MessageType messageType);
    }
}
