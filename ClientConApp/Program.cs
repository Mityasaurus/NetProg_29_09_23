﻿using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;

namespace ClientConApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int port = 8080;
            string ip = "127.0.0.1";
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(endPoint);
                Console.WriteLine("Connection success");
                string message = "Привiт сервере!";
                byte[] data = Encoding.UTF8.GetBytes(message);
                await socket.SendAsync(data, SocketFlags.None);

                ///////////////////////////////////////////////

                socket.Close();
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                port = 8081;

                endPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                socket.Bind(endPoint);
                socket.Listen();

                Socket client = await socket.AcceptAsync();
                Console.WriteLine("Server replied");

                data = new byte[256];
                StringBuilder sb = new StringBuilder();
                int bytes = 0;

                do
                {
                    DateTime time = DateTime.Now;
                    bytes = await client.ReceiveAsync(data, SocketFlags.None);
                    sb.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    IPEndPoint clientEndPoint = client.RemoteEndPoint as IPEndPoint;
                    Console.WriteLine($"О {time.ToShortTimeString()} вiд {clientEndPoint.Address} отримано рядок: " +
                        $"{sb}");
                } while (client.Available > 0);

                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}