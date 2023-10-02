﻿using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<string> answers = new List<string>
            {
                "Hi client!",
                "I am an AI",
                "I can send messages",
                "Bye"
            };

            int port = 8080;
            string ip = "127.0.0.1";
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Bind(endPoint);
                socket.Listen();

                Console.WriteLine("Choose a setup\n1 - Human | 2 - AI");
                string workMode = Console.ReadLine();

                Console.WriteLine("Server started. Waiting for connections...");
                Socket client = await socket.AcceptAsync();
                Console.WriteLine("Client connected");

                bool job = true;

                while(job)
                {
                    byte[] data = new byte[256];
                    StringBuilder sb = new StringBuilder();
                    int bytes = 0;

                    do
                    {
                        bytes = await client.ReceiveAsync(data, SocketFlags.None);
                        sb.Append(Encoding.UTF8.GetString(data, 0, bytes));
                        Console.WriteLine($"{sb}");
                        if(sb.ToString().ToLower() == "bye")
                        {
                            socket.Close();
                            job = false;
                        }
                    } while (client.Available > 0);

                    if(job == false)
                    {
                        break;
                    }
                    string message;
                    if (workMode == "1")
                    {
                        message = Console.ReadLine();
                    }
                    else
                    {
                        Random rand = new Random();
                        message = answers[rand.Next(0, answers.Count)];
                        Thread.Sleep(3000);
                        Console.WriteLine(message);
                    }

                    data = Encoding.UTF8.GetBytes(message);
                    await client.SendAsync(data, SocketFlags.None);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}