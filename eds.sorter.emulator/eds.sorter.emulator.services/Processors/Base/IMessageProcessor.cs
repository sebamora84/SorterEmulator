using System.Threading.Tasks;
using eds.sorter.emulator.services.Model.Messages;

namespace eds.sorter.emulator.services.Processors.Base
{
    public interface IMessageProcessor
    {
        Task<Message> ProcessAsync(Message message);
    }
}
