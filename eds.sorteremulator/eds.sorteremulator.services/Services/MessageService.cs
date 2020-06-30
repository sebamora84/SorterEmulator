using Autofac;
using eds.sorteremulator.communiation;
using eds.sorteremulator.configuration;
using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Model.Messages;
using eds.sorteremulator.services.Processors.Base;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Timers;

namespace eds.sorteremulator.services.Services
{
    public class MessageService:IMessageService
    {

        private Timer _sendKeepAliveTimer;
        private readonly ILifetimeScope _scope;
        private readonly ILogger<MessageService> _logger;
        private readonly IConfigurationManager _configurationManager;
        private readonly ICommunicationManager _communicationManager;
        
        private  MessageServiceConfig Config
        {
            get => _configurationManager.GetConfig<MessageServiceConfig>();
            set => _configurationManager.SaveConfig(value);
        }
        public MessageService(ILifetimeScope scope, ILogger<MessageService> logger,IConfigurationManager configurationManager, ICommunicationManager communicationManager)
        {
            _scope = scope;
            _logger = logger;
            _configurationManager = configurationManager;
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
                _logger.LogError("Exception while parsing message",e);
                return;
            }
            using(var scope = _scope.BeginLifetimeScope())
            {
                scope.Resolve<IProcessorFactory>().Create(message.MessageType).ProcessAsync(message);
            }
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
            SendMessage("W2\0\0\0\0\0\0\0\0\0\0\0\0\0\065", "Client");
        }
        private void StopKeepAliveActivity()
        {
            _sendKeepAliveTimer.Stop();
            _sendKeepAliveTimer.Elapsed -= KeepAliveTimerElapsed;
            _sendKeepAliveTimer.Dispose();
        }



    }
}
