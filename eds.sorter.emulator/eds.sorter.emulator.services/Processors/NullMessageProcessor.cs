using System.Reflection;
using System.Threading.Tasks;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.Model.Messages;
using eds.sorter.emulator.services.Processors.Base;
using eds.sorter.emulator.logger;
using log4net;

namespace eds.sorter.emulator.services.Processors
{
    public class NullMessageProcessor : IMessageProcessor
    {
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<Message> ProcessAsync(Message parceldataMessage)
        {
            return await Task.FromResult<Message>(null);
        }
    }
}
