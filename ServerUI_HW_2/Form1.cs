using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerUI_HW_2
{
    public partial class Form1 : Form
    {
        IPEndPoint endPoint;
        Socket socket;
        Socket client;

        public Form1()
        {
            InitializeComponent();
        }
        private async Task ServerStart()
        {
            try
            {
                int port = 8080;
                string ip = "127.0.0.1";
                endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(endPoint);
                socket.Listen();

                StringBuilder sb = new StringBuilder(tb_log.Text);
                sb.Append("Server started. Waiting for connections...\n");
                //tb_log.Text = sb.ToString();
                sb.Clear();

                client = await socket.AcceptAsync();

                sb.Append(tb_log.Text);
                sb.Append("Client connected\n");
                //tb_log.Text = sb.ToString();
                sb.Clear();

                string answer = await WaitForRequest();
                await SendResponce(answer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void btn_start_Click(object sender, EventArgs e)
        {
            await Task.Run(() => ServerStart());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private async Task<string> WaitForRequest()
        {
            string message = "Error request";
            try
            {
                byte[] data = new byte[256];
                StringBuilder sb = new StringBuilder();
                int bytes = 0;

                do
                {
                    bytes = client.Receive(data, SocketFlags.None);
                    sb.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    if (sb.ToString() == "date")
                    {
                        message = DateTime.Now.ToLongDateString();
                    }
                    else if (sb.ToString() == "time")
                    {
                        message = DateTime.Now.ToLongTimeString();
                    }
                } while (client.Available > 0);

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return message;
        }

        private async Task SendResponce(string message)
        {
            byte[] data = new byte[256];
            data = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(data, SocketFlags.None);
        }
    }
}