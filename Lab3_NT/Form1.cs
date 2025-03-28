using System.Net.Sockets;
using System.Text;

namespace Lab3_NT
{
    public partial class Form1 : Form
    {
        private int _port = 12000;

        private TcpListener server;

        private const int MaxListeningClients = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void âûõîäToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ñåðâåðToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        [Obsolete]
        private async void çàïóñòèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            server = new TcpListener(_port); //ìîæíî ïåðåäàòü ip 

            server.Start(MaxListeningClients);

            AddTextToLog($"Ñåðâåð çàïóùåí íà ïîðòå {_port}");

            var thread = new Thread(async () => await ServerStartAsync());

            thread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init_Logger();
        }

        private async Task ServerStartAsync()
        {
            var userDictionary = new Dictionary<string, TcpClient>();

            while (true)
            {
                var client = await server.AcceptTcpClientAsync();

                var stream = client.GetStream();

                var buffer = new byte[1024];
                
                await stream.ReadAsync(buffer);
                
                AddTextToLog($"Ïîëüçîâàòåëü {client.Client.AddressFamily.ToString()} ïîäêëþ÷èëñÿ");

                var userName = Encoding.UTF8
                    .GetString(buffer)
                    .TrimEnd('\0');

                userDictionary.Add(userName, client);

                _ = Task.Run(() => ProcessUser(client, userDictionary));
            }
        }

        private async Task ProcessUser(TcpClient client, 
            Dictionary<string, TcpClient> userDictionary)
        {
            while (true)
            {
                var stream = client.GetStream();

                var buffer = new byte[1024];
                
                var bytesCount = await stream.ReadAsync(buffer);

                if (bytesCount == 0)
                {
                    return;
                }

                var data = Encoding.UTF8
                    .GetString(buffer)
                    .TrimEnd('\0');

                var words = data.Split(' ', 3, StringSplitOptions.None);

                if (string.CompareOrdinal(words[0],"-m") == 0 
                    && userDictionary.Keys.Contains(words[1]))
                {
                    var bytes = Encoding.UTF8.GetBytes(words[2]);

                    var userStream = userDictionary[words[1]].GetStream();

                    await userStream.WriteAsync(bytes); 
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
            textBox1.Text += DateTime.Now + $" {text} " + Environment.NewLine;
        }
    }
}
