using eds.sorteremulator.services.Model.Messages;
using eds.sorteremulator.services.Processors.Base;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;

namespace eds.sorteremulator.services.Processors
{
    public class KeepAliveReplyMessageProcessor : IMessageProcessor
    {
        public async Task<Message> ProcessAsync(Message message)
        {
            return await Task.FromResult<Message>(null);
        }
    }
}
