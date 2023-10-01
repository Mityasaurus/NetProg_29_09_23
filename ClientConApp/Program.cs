using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientConApp
{
    public class ClientApp
    {
        IPEndPoint endPoint;
        Socket socket;

        static void Main(string[] args)
        {

        }

        private async void ConnectAction(string ip, int port)
        {
            endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                await socket.ConnectAsync(endPoint);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Connect(string ip, int port)
        {
            Task task = new Task(() => ConnectAction(ip, port));
            task.Start();
        }

        public async Task<string> SendMessage(string message)
        {
            try
            {
                if (message.Length == 0)
                {
                    throw new Exception("Message is empty");
                }
                if (!socket.Connected)
                {
                    throw new Exception("Connection error!");
                }

                byte[] data = Encoding.UTF8.GetBytes(message);
                await socket.SendAsync(data, SocketFlags.None);

                ////////////////////////////////////////////////

                data = new byte[256];
                StringBuilder sb = new StringBuilder();
                int bytes = 0;

                do
                {
                    DateTime time = DateTime.Now;
                    bytes = await socket.ReceiveAsync(data, SocketFlags.None);
                    sb.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    IPEndPoint serverEndPoint = socket.RemoteEndPoint as IPEndPoint;
                    return $"О {time.ToShortTimeString()} вiд {serverEndPoint.Address} отримано рядок: " + $"{sb}";
                } while (socket.Available > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}