using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Model.Messages;

namespace eds.sorteremulator.services.Services.Interfaces
{
    public interface IMessageService:IService
    {
        void SendMessage(string message);
        void SendMessage(Message message);
        void SendMessage(string message, string socket);
        void SendMessage(Message message, string socket);
    }
}
