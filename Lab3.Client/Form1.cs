using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab3.Client
{
    public partial class Form1 : Form
    {
        private TcpClient? client;

        private bool ClientIsOn = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void подключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SetConnection();
        }

        private async Task SetConnection()
        {
            try
            {
                var form2 = new Form2();

                var res = form2.ShowDialog(this);

                if (res == DialogResult.Cancel)
                {
                    return;
                }

                client = new TcpClient();

                client.Connect("localhost", form2?.Port ?? throw new Exception("Port имеет значение null"));

                var bytes = Encoding.UTF8.GetBytes(form2.NickName!);

                var stream = client.GetStream();

                await stream.WriteAsync(bytes);

                var local = client.Client.LocalEndPoint as IPEndPoint;

                AddTextToLog($"Вы запустились по адресу {"localhost:"}{local!.Port}");

                await Task.Run(() => ClientHandler(client));
            }
            catch (Exception ex)
            {
                AddTextToLog(ex.Message);
            }
        }

        private async Task ClientHandler(TcpClient client)
        {
            try
            {
                ClientIsOn = true;

                var stream = client.GetStream();

                while (true)
                {
                    if (!ClientIsOn)
                    {
                        stream.Close();
                    }

                    var buffer = new byte[1024];

                    await stream.ReadAsync(buffer);

                    var data = Encoding.UTF8
                        .GetString(buffer)
                        .TrimEnd('\0');

                    var firstFlag = data.Split(' ', 2)[0];

                    if (String.CompareOrdinal(firstFlag, "-m") == 0)
                    {
                        var localData = data.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);

                        AddTextToLog($"От {localData[1]}: \n {localData[2]}");
                    }

                    if (String.CompareOrdinal(firstFlag, "-l") == 0)
                    {
                        var localData = data.Split(' ', 2);

                        AddTextToLog("Список всех пользователей");
                        AddTextToLog(localData[1]);
                    }
                }
            }
            catch (IOException ex)
            {
                AddTextToLog(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox1.TabStop = false;
            textBox1.GotFocus += (s, e) => { this.ActiveControl = null; };
            textBox1.ScrollBars = ScrollBars.Vertical;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await SendMessage();
        }

        private async Task SendMessage()
        {
            var data = textBox2.Text.Split(' ', 3);

            var stream = client?.GetStream();

            if (String.CompareOrdinal(data[0], "-m") == 0
                && data.Length == 3)
            {
                var bytes = Encoding.UTF8.GetBytes(textBox2.Text);

                await stream!.WriteAsync(bytes);

                AddTextToLog(textBox2.Text);

                return;
            }

            if (String.CompareOrdinal(data[0], "-l") == 0
                && data.Length == 1)
            {
                var bytes = Encoding.UTF8.GetBytes(textBox2.Text);

                await stream!.WriteAsync(bytes);

                return;
            }

            AddTextToLog("Произошла ошибка при обработке команды.");

            return;
        }

        private void AddTextToLog(string text)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(() =>
                textBox1.Text += DateTime.Now + $" {text} " + Environment.NewLine);

                return;
            }

            textBox1.Text += DateTime.Now + $" {text} " + Environment.NewLine;
        }

        private void отключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseConnection();
        }


        private void CloseConnection()
        {
            try
            {
                client!.Close();
            }
            catch (Exception ex) when (ex is NullReferenceException)
            {
                AddTextToLog("Ошибка разрыва соединения. Соединение изначально не было установлено");
            }

            AddTextToLog("Вы отключились от сервера");
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private async void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                await SetConnection();
            }
            if (e.KeyCode == Keys.F2)
            {
                CloseConnection();
            }
            if (e.KeyCode == Keys.Enter)
            {
                await SendMessage();
            }
            if (e.KeyCode == Keys.Escape)
            {
                CloseConnection();
                Close();
            }
        }
    }
}
