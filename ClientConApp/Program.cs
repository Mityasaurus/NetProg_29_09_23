using System.Net;
using System.Net.Sockets;
using System.Text;

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
                Console.WriteLine("Get:");
                Console.WriteLine("1 - Date\n2 - Time");
                string message = "error";
                string choice = Console.ReadLine();
                if(choice == "1")
                {
                    message = "date";
                }
                else if(choice == "2") 
                {
                    message = "time";
                }

                byte[] data = Encoding.UTF8.GetBytes(message);
                await socket.SendAsync(data, SocketFlags.None);

                data = new byte[256];
                StringBuilder sb = new StringBuilder();
                int bytes = 0;

                do
                {
                    bytes = await socket.ReceiveAsync(data, SocketFlags.None);
                    sb.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    Console.WriteLine(sb.ToString());
                } while (socket.Available > 0);

                Console.ReadKey();

                socket.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}