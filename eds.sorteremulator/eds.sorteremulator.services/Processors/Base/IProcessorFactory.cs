using eds.sorteremulator.services.Model.Messages;

namespace eds.sorteremulator.services.Processors.Base
{
    public interface IProcessorFactory
    {
        IMessageProcessor Create(MessageType messageType);
    }
}
