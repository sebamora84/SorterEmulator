using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using eds.sorter.emulator.communiation.Sockets;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.logger;
using log4net;

namespace eds.sorter.emulator.communiation
{
    public class CommunicationManager:ICommunicationManager
    {
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly TCPSocket _server;
        private readonly TCPSocket _client;
        private readonly TCPSocket _service;

        public event MessageReceivedEvent MessageReceived;
        public event MessageSentEvent MessageSent;

        public CommunicationManager()
        {
            _server = new TCPSocket("Server");
            _server.ConfigureAsServer(Config.LocalEndPoint);
            _server.StartMarker = "\u0002";
            _server.EndMarker = "\u0003\u000d";
            _server.TCPMessageReceived += OnTcpMessageReceived;
            _server.TCPMessageSent += OnTcpMessageSent;
            _server.SocketStateChanged += OnSocketStateChanged;

            _client = new TCPSocket("Client");
            _client.ConfigureAsClient(Config.RemoteIp, Config.RemoteEndPoint);
            _client.StartMarker = "\u0002";
            _client.EndMarker = "\u0003\u000d";
            _client.TCPMessageReceived += OnTcpMessageReceived;
            _client.TCPMessageSent += OnTcpMessageSent;
            _client.SocketStateChanged += OnSocketStateChanged;

            _service = new TCPSocket("Service");
            _service.ConfigureAsServer(Config.ServiceIp, Config.ServiceEndPoint);
            _service.StartMarker = "\u0002";
            _service.EndMarker = "\u0003\u000d";
            _service.TCPMessageReceived += OnTcpMessageReceived;
            _service.TCPMessageSent += OnTcpMessageSent;
            _service.SocketStateChanged += OnSocketStateChanged;
        }

        private void OnSocketStateChanged(string socketName, SocketState value)
        {
            _log.Info($"Socket {socketName} state changed to {value}");
        }

        private void OnTcpMessageSent(string message, string socketName)
        {
            _log.Debug($"Message sent throug {socketName}: {message}");
            Task.Run(() =>
                {
                    try
                    {
                        MessageSent?.Invoke(message, socketName);
                    }
                    catch (Exception e)
                    {
                        _log.Error($"Error while processing message sent throug {socketName}: {message}", e);
                    }
                }
            );
        }

        private void OnTcpMessageReceived(string message, string socketName)
        {
            _log.Debug($"Message received throug {socketName}: {message}");
            Task.Run(() =>
                {
                    try
                    {
                        MessageReceived?.Invoke(message, socketName);
                    }
                    catch (Exception e)
                    {
                        _log.Error($"Error while processing message received throug {socketName}: {message}",e);
                    }
                }
            );

        }

        private static CommunicationConfig Config
        {
            get => ConfigurationManager.GetConfig<CommunicationConfig>();
            set => ConfigurationManager.SaveConfig(value);
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
