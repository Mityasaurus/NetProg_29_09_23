using ClientConApp;

namespace ClientUI_HW_2
{
    public partial class Form1 : Form
    {
        ClientApp client;
        public Form1()
        {
            InitializeComponent();

            client = new ClientApp();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = tb_IP.Text;
            int port = int.Parse(tb_Port.Text);
            try
            {
                client.Connect(ip, port);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private async void btnGetDate_ClickAsync(object sender, EventArgs e)
        {
            string answer = await client.SendMessage("date");

            tb_Responce.Text = answer;
        }

        private async void btnGetTime_ClickAsync(object sender, EventArgs e)
        {
            string answer = await client.SendMessage("time");

            tb_Responce.Text = answer;
        }
    }
}