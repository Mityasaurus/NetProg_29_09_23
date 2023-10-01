using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientConApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter ip address");
            IPAddress ip;
            if(IPAddress.TryParse(Console.ReadLine(), out ip) == false)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("Enter port");
            int port;
            if (int.TryParse(Console.ReadLine(), out port) == false)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            try
            {
                IPEndPoint endPoint = new IPEndPoint(ip, port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(endPoint);
                Console.WriteLine("Connection success");

                bool job = true;

                while(job)
                {
                    string message = Console.ReadLine();
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    await socket.SendAsync(data, SocketFlags.None);

                    data = new byte[256];
                    StringBuilder sb = new StringBuilder();
                    int bytes = 0;

                    do
                    {
                        bytes = await socket.ReceiveAsync(data, SocketFlags.None);
                        sb.Append(Encoding.UTF8.GetString(data, 0, bytes));
                        Console.WriteLine($"{sb}");
                        if(sb.ToString().ToLower() == "bye")
                        {
                            socket.Close();
                            job = false;
                            break;
                        }
                    } while (socket.Available > 0);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}