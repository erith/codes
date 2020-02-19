   public class Client
    {
        ClientWebSocket cws;
        Task reConnectTask;
        CancellationTokenSource ConnectionToken;
        int BufferSize = 4096;
        public event Action<string> OnMessage;
        bool isConnected = false;
        ManualResetEventSlim eventSlim = new ManualResetEventSlim(false);

        async Task<bool> ConnectAsync(string address)
        {
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
            {
                try
                {
                    if (cws != null)
                    {
                        Close();
                        cws.Dispose();
                        cws = null;
                    }
                    cws = new ClientWebSocket();
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    cws.Options.UseDefaultCredentials = false;
                    cws.Options.Credentials = new NetworkCredential("nobita", "password");
                    await cws.ConnectAsync(new Uri(address), cts.Token);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connect Error");
                    //Console.WriteLine(ex.StackTrace);
                    return false;
                }
            }
        }

        public async Task ReceiveLoop()
        {
            Console.WriteLine("RECEIVE LOOOOOOOOOOOOOOOOOOP");
            int count = 0;
            while (!ConnectionToken.IsCancellationRequested)
            {
                // Read the bytes from the web socket and accumulate all into a list.
                var buffer = new ArraySegment<byte>(new byte[BufferSize]);
                WebSocketReceiveResult result = null;
                var allBytes = new List<byte>();

                //Console.WriteLine("EVENT SET");
                eventSlim.Set();
                do
                {
                    if (cws.State == WebSocketState.Open)
                    {
                        Console.WriteLine(cws.State.ToString());
                        using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2)))
                        {
                            try
                            {
                                result = await cws.ReceiveAsync(buffer, cts.Token);
                                for (int i = 0; i < result.Count; i++)
                                {
                                    allBytes.Add(buffer.Array[i]);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("RECV ERROR");
                                //Console.WriteLine(ex.StackTrace);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                while (result != null && !result.EndOfMessage);

                eventSlim.Reset();

                var text = Encoding.UTF8.GetString(allBytes.ToArray(), 0, allBytes.Count);
                count++;
                OnMessage?.Invoke(text);

                if (cws == null || cws.State != WebSocketState.Open)
                    await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        public async Task Send(string message)
        {
            if (cws.State == WebSocketState.Open)
            {
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
                {
                    try
                    {
                        ArraySegment<byte> data = new ArraySegment<byte>(UTF8Encoding.UTF8.GetBytes(message));
                        await cws.SendAsync(data, WebSocketMessageType.Text, true, cts.Token);
                    }
                    catch (Exception e)
                    {
                        await Task.FromException(e);
                    }
                }
            }
        }

        public async Task Start(string address = "wss://127.0.0.1:9090/chat")
        {
            isConnected = await ConnectAsync(address);

            ConnectionToken = new CancellationTokenSource();

            Task t = Task.Run(ReceiveLoop);
            
            reConnectTask = new Task(async () =>
            {

                while (!ConnectionToken.IsCancellationRequested)
                {
                    if (cws.State == WebSocketState.Aborted || cws.State == WebSocketState.None || cws.State == WebSocketState.Closed)
                    {
                        Console.WriteLine("DISCONNECTED. CONNECT RETRY...");
                        isConnected = await ConnectAsync(address);
                        if (isConnected)
                        {
                            Console.WriteLine("CONNECTED.");
                        }                            
                    }

                    await Task.Delay(TimeSpan.FromSeconds(3));
                }
            });
            reConnectTask.Start();
        }

        public void Close()
        {
            if (cws != null && cws.State == WebSocketState.Open)
            {
                eventSlim.Wait(TimeSpan.FromSeconds(2));
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
                {
                    try
                    {
                        cws.CloseAsync(WebSocketCloseStatus.NormalClosure, "LOG OUT", cts.Token).Wait();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        ConnectionToken.Cancel();
                        cws = null;
                    }
                }
            }
        }

        public void Stop()
        {
            Close();
        }
    }
