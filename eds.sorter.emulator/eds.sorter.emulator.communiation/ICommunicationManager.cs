using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eds.sorter.emulator.communiation
{
    public interface ICommunicationManager
    {
        event MessageReceivedEvent MessageReceived;
        event MessageSentEvent MessageSent;
        void Start();
        void Stop();

        bool SendMessage(string message);
        bool SendMessage(string message, string socket);
    }
    public delegate void MessageReceivedEvent(string message, string socket);
    public delegate void MessageSentEvent(string message, string socket);
}
