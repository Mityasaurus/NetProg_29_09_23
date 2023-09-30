using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerConApp
{
    internal class Program
    { 
        static async Task Main(string[] args)
        {
            int port = 8080;
            string ip ="127.0.0.1";
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Bind(endPoint);
                socket.Listen();

                Console.WriteLine("Server started. Waiting for connections...");
                Socket client = await socket.AcceptAsync();
                Console.WriteLine("Client connected");

                byte[] data = new byte[256];
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

                /////////////////////////////////////////////

                string message = "Привiт клiєнте!";
                data = Encoding.UTF8.GetBytes(message);
                await client.SendAsync(data, SocketFlags.None);

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