using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using eds.sorter.emulator.communiation.Sockets;
using eds.sorter.emulator.logger;
using log4net;

namespace eds.sorter.emulator.communiation.Sockets
{
    public class TCPSocket
    {
        #region Constants
        //Don´t allow more connections in server socket. We are in sigle server/client scenario
        private const int MAX_CONNECTIONS = 1;
        private const int EV_STOP = 0;
        private const int EV_STOPPED = 1;
        //private const int TIME_OUT_RUN_THREAD = 10;
        private const int TIME_OUT_STOP_THREAD = 100;
        #endregion Constants

        #region Attributes / Properties

        #region Attributes
        private bool _firstConnection = true;
        private bool _requestStopped;
        private DateTime _lastErrorServerLogged = DateTime.MinValue;
        private AutoResetEvent[] _resetEvents;
        private Thread _checkConnectionThread;
        
        
        private int _timeoutMiliseconds;
        
        private Socket _socket;
        // Socket state
        private SocketState _socketState = SocketState.Stopped;
        //Variable for control Thread
        private readonly ManualResetEvent _mEventsSocket = new ManualResetEvent(false);
        private bool _markToDelete;
        //Variables para control de trazas
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly StringBuilder stringBuilder = new StringBuilder();
        private bool _foundStartMarker = false;

        protected DateTime LastActivity = DateTime.MinValue;
        protected DateTime Timeout = DateTime.UtcNow;
        protected Socket Socket;
        #endregion

        #region Properties
        public delegate void TCPMessageReceivedEvent(string mensaje, string socketName);
        public event TCPMessageReceivedEvent TCPMessageReceived;

        public delegate void TCPMessageSentEvent(string message, string socketName);
        public event TCPMessageSentEvent TCPMessageSent;
        //Nombre para el socket
        public string SocketName { get; set; }
        //Define the max length for an incoming message. If a particular message exceed this length, the message is discarded and the connection should be closed
        public int MaxMessageLength { get; set; }

        public int ReconnectionTimeout { get; set; }

        //Define if socket act as server or client
        private bool IsServer { get; set; }

        protected int TimeoutForExecutingTask { get; set; }

        public bool IsConnected
        {
            get
            {
                try
                {
                    return 
                        Socket != null &&
                        Socket.Connected &&
                        _socketState == SocketState.Connected &&
                        !(Socket.Poll(1, SelectMode.SelectRead) && Socket.Available == 0);
                }
                catch (Exception ex)
                {
                    _log.Error("Exception in IsConnected", ex);
                    return false;
                }
            }
        }

        //IP Address for socket connection
        public string ConnectionIp { get; private set; }

        //Port for socket connection
        public int ConnectionPort { get; private set; }

      
        public string StartMarker { get; set; }

        public string EndMarker { get; set; }
        #endregion

        #endregion

        #region Constructor

        public TCPSocket(string name)
        {
            ConnectionPort = -1;
            ConnectionIp = string.Empty;
            MaxMessageLength = 4096;
            ReconnectionTimeout = 2000;
            SocketName = name;
        }
        #endregion


        private void MarkedToDelete()
        {
            _markToDelete = true;
        }


        #region Configuration methods
        
        public void ConfigureAsServer(int port)
        {
            ConfigureAsServer("0.0.0.0", port);
        }

        public void ConfigureAsServer(string connectionIp, int connectionPort)
        {
            if (!IsConnected)
            {
                ConnectionIp = connectionIp;
                ConnectionPort = connectionPort;
                IsServer = true;
            }
            else
            {
                throw new Exception("Impossible to change connection params while socket is connected");
            }
        }

        public void ConfigureAsClient(string connectionIp, int connectionPort, int maxTimeoutForExecutingTask = 0)
        {
            if (!IsConnected)
            {
                ConnectionIp = connectionIp;
                ConnectionPort = connectionPort;
                IsServer = false;
                TimeoutForExecutingTask = maxTimeoutForExecutingTask;
            }
            else
            {
                throw new Exception("Impossible to change connection params while socket is connected");
            }
        }
        #endregion




        #region Thread Control methods

