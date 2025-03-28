using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lab3_NT
{
    public partial class Form1 : Form
    {
        private int _port = 12000;

        private TcpListener? server;

        private bool ServerOn = false;

        private const int MaxListeningClients = 10;

        [Obsolete]
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void серверToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        [Obsolete]
        private void запуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init_Logger();
        }

        [Obsolete]
        private void StartServer()
        {
            ServerOn = true; 

            server = new TcpListener(_port); //можно передать ip 

            server.Start(MaxListeningClients);

            AddTextToLog($"Сервер запущен на порте {_port}");

            var thread = new Thread(async () => await ProcessRequestAsync());

            thread.Name = "Server_Thread";

            thread.Start();
        }

        private void StopServer()
        {
            try
            {
                server!.Stop();
            }
            catch (Exception ex) when (ex is NullReferenceException)
            {
                AddTextToLog("Ошибка остановки сервера. Сервер изначально не был запущен");
            }
            
            ServerOn = false;
        }

        private async Task ProcessRequestAsync()
        {
            var userDictionary = new Dictionary<string, TcpClient>();

            try
            {
                while (true)
                {
                    var client = await server!.AcceptTcpClientAsync();

                    var stream = client.GetStream();

                    var buffer = new byte[1024];

                    await stream.ReadAsync(buffer);


                    var userName = Encoding.UTF8
                        .GetString(buffer)
                        .TrimEnd('\0');

                    userDictionary.Add(userName, client);

                    IPEndPoint? localEndPoint = client.Client.RemoteEndPoint as IPEndPoint;

                    AddTextToLog($"Пользователь {localEndPoint?.Address} {localEndPoint?.Port} {userName} подключился");

                    var task = Task.Run(() => ProcessUser(client, userDictionary));
                }
            }
            catch (Exception ex)
            {
                AddTextToLog(ex.Message);
            }
        }

        private async Task ProcessUser(TcpClient client,
            Dictionary<string, TcpClient> userDictionary)
        {
            var stream = client.GetStream();

            while (true)
            {
                if (!ServerOn)
                {
                    stream.Close();
                }

                var buffer = new byte[1024];

                var bytesCount = await stream.ReadAsync(buffer);

                if (bytesCount == 0)
                {
                    var users = userDictionary.Keys;

                    var key = users.First(x => userDictionary[x] == client);

                    userDictionary.Remove(key);

                    return;
                }

                var data = Encoding.UTF8
                    .GetString(buffer)
                    .TrimEnd('\0');

                var words = data.Split(' ', 3, StringSplitOptions.None);

                if (string.CompareOrdinal(words[0], "-m") == 0
                    && userDictionary.Keys.Contains(words[1]))
                {
                    var splitData = data.Split(' ', 3);

                    var users = userDictionary.Keys;

                    var senderName = users.First(x => userDictionary[x] == client);

                    var userStream = userDictionary[words[1]].GetStream();

                    var bytes = Encoding.UTF8.GetBytes(splitData[0] + " " + senderName + " " + splitData[2]);

                    await userStream.WriteAsync(bytes);
                }

                if (string.CompareOrdinal(words[0],"-l") == 0)
                {
                    var builder = new StringBuilder();
                    var users = userDictionary.Keys;
                    builder
                        .Append("-l")
                        .Append(" ")
                        .AppendLine($"Пользователей на сервере: {users.Count}");

                    foreach ( var user in users)
                    {
                        builder.AppendLine(user + '\n');
                    }

                    var bytes = Encoding.UTF8.GetBytes(builder.ToString());

                    await stream.WriteAsync(bytes);
                }
            }
        }

        private void Init_Logger()
        {
            ActiveControl = null;
            textBox1.Multiline = true;
            textBox1.Height = Height;
            textBox1.Width = Width;
            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = Color.White;
            textBox1.Font = new Font(textBox1.Font.FontFamily, 10, FontStyle.Bold);
            textBox1.ReadOnly = true;
            textBox1.MouseDown += (s, e) => ActiveControl = null;
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

        [Obsolete]
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                StartServer();
            }

            if (e.KeyCode == Keys.F2)
            {
                StopServer();
            }
            if (e.KeyCode == Keys.Escape)
            {
                StopServer();
                Close();
            }
        }
    }
}
