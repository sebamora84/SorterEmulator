using System.Reflection;
using System.Threading.Tasks;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.Model.Messages;
using eds.sorter.emulator.services.Processors.Base;
using eds.sorter.emulator.services.Services.Interfaces;
using eds.sorter.emulator.logger;
using log4net;

namespace eds.sorter.emulator.services.Processors
{
    public class KeepAliveRequestMessageProcessor : IMessageProcessor
    {
        private readonly IMessageService _messageService;
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public KeepAliveRequestMessageProcessor(IMessageService messageService)
        {

            _messageService = messageService;
        }

        public async Task<Message> ProcessAsync(Message message)
        {
            _messageService.SendMessage("W1              65", message.SocketName);
            return await Task.FromResult<Message>(null);
        }
    }
}
