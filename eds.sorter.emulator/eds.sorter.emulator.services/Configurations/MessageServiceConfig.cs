using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.services.Model.Messages;

namespace eds.sorter.emulator.services.Configurations
{
    public class MessageServiceConfig
    {
        public List<MessageConfig> MessagesConfig { get; set; }
    }
    public class MessageConfig
    {
        public MessageType MessageType { get; set; }
        public string MessageProcessor { get; set; }
        public int MessageId { get; set; }
        public int ReplyMessage { get; set; }
        public bool OutputMessage { get; set; }
        public List<MessageField> EnabledFields { get; set; }
        public List<string> EnabledFieldsNames { get; set; }


    }
}
