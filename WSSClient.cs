using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTickClient
{
    public class WSSClient
    {
        private const int ReceiveChunkSize = 4096;
        private const int SendChunkSize = 4096;

        private ClientWebSocket _ws;
        private Uri _uri;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken _cancellationToken;

        private Action<WSSClient> _onConnected;
        private Action<string, WSSClient> _onMessage;
        private Action<WSSClient> _onDisconnected;

        private int connectRetryCount = -1;
        int retryCount = 0;

        public bool IsOpen
        {
            get
            {
                return _ws != null && _ws.State == WebSocketState.Open;
            }
        }

        public WSSClient(string uri, int connectRetryCount = -1)
        {
            _uri = new Uri(uri);
            this.connectRetryCount = connectRetryCount;
        }

        public void Init()
        {
            if (_ws != null)
            {
                try
                {
                    _ws.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
                catch(Exception e)
                {
                    Console.WriteLine("CLOSE 실패"+e.Message);
                }
                finally
                {
                    _ws?.Dispose();
                    _ws = null;
                }

            }
            _ws = new ClientWebSocket();
            _ws.Options.KeepAliveInterval = TimeSpan.FromSeconds(20);
            _cancellationToken = _cancellationTokenSource.Token;
            _ws.Options.KeepAliveInterval = TimeSpan.FromSeconds(20);
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            _ws.Options.UseDefaultCredentials = false;
            _ws.Options.Credentials = new NetworkCredential("nobita", "password");
        }

        public static WSSClient Create(string uri)
        {
            return new WSSClient(uri);
        }

        public WSSClient Connect()
        {
            Task t = ConnectAsync();
            return this;
        }


        public WSSClient OnConnect(Action<WSSClient> onConnect)
        {
            _onConnected = onConnect;
            return this;
        }


        public WSSClient OnDisconnect(Action<WSSClient> onDisconnect)
        {
            _onDisconnected = onDisconnect;
            return this;
        }


        public WSSClient OnMessage(Action<string, WSSClient> onMessage)
        {
            _onMessage = onMessage;
            return this;
        }

        public async Task SendMessage(string message)
        {
            await SendMessageAsync(message);
        }


        public void TryConnect(int retry = -1)
        {
            connectRetryCount = retry;
            Task.Run(() =>
            {
                
                while (connectRetryCount == -1 || retryCount < connectRetryCount)
                {
                    if (_ws == null || _ws.State != WebSocketState.Open)
                    {
                        try
                        {
                            Console.WriteLine("재접속 시도..");
                            Init();
                            Connect();

                            if (_ws.State == WebSocketState.Open)
                                retryCount = 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("재접속 시도 실패 - "+e.Message);
                        }
                        retryCount++;
                        Console.WriteLine("시도 횟수 " + retryCount);

                    }
                    Thread.Sleep(1000);
                }
            });
        }

        private async Task SendMessageAsync(string message)
        {
            if (_ws.State != WebSocketState.Open)
            {
                //throw new Exception("Connection is not open.");
                await Task.FromException(new Exception("Connection is not open"));
            }

            var messageBuffer = Encoding.UTF8.GetBytes(message);
            var messagesCount = (int)Math.Ceiling((double)messageBuffer.Length / SendChunkSize);

            for (var i = 0; i < messagesCount; i++)
            {
                var offset = (SendChunkSize * i);
                var count = SendChunkSize;
                var lastMessage = ((i + 1) == messagesCount);

                if ((count * (i + 1)) > messageBuffer.Length)
                {
                    count = messageBuffer.Length - offset;
                }

                await _ws.SendAsync(new ArraySegment<byte>(messageBuffer, offset, count), WebSocketMessageType.Text, lastMessage, _cancellationToken);
            }
        }

        private async Task ConnectAsync()
        {
            try
            {
                await _ws.ConnectAsync(_uri, _cancellationToken);
                CallOnConnected();
                StartListen();
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }

        }

        private async void StartListen()
        {
            var buffer = new byte[ReceiveChunkSize];

            try
            {
                while (_ws.State == WebSocketState.Open)
                {
                    var stringResult = new StringBuilder();


                    WebSocketReceiveResult result;
                    do
                    {
                        result = await _ws.ReceiveAsync(new ArraySegment<byte>(buffer), _cancellationToken);

                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            await
                                _ws.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                            CallOnDisconnected();
                        }
                        else
                        {
                            var str = Encoding.UTF8.GetString(buffer, 0, result.Count);
                            stringResult.Append(str);
                        }

                    } while (!result.EndOfMessage);

                    CallOnMessage(stringResult);

                }
            }
            catch (Exception)
            {
                CallOnDisconnected();
            }
            finally
            {
                _ws.Dispose();
            }
        }

        private void CallOnMessage(StringBuilder stringResult)
        {
            if (_onMessage != null)
                RunInTask(() => _onMessage(stringResult.ToString(), this));
        }

        private void CallOnDisconnected()
        {
            if (_onDisconnected != null)
                RunInTask(() => _onDisconnected(this));
        }

        private void CallOnConnected()
        {
            if (_onConnected != null)
                RunInTask(() => _onConnected(this));
        }

        private static void RunInTask(Action action)
        {
            Task.Factory.StartNew(action);
        }


        public async Task SendBytes(byte[] bytes)
        {
            await SendBytesAsync(bytes);
        }

        private async Task SendBytesAsync(byte[] bytes)
        {
            if (_ws.State != WebSocketState.Open)
            {
                //throw new Exception("Connection is not open.");
                await Task.FromException(new Exception("Connection is not open"));
            }

            var messageBuffer = bytes;
            var messagesCount = (int)Math.Ceiling((double)messageBuffer.Length / SendChunkSize);

            for (var i = 0; i < messagesCount; i++)
            {
                var offset = (SendChunkSize * i);
                var count = SendChunkSize;
                var lastMessage = ((i + 1) == messagesCount);

                if ((count * (i + 1)) > messageBuffer.Length)
                {
                    count = messageBuffer.Length - offset;
                }

                await _ws.SendAsync(new ArraySegment<byte>(bytes, offset, count), WebSocketMessageType.Binary, lastMessage, _cancellationToken);
            }
        }
    }
}


            //WSSClient client = new WSSClient("wss://127.0.0.1:9090/chat");
            
            //client.TryConnect(5);
            //client.OnMessage((s, w) =>
            //{
            //    Console.WriteLine(s);
            //});
            //Task.Run(async () =>
            //{
            //    while (true)
            //    {
            //        try
            //        {
            //            if (client.IsOpen)
            //                await client.SendMessage(Guid.NewGuid().ToString());
            //        }
            //        catch (Exception e)
            //        {
            //            Console.WriteLine(e.Message);
            //        }
            //        Thread.Sleep(1000);
            //    }
            //});

            //Console.ReadLine();
