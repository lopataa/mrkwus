using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SocketIOClient;

namespace MrkView
{
    class Communication
    {
        public event Action<Communication> OnConnected;
        public event Action<Communication> OnDisconnected;
        public event Action<Communication, string, float, float, float> LoginPlayerData;
        public event Action<Communication, string, string, float, float, float> PlayerEnter;
        public event Action<Communication, string, float, float, float> PlayerMove;
        public event Action<Communication, string> PlayerLeave;
        public event Action<Communication, string> ServerError;
        public bool Connected
        {
            get
            {
                if (socket?.Connected == true)
                    return true;
                else
                    return false;
            }
        }

        SocketIO socket;

        public void Connect(string url, string username)
        {
            if (socket != null)
                Disconnect();

            socket = new SocketIO(url);

            socket.OnConnected += Socket_OnConnected;
            socket.OnDisconnected += Socket_OnDisconnected;

            socket.On("login", response =>
            {
                OnConnected?.Invoke(this);
                LoginPlayerData?.Invoke(this, response.GetValue<string>(0),
                    response.GetValue<float>(1),
                    response.GetValue<float>(2),
                    response.GetValue<float>(3));
            });

            socket.On("error", response =>
            {
                ServerError?.Invoke(this, response.GetValue<string>(0));
            });

            socket.On("join", response =>
            {
                PlayerEnter?.Invoke(this, response.GetValue<string>(0), response.GetValue<string>(1),
                    response.GetValue<float>(2),
                    response.GetValue<float>(3),
                    response.GetValue<float>(4));
            });
            
            socket.On("leave", response =>
            {
                PlayerLeave?.Invoke(this, response.GetValue<string>(0));
            });
            
            socket.On("move", response =>
            {
                PlayerMove?.Invoke(this, response.GetValue<string>(0),
                    response.GetValue<float>(1),
                    response.GetValue<float>(2),
                    response.GetValue<float>(3));
            });

            socket.ConnectAsync().ContinueWith((_) =>
            {
                socket.EmitAsync("login", username);
            });
        }

        public void Disconnect()
        {
            if (socket == null)
                return;

            socket.DisconnectAsync().Wait();
            Cleanup();
        }

        public void SendLocation(float x, float y, float rot)
        {
            socket.EmitAsync("location", x, y, rot);
        }

        private void Socket_OnConnected(object sender, EventArgs e)
        {
            OnConnected?.Invoke(this);
        }

        private void Socket_OnDisconnected(object sender, string e)
        {
            OnDisconnected?.Invoke(this);
            Task.Delay(200).ContinueWith((_) => Disconnect());
        }

        private void Cleanup()
        {
            socket.OnConnected -= Socket_OnConnected;
            socket.OnDisconnected -= Socket_OnDisconnected;
            try
            { 
                // mby like SOTP throwing NRE!
                socket?.Dispose();
            }
            catch { Trace.WriteLine("weird exceptiò happened again..."); }
            socket = null;
        }
    }
}
