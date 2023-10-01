using ClientConApp;

namespace ClientUI_HW_2
{
    public partial class Form1 : Form
    {
        NetworkClass client;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            client = new NetworkClass();
            string ip = "127.0.0.1";
            int port = 8080;
            try
            {
                client.Connect(ip, port);
                //

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private async void btnGetDate_ClickAsync(object sender, EventArgs e)
        {
           
            await client.SendMessage("date");


        }

        private async void btnGetTime_ClickAsync(object sender, EventArgs e)
        {
            //await client.SendMessage("time");
            tb_Responce.Text = await Task.Run(() => client.ReceiveMessage());


        }
    }
}