using eds.sorteremulator.services.Model.Messages;
using eds.sorteremulator.services.Processors.Base;
using eds.sorteremulator.services.Services.Interfaces;
using System.Threading.Tasks;

namespace eds.sorteremulator.services.Processors
{
    public class KeepAliveRequestMessageProcessor : IMessageProcessor
    {
        private readonly IMessageService _messageService;
        public KeepAliveRequestMessageProcessor(IMessageService messageService)
        {

            _messageService = messageService;
        }

        public async Task<Message> ProcessAsync(Message message)
        {
            //_messageService.SendMessage("W1              65", message.SocketName);
            _messageService.SendMessage("W1              65", message.SocketName);
            return await Task.FromResult<Message>(null);
        }
    }
}
