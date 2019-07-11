using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using eds.sorter.emulator.communiation;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Model.Messages;
using eds.sorter.emulator.services.Processors.Base;
using eds.sorter.emulator.services.Services.Interfaces;
using eds.sorter.emulator.logger;
using log4net;

namespace eds.sorter.emulator.services.Services
{
    public class MessageService:IMessageService
    {

        private Timer _sendKeepAliveTimer;
        private readonly IProcessorFactory _processorFactory;
        private readonly ICommunicationManager _communicationManager;
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        private static MessageServiceConfig Config
        {
            get => ConfigurationManager.GetConfig<MessageServiceConfig>();
            set => ConfigurationManager.SaveConfig(value);
        }
        public MessageService(ICommunicationManager communicationManager, IProcessorFactory processorFactory)
        {
            _processorFactory = processorFactory;
            _communicationManager = communicationManager;
        }
        public void Start()
        {
            _communicationManager.MessageReceived += CommunicationManager_MessageReceived;
            _communicationManager.Start();
            StartKeepAliveActivity();
        }

        public void SendMessage(string message, string socket)
        {
            _communicationManager.SendMessage(message, socket);
        }

        public void SendMessage(string message)
        {
            _communicationManager.SendMessage(message);
        }

        public void SendMessage(Message message)
        {
            _communicationManager.SendMessage(message.GetMessageString(Config.MessagesConfig));
        }

        public void SendMessage(Message message, string socket)
        {
            _communicationManager.SendMessage(message.GetMessageString(Config.MessagesConfig), socket);
        }


        private void CommunicationManager_MessageReceived(string messageString, string socket)
        {
            Message message;
            try
            {
                Message.ParseMessage(messageString, Config.MessagesConfig, out message);
                message.SocketName = socket;
            }
            catch (Exception e)
            {
                _log.Error("Exception while parsing message",e);
                return;
            }
            _processorFactory.Create(message.MessageType).ProcessAsync(message);
        }

        public void Stop()
        {
            _communicationManager.Stop();
            _communicationManager.MessageReceived -= CommunicationManager_MessageReceived;
            StopKeepAliveActivity();
        }

        private void StartKeepAliveActivity()
        {
            _sendKeepAliveTimer = new Timer(15000);
            _sendKeepAliveTimer.Elapsed += KeepAliveTimerElapsed;
            _sendKeepAliveTimer.Start();
        }
        private void KeepAliveTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SendMessage("W2              65", "Client");
        }
        private void StopKeepAliveActivity()
        {
            _sendKeepAliveTimer.Stop();
            _sendKeepAliveTimer.Elapsed -= KeepAliveTimerElapsed;
            _sendKeepAliveTimer.Dispose();
        }



    }
}
