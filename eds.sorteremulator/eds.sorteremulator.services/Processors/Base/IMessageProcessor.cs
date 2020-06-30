using System.Threading.Tasks;
using eds.sorteremulator.services.Model.Messages;

namespace eds.sorteremulator.services.Processors.Base
{
    public interface IMessageProcessor
    {
        Task<Message> ProcessAsync(Message message);
    }
}
