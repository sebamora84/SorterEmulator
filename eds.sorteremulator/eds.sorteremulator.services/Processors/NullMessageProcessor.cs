using System.Reflection;
using System.Threading.Tasks;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.Model.Messages;
using eds.sorteremulator.services.Processors.Base;



namespace eds.sorteremulator.services.Processors
{
    public class NullMessageProcessor : IMessageProcessor
    {
        public async Task<Message> ProcessAsync(Message parceldataMessage)
        {
            return await Task.FromResult<Message>(null);
        }
    }
}
