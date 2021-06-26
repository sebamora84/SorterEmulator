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
        private  TCPSocket _server;
        private  TCPSocket _client;
        private  TCPSocket _service;
        private readonly ILogger<CommunicationManager> _logger;
        private readonly IConfigurationManager _configurationManager;
        private readonly ILogger<TCPSocket> _socketLogger;

        private CommunicationConfig Config
        {
            get => _configurationManager.GetConfig<CommunicationConfig>();
            set => _configurationManager.SaveConfig(value);
        }

        public event MessageReceivedEvent MessageReceived;
        public event MessageSentEvent MessageSent;
        public CommunicationManager(ILogger<CommunicationManager> logger,  IConfigurationManager configurationManager, ILogger<TCPSocket> socketLogger)
        {
            _logger = logger;
            _configurationManager = configurationManager;
            _socketLogger = socketLogger;
        }

        private void StartService()
        {
            if (_service != null)
            {
                _service.Stop();
                _service.TCPMessageReceived -= OnTcpMessageReceived;
                _service.TCPMessageSent -= OnTcpMessageSent;
                _service.SocketStateChanged -= OnSocketStateChanged;
            }


            _service = new TCPSocket(_socketLogger);
            _service.SocketName = "Service";
            _service.ConfigureAsServer(Config.ServiceEndPoint);
            _service.StartMarker = "\u0002";
            _service.EndMarker = "\u0003\u000d";
            _service.TCPMessageReceived += OnTcpMessageReceived;
            _service.TCPMessageSent += OnTcpMessageSent;
            _service.SocketStateChanged += OnSocketStateChanged;
            _service.Start();
        }
        private void StartServer()
        {
            if (_server != null)
            {
                _server.Stop();
                _server.TCPMessageReceived -= OnTcpMessageReceived;
                _server.TCPMessageSent -= OnTcpMessageSent;
                _server.SocketStateChanged -= OnSocketStateChanged;
            }

            _server = new TCPSocket(_socketLogger);
            _server.SocketName = "Server";
            _server.ConfigureAsServer(Config.LocalEndPoint);
            _server.StartMarker = "\u0002";
            _server.EndMarker = "\u0003\u000d";
            _server.TCPMessageReceived += OnTcpMessageReceived;
            _server.TCPMessageSent += OnTcpMessageSent;
            _server.SocketStateChanged += OnSocketStateChanged;
            _logger.LogInformation($"Configured channel Server on 0.0.0.0:{Config.LocalEndPoint}");
            _server.Start();
        }
        private void StartClient()
        {
            if (_client != null)
            {
                _client.Stop();
                _client.TCPMessageReceived -= OnTcpMessageReceived;
                _client.TCPMessageSent -= OnTcpMessageSent;
                _client.SocketStateChanged -= OnSocketStateChanged;
            }

            _client = new TCPSocket(_socketLogger);
            _client.SocketName = "Client";
            _client.ConfigureAsClient(Config.RemoteIp, Config.RemoteEndPoint);
            _client.StartMarker = "\u0002";
            _client.EndMarker = "\u0003\u000d";
            _client.TCPMessageReceived += OnTcpMessageReceived;
            _client.TCPMessageSent += OnTcpMessageSent;
            _client.SocketStateChanged += OnSocketStateChanged;
            _logger.LogInformation($"Configured channel Client on {Config.RemoteIp}:{Config.RemoteEndPoint}");
            _client.Start();
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
        public void Start()
        {
            StartClient();
            StartServer();
            StartService();
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