        /// <summary>
        /// Método para iniciar el thread de control para el socket
        /// </summary>
        public void Start()
        {
            try
            {
                if (_checkConnectionThread != null)
                {
                    Stop();
                }
                _markToDelete = false;

                OnSocketStateChange(SocketState.Disconnected);


                _resetEvents = new AutoResetEvent[2];
                _resetEvents[EV_STOP] = new AutoResetEvent(false);
                _resetEvents[EV_STOPPED] = new AutoResetEvent(false);
                _checkConnectionThread = new Thread(CheckConnectionThread)
                {
                    IsBackground = true,
                };
                _checkConnectionThread.Start();

                Thread.Sleep(1000);
                if (_checkConnectionThread.IsAlive)
                    return;
                _log.Warn("Timeout to create check connection thread. Socket will be stopped");
                Stop();
            }
            catch (Exception ex)
            {
                _log.Error("Exception in socket start. Socket will be stopped", ex);
                Stop();
            }
        }

        public void SetTimeout(int timeoutms)
        {
            _timeoutMiliseconds = timeoutms;
        }
        public void Stop()
        {
            try
            {
               if (_resetEvents == null || _checkConnectionThread == null) return;
                _requestStopped = true;

                MarkedToDelete();
                _mEventsSocket.Set();
                Disconnect();

                _resetEvents[EV_STOP].Set();
                _resetEvents[EV_STOPPED].WaitOne(TIME_OUT_STOP_THREAD);
                if (_socket != null)
                {
                    _socket.Close();
                    _socket.Dispose();
                }

                var retries = 3;
                while (_checkConnectionThread.IsAlive && retries > 0)
                {
                    Thread.Sleep(2000);
                    retries--;
                }

                if (_checkConnectionThread.IsAlive)
                {
                    _checkConnectionThread.Abort();
                }

                _checkConnectionThread = null;
                _resetEvents[EV_STOP].Close();
                _resetEvents[EV_STOPPED].Close();
                _resetEvents = null;
                OnSocketStateChange(SocketState.Stopped);
                Socket = null;
                _socket = null;
            }
            catch (Exception ex)
            {
                _log.Error("Error en viMessageSocket.Stop() " + ex.Message, ex);
            }
        }

        private void CheckConnectionThread()
        {
           while (!_markToDelete)
            {
                try
                {
                    Connect();
                    Thread.Sleep(1000);
                    CheckActivity();

                    if ((_timeoutMiliseconds <= 0) || (DateTime.UtcNow <= Timeout.AddMilliseconds(_timeoutMiliseconds)))
                        continue;
                    //Send keepalive
                    if (IsConnected)
                        OnTimeout();
                    Timeout = DateTime.UtcNow;
                }
                catch (Exception ex)
                {
                    _log.Error("Exception in Check Connection Thread", ex);
                }
            }
            if (!_requestStopped)
                _log.Warn("Check Connection Thread was stopped without request ");

        }

        #endregion

        #region Connection management methods

        private void Connect()
        {
            if (IsConnected || 
                ConnectionIp == null || 
                ConnectionIp.Equals(string.Empty) || 
                ConnectionPort <= 0)
                return;
            if (!IsServer)
            {
                try
                {
                    if (!_firstConnection)
                    {
                        Disconnect();
                        Thread.Sleep(ReconnectionTimeout);
                    }
                    IPAddress ipAddress;
                    if (!IPAddress.TryParse(ConnectionIp, out ipAddress)) return;
                    var localEndPoint = new IPEndPoint(ipAddress, ConnectionPort);
                    var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                        ProtocolType.Tcp);
                    client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    OnSocketStateChange(SocketState.WaitingConnection);
                    client.BeginConnect(localEndPoint, ConnectToServerCallback,
                        client);
                    _mEventsSocket.WaitOne();
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    _log.Error("Exception when connecting in client mode", ex);
                    Disconnect();
                }
            }
            else
            {
                try
                {
                    Disconnect(); 
                    if (_firstConnection || _socket == null)
                    {
                       CreateServerSocket();
                    }

                    if (_socket != null && _socket.IsBound)
                    {
                        try
                        {

                            OnSocketStateChange(SocketState.WaitingConnection);
                            
                            _mEventsSocket.Reset();

                            _socket.BeginAccept(ConnectFromClientCallback, _socket);

                            _mEventsSocket.WaitOne();


                        }
                        catch (Exception e)
                        {
                            _socket = null;
                            _log.Error("Exception when listenting server mode", e);
                        }
                    }
                    else
                    {
                        _socket = null;
                    }

                }
                catch (Exception ex)
                {
                    _log.Error("Exception when connecting in server mode", ex);
                    Disconnect();
                }
            }
        }

