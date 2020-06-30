using eds.sorteremulator.communiation.Sockets;
using eds.sorteremulator.configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace eds.sorteremulator.communiation
{
    public class CommunicationManager:ICommunicationManager
    {
        private readonly TCPSocket _server;
        private readonly TCPSocket _client;
        private readonly TCPSocket _service;
        private readonly ILogger<CommunicationManager> _logger;
        private readonly IConfigurationManager _configurationManager;

        public event MessageReceivedEvent MessageReceived;
        public event MessageSentEvent MessageSent;

        public CommunicationManager(ILogger<CommunicationManager> logger,  IConfigurationManager configurationManager, TCPSocket server, TCPSocket client, TCPSocket service)
        {
            _logger = logger;
            _configurationManager = configurationManager;

            _server = server;
            _server.SocketName = "Server";
            _server.ConfigureAsServer(Config.LocalEndPoint);
            _server.StartMarker = "\u0002";
            _server.EndMarker = "\u0003\u000d";
            _server.TCPMessageReceived += OnTcpMessageReceived;
            _server.TCPMessageSent += OnTcpMessageSent;
            _server.SocketStateChanged += OnSocketStateChanged;

            _client = client;
            _client.SocketName = "Client";
            _client.ConfigureAsClient(Config.RemoteIp, Config.RemoteEndPoint);
            _client.StartMarker = "\u0002";
            _client.EndMarker = "\u0003\u000d";
            _client.TCPMessageReceived += OnTcpMessageReceived;
            _client.TCPMessageSent += OnTcpMessageSent;
            _client.SocketStateChanged += OnSocketStateChanged;

            _service = service;
            _service.SocketName = "Service";
            _service.ConfigureAsServer(Config.ServiceIp, Config.ServiceEndPoint);
            _service.StartMarker = "\u0002";
            _service.EndMarker = "\u0003\u000d";
            _service.TCPMessageReceived += OnTcpMessageReceived;
            _service.TCPMessageSent += OnTcpMessageSent;
            _service.SocketStateChanged += OnSocketStateChanged;
        }

        private void OnSocketStateChanged(string socketName, SocketState value)
        {
            _logger.LogInformation($"Socket {socketName} state changed to {value}");
        }

        private void OnTcpMessageSent(string message, string socketName)
        {
            _logger.LogDebug($"Message sent throug {socketName}: {message}");
            Task.Run(() =>
                {
                    try
                    {
                        MessageSent?.Invoke(message, socketName);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError($"Error while processing message sent throug {socketName}: {message}", e);
                    }
                }
            );
        }

        private void OnTcpMessageReceived(string message, string socketName)
        {
            _logger.LogDebug($"Message received throug {socketName}: {message}");
            Task.Run(() =>
                {
                    try
                    {
                        MessageReceived?.Invoke(message, socketName);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError($"Error while processing message received throug {socketName}: {message}",e);
                    }
                }
            );

        }

        private CommunicationConfig Config
        {
            get => _configurationManager.GetConfig<CommunicationConfig>();
            set => _configurationManager.SaveConfig(value);
        }
        public void Start()
        {
            _client.Start();
            _server.Start();
            _service.Start();
        }


        public void Stop()
        {
            _server.Stop();
            _client.Start();
            _service.Start();
        }

        public bool SendMessage(string message)
        {
            return _client.Send(message);
        }
        public bool SendMessage(string message, string socket)
        {
            if(socket == _client.SocketName)
                return _client.Send(message);
            if (socket == _server.SocketName)
                return _server.Send(message);
            if (socket == _service.SocketName)
                return _service.Send(message);
            return false;
        }
    }
}
