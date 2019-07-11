using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.services.Model.Messages;

namespace eds.sorter.emulator.services.Services.Interfaces
{
    public interface IMessageService:IService
    {
        void SendMessage(string message);
        void SendMessage(Message message);
        void SendMessage(string message, string socket);
        void SendMessage(Message message, string socket);
    }
}