        private void CreateServerSocket()
        {
            IPAddress ipAddress;
            if (!IPAddress.TryParse(ConnectionIp, out ipAddress))
            {
                if (ConnectionIp == "0.0.0.0")
                {
                    ipAddress = IPAddress.Any;
                }
            }
            if (ipAddress == null) return;
            var localEndPoint = new IPEndPoint(ipAddress, ConnectionPort);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {

                _socket.Bind(localEndPoint);
                _socket.Listen(MAX_CONNECTIONS);
            }
            catch (Exception e)
            {
                _log.Error("Error when creating server socket", e);
            }
        }

        public void DisconnectCallback(IAsyncResult ar)
        {

            try
            {
                // Get the socket that handles the client request.
                var handler = (Socket)ar.AsyncState;
                handler.EndDisconnect(ar);
                OnSocketStateChange(SocketState.Disconnected);

            }
            catch(Exception e)
            {
                _log.Error("Error processing DisconnectCallback", e);
            }
        }

        private void CheckActivity()
        {
            if (Socket == null) return;
            var dt = DateTime.UtcNow - LastActivity;
            if (!OnActivityTimeOut(dt.TotalMilliseconds))
                return;
            _log.Warn("Disconnected for Inactivity! (" + dt.TotalMilliseconds + ")");
            LastActivity = DateTime.UtcNow;
            Disconnect();
        }

        private void Disconnect()
        {
            try
            {
                if (Socket == null) return;
                try
                {
                    if (Socket.Connected)
                        Socket.Disconnect(false);
                }
                catch
                {
                    
                }

                try
                {
                    Socket.Close();
                }
                catch
                {
                    
                }

                OnSocketStateChange(SocketState.Disconnected);

                Socket.Dispose();
            }
            catch (Exception ex)
            {
                _log.Error("Exception while disconnecting", ex);
                Socket = null;
                OnSocketStateChange(SocketState.Disconnected);
            }
        }

