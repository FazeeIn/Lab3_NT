using System.Net.Sockets;
using System.Text;

namespace Lab3.Client
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void подключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();

            var res = form2.ShowDialog(this);

            if (res == DialogResult.Cancel)
            {
                return;
            }
            var random = new Random();

            var clientPort = random.Next(8000, 16000);

            client = new TcpClient("localhost", clientPort);

            client.Connect("localhost", form2.Port);
        }

        private async Task ClientHandler(TcpClient client)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox1.TabStop = false;
            textBox1.GotFocus += (s, e) => { this.ActiveControl = null; };
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var data = textBox2.Text.Split(' ', 3);

            var stream = client.GetStream();

            if (String.CompareOrdinal(data[0], "-m") == 0
                && data.Length == 3)
            {
                var bytes = Encoding.UTF8.GetBytes(textBox2.Text);

                await stream.WriteAsync(bytes);
            }

            if (String.CompareOrdinal(data[0], "-l") == 0
                && data.Length == 1)
            {
                var bytes = Encoding.UTF8.GetBytes(textBox2.Text);

                await stream.WriteAsync(bytes);
            }

            AddTextToLog("Произошла ошибка при обработке команды.");
            
            return;
        }

        private void AddTextToLog(string text)
        {
            textBox1.Text += DateTime.Now + $" {text} " + Environment.NewLine;
        }
    }
}
