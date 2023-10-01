using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI_HW_2
{
    public class NetworkClass
    {
        IPEndPoint endPoint;
        Socket socket;

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

        public async Task<string> ReceiveMessage()
        {
            try
            {
                
                byte[] data = new byte[256];
                StringBuilder sb = new StringBuilder();
                int bytes = 0;

                do
                {
                    bytes = await socket.ReceiveAsync(data, SocketFlags.None);
                    sb.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    return sb.ToString();
                } while (socket.Available > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public async Task SendMessage(string message)
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