        private void ConnectToServerCallback(IAsyncResult ar)
        {
            try
            {
                _firstConnection = false;

                LastActivity = DateTime.UtcNow;
                Socket = (Socket)ar.AsyncState;
                Socket.EndConnect(ar);

                var state = new StateObject { workSocket = Socket };

                Socket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, ReadCallback,state);
                OnSocketStateChange(SocketState.Connected);
                _log.Info($"Socket {SocketName} connected to {Socket.RemoteEndPoint} trough {Socket.LocalEndPoint}");
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == SocketError.ConnectionRefused)
                {
                    if (_lastErrorServerLogged.AddSeconds(60) < DateTime.UtcNow)
                    {
                        _log.Warn($"Connection Refused when trying to connect: {e.Message}");
                        _lastErrorServerLogged = DateTime.UtcNow;
                    }
                    //Descanso
                    Thread.Sleep(500);
                }
                else
                {
                    if (_lastErrorServerLogged.AddSeconds(60) < DateTime.UtcNow)
                    {
                        _log.Fatal("Exception while trying to connect", e);
                        _lastErrorServerLogged = DateTime.UtcNow;
                    }
                    //Descanso
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                _log.Error("Exception while trying to connect", ex);
                Disconnect();
            }
            _mEventsSocket.Set();
        }

        private void ConnectFromClientCallback(IAsyncResult ar)
        {
            try
            {
                LastActivity = DateTime.UtcNow;
                // Signal the main thread to continue.
                // Get the socket that handles the client request.
                var listener = (Socket)ar.AsyncState;
                var handler = listener.EndAccept(ar);
                _mEventsSocket.Set();
                Socket = handler;
                // Create the state object.
                var state = new StateObject { workSocket = handler };

                OnSocketStateChange(SocketState.Connected);
                _firstConnection = false;
                _log.Info($"Socket {SocketName} received connection from {Socket.RemoteEndPoint} trough {_socket.LocalEndPoint}");
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, ReadCallback, state);
            }
            catch (Exception ex)
            {
                _log.Error("Exception while accepting client connection", ex);
                Disconnect();
            }
        }

        /// <summary>
        /// Delegado para notifcar el cambio de estado del Socket
        /// </summary>
        /// <param name="socketname">Nombre del socket que notifica</param>
        /// <param name="value">Nuevo estado del socket</param>
        public delegate void SocketStateChangedEvent(string socketname, SocketState value);
        public event SocketStateChangedEvent SocketStateChanged;


        // Delegado para que se notifique si se ha de reiniciar la conexión
        public delegate bool ActivityTimeOutEvent(double elapsedMiliseconds);
        public event ActivityTimeOutEvent ActivityTimeOut;

        public event EventHandler TimeoutEvent;

        private void OnSocketStateChange(SocketState newStateValue)
        {
            if (_socketState != newStateValue)
            {
                SocketStateChanged?.Invoke(SocketName, newStateValue);
            }
            _socketState = newStateValue;
        }

        private bool OnActivityTimeOut(double elapsedMiliseconds)
        {
            return ActivityTimeOut != null && ActivityTimeOut(elapsedMiliseconds);
        }

        private void OnTimeout()
        {
            TimeoutEvent?.Invoke(this, new EventArgs());
        }

        #endregion

        //protected abstract void ProcessDataReceived(ReceiveStateObject state, int bytesReaded);
        public void ProcessDataReceived(byte[] readBuffer, int bytesReaded)
        {
            //Añadimos lo recibido a lo que tuvieramos en el buffer
            //stringBuilder.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
            stringBuilder.Append(Encoding.UTF8.GetString(readBuffer, 0, bytesReaded));

            //Lo copiamos a una cadena para hacer las búsquedas necesarias de los simbolos de apertura y cierre
            var received = stringBuilder.ToString();

            //Limpiamos el buffer. Al final del proceso pondre lo que me quede pendiente
            stringBuilder.Clear();

            var completed = false;

            while (!completed) //Bucle para procesar mientras nos quede información susceptile de ser o formar parte de un message
            {

                if (!_foundStartMarker) //No teniamos ningún message previamente iniciado, por lo que en esta parte buscamos abrir uno nuevo
                {
                    //Buscar el simbolo de inicio
                    var idx = received.IndexOf(StartMarker, StringComparison.Ordinal);
                    //if (idx > 0) _log.Warn("Discarded content: " + received.Substring(0, idx + 1));
                    if (StartMarker == string.Empty)
                        idx = 0;
                    if (idx > -1)
                    {
                        //INICIO ENCONTRADO!!!!
                        _foundStartMarker = true; //Si encontramos el simbolo de inicio, cambiamos de estado

                        //Si no hay message iniciado previamente solo interesa a partir del START. Lo anterior es basura.
                        // de hecho, si tuvieramos "algo" entre un END y un START deberemos descartarlo
                        received = received.Substring(idx + StartMarker.Length); //Descartar lo que haya antes del START.
                        //NOTA: TAMBIÉN SE DESCARTA EL SIMBOLO DE START, PORQUE NO FORMA PARTE DE NUESTRO MENSAJE

                        //Podria ocurrir que despues del simbolo START no haya nada porque es donde se acaba el buffer en esta pasada
                        //En este caso, el resto de lacadena es vacia y podemos salir del proceso a la espera de que lleguen más datos
                        if (received.Equals(String.Empty))
                        {
                            completed = true;
                        }
                    }
                    else
                    {
                        //Aparentemente no hay caracter de inicio, pero puede ocurrir que el buffer lo haya partido por la mitad si tiene 2 ó más bytes de longitud
                        // Por ejemplo: BUFFER ACTUAL PROXIMA LECTURA
                        // [ ..... STARTMensaje1ENDST] [ARTMensaje2END ..... ]
                        stringBuilder.Append(received); //Metemos lo que nos queda de cadena, para que dispongamos de ello en la próxima lectura
                        completed = true;
                    }
                }
                else
                {
                    //ESTAMO EN ESTADO DE UN MENSAJE INICIADO PREVIAMENTE POR LO QUE AHORA LO QUE BUSCAMOS ES EL FIN
                    var idx = received.IndexOf(EndMarker, StringComparison.Ordinal); //Buscar simbolo de Fin de message
                    //El indice ha de ser mayor que 0 y menor que el fin del message
                    if (idx > -1 && idx <= MaxMessageLength)
                    {
                        _foundStartMarker = false; //Cambiar el estado, porque hemos encontrado el fin
                        var content = received.Substring(0, idx);

                        //PROCESAR MENSAJE O ENVIAR A QUIEN PROCEDA....

                        //foundMessages++;

                        LastActivity = DateTime.UtcNow;
                        var swTask = new Stopwatch();
                        swTask.Start();
                        Task.Factory.StartNew(() => OnMessageReceived(content, swTask));

                        received = received.Substring(idx + EndMarker.Length);
                        if (received.Equals(string.Empty))
                        {
                            completed = true;
                        }
                    }
                    else
                    {
                        // Console.WriteLine(received);
                        if (!string.IsNullOrEmpty(received))
                        {
                            stringBuilder.Append(received);
                            if (stringBuilder.Length > MaxMessageLength + EndMarker.Length)
                            {
                                stringBuilder.Clear();
                                _foundStartMarker = false;
                                received = string.Empty;
                                _log.Warn("Message lenght exceds the buffer size. Restart socket");
                            }
                        }
                        completed = true;
                    }
                }
            }
            //Continue receiving data
        }
        private void OnMessageReceived(string message, Stopwatch sw)
        {
            var elapsed = sw.ElapsedMilliseconds;
            if (TimeoutForExecutingTask > 0 && elapsed > TimeoutForExecutingTask)
            {
                _log.Warn($"Discard Message {message} takes {elapsed.ToString("00000")} ms to start the task");
                return;
            }
            LastActivity = DateTime.UtcNow;
            Timeout = DateTime.UtcNow;
            TCPMessageReceived?.Invoke(message, SocketName);
        }


        #region Send Management

        public bool Send(string data)
        {
            var byteData = Encoding.ASCII.GetBytes($"{StartMarker}{data}{EndMarker}");
            bool salida = false;
            if (IsConnected)
            {
                try
                {
                    StateObject state = new StateObject() { buffer = byteData, workSocket = Socket };
                    // Convert the string data to byte data using ASCII encoding.
                    Socket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, SendCallback, state);
                    salida = true;
                }
                catch (Exception ex)
                {
                    _log.Error("There is a problem sendig the message",ex);
                    salida = false;
                }
            }
            return salida;
        }

        private void SendCallback(IAsyncResult ar)
        {
            var state = (StateObject)ar.AsyncState;
            try
            {

                var handler = state.workSocket;
                var bytesSent = handler.EndSend(ar);
                if (bytesSent == 0)
                {
                    _log.Warn("0 bytes sent but the message has " + state.buffer.Length + " bytes ");
                }
                // m_dLastActivity = DateTime.UtcNow;
                OnMessageSent(state.buffer);
                //Interlocked.Add(ref _sentBytes, bytesSent);
            }
            catch (Exception ex)
            {
                _log.Error("Error enviando message " + (state != null && state.buffer != null && state.buffer.Count() > 0 ? Encoding.ASCII.GetString(state.buffer) : "'SIN DATOS?'") + ex.Message, ex);
            }
        }

        private void OnMessageSent(byte[] message)
        {
            var asciiMessage = Encoding.ASCII.GetString(message).Replace(StartMarker, string.Empty).Replace(EndMarker, string.Empty);
            TCPMessageSent?.Invoke(asciiMessage, SocketName);
        }


        #endregion


        #region ReceiveManagement

        /// <summary>
        /// Operación de lectura asincrona
        /// </summary>
        /// <param name="ar"></param>
        private void ReadCallback(IAsyncResult ar)
        {
            //String content = String.Empty;
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            try
            {
                //ESDNH: Si aquí llegamos porque se ha cerrado el socket, ojo! porque la siguiente linea dara objectdisposedexception
                //y puede generarnos cosas raras, duplicados, threads fantasmas, etc.
                //a todo esto, hay que saber si hemos entrado aqui por recepción o por desconexión...
                int bytesRead = handler.EndReceive(ar);
                if (bytesRead <= 0)
                {
                    //Si ha saltado el callback y no recibo nada, estamos desconectados
                    Disconnect();
                }
                else if (bytesRead > 0)
                {
                    ProcessDataReceived(state.buffer, bytesRead);
                }

                try
                {
                    //ESDNH: Añado esta linea (posiblemente la solucion a los threads fantasma!!!!!
                    //Basicamente, el handler no quedaba referenciado, por lo que aunte una desconexion el socket se quedaba contionuamente entre
                    //beginrecive endrecieve todo dando vueltas infinitamente, incrementando 20% CPU en cada vuelta
                    if (IsConnected)
                    {
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, ReadCallback, state);
                    }
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.Shutdown)
                    {
                        //se ha cerrado el socket. Desconecto...
                        Disconnect();
                    }
                    else
                        throw ex;
                }
                catch (ObjectDisposedException)
                {
                    Disconnect();
                }
                catch (Exception ex)
                {
                    _log.Fatal("Fatal Exception on data reception", ex);
                    Disconnect();
                }
            }
            catch (ObjectDisposedException)
            {
                Disconnect();
            }
            catch (Exception ex)
            {
                _log.Fatal("Fatal Exception on data reception. The socket will be disconnected ", ex);
                Disconnect();
            }
        }

        #endregion

    }

    public enum SocketState
    {
        Stopped = -1,
        Disconnected = 0,
        WaitingConnection = 1,
        Connected = 2
    }
}
