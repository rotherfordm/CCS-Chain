using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Sockets;

namespace Miner
{
    public partial class Form1 : Form
    {
        public static TcpClient server;

        private void ConnectToNode()
        {
            server = new TcpClient("127.0.0.1", 3000);
        }

        public static string SendToServerString(string _data)
        {
            NetworkStream stream = server.GetStream();

            byte[] sendData = Encoding.ASCII.GetBytes(_data);

            if (sendData.Length != 0)
            {
                stream.Write(sendData, 0, sendData.Length);
                //ADDED
                Thread.Sleep(1000);
                if (stream.DataAvailable)
                {
                    byte[] dataByte = new byte[server.Available];

                    stream.Read(dataByte, 0, dataByte.Length);

                    string dataString = Encoding.ASCII.GetString(dataByte);

                    return dataString;
                }
            }
            return "Error Occured";
        }

        public static void SendToServer(string _data)
        {
            NetworkStream stream = server.GetStream();

            byte[] sendData = Encoding.ASCII.GetBytes(_data);

            if (sendData.Length != 0)
            {
                stream.Write(sendData, 0, sendData.Length);
                //ADDED
                Thread.Sleep(1000);
                if (stream.DataAvailable)
                {
                    byte[] dataByte = new byte[server.Available];

                    stream.Read(dataByte, 0, dataByte.Length);

                    string dataString = Encoding.ASCII.GetString(dataByte);
                }
            }
        }

        public class Block
        {
            public int Index { get; set; }
            public string PreviousHash { get; set; }
            public long TimeStamp { get; set; }
            public string Data { get; set; }
            public string Hash { get; set; }
            public int Difficulty { get; set; }
            public int Nonce { get; set; }

            public Block(int index, string prevHash, long timeStamp, string data, string hash, int difficulty, int nonce)
            {
                this.Index = index;
                this.PreviousHash = prevHash;
                this.TimeStamp = timeStamp;
                this.Data = data;
                this.Hash = hash;
                this.Difficulty = difficulty;
                this.Nonce = nonce;
            }
        }

        List<Block> blocks = new List<Block>();
        static int difficulty = 5;
        TcpClient client;
        NetworkStream stream ;

        string ip;
        int port;

        public Form1()
        {
            InitializeComponent();
            GetGenesisBlock();

            blocks.Add(GetGenesisBlock());
            //textBox2.Text = JsonConvert.SerializeObject(blocks, Formatting.Indented);

            Form2 form2 = new Form2();

            //client = new TcpClient(form2.Ip(), form2.Port());
            //stream = client.GetStream();
        }

        public Form1(string ip, int port)
        {
            this.ip = ip;
            this.port = port;

            InitializeComponent();
            //GetGenesisBlock();

            //blocks.Add(GetGenesisBlock());

            //textBox2.Text = JsonConvert.SerializeObject(blocks, Formatting.Indented);

            Form2 form2 = new Form2();

            //client = new TcpClient(ip, port);
            //stream = client.GetStream();
        }

        public Block GetGenesisBlock()
        {
            return new Block(0, "0000000000000000000000000000000000000000000000000000000000000000", DateTimeOffset.UtcNow.ToUnixTimeSeconds(), null, "2BFB4518733A85B42F684872D69C8623EB8EC5624B5291FA6F5F543B918921AE", 0, 0);
        }

        private Block LastBlock()
        {
            return blocks.Last();
        }

        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string CalculateHashForBlock(Block block)
        {
            return CalculateHash(block.Index.ToString(), block.PreviousHash, block.TimeStamp.ToString(), block.Data, block.Nonce);
        }

        public static string CalculateHash(string index, string previousHash, string timeStamp, string data, int nonce)
        {
            return ComputeSha256Hash(index + previousHash + timeStamp + data + nonce);
        }

        public  void AddBlock(Block newBlock)
        {
            if (IsValidNewBlock(newBlock, LastBlock()))
            {
                blocks.Add(newBlock);
            }
        }

        public static bool IsValidNewBlock(Block newBlock, Block prevBlock)
        {
            if (prevBlock.Index + 1 != newBlock.Index)
            {
                MessageBox.Show("invalid index");
                return false;
            }
            else if (prevBlock.Hash != newBlock.PreviousHash)
            {
                MessageBox.Show("invalid previous hash");
                return false;
            }
            else if (CalculateHashForBlock(newBlock) != newBlock.Hash)
            {
                MessageBox.Show(newBlock.Hash + ' ' + CalculateHashForBlock(newBlock));
                MessageBox.Show("invalid hash: " + CalculateHashForBlock(newBlock) + ' ' + newBlock.Hash);
                return false;
            }
            return true;
        }

        private Block MineBlock(string data)
        {
            Block previousBlock = LastBlock();
            int nextIndex = previousBlock.Index + 1;
            int nonce = 0;
            long nextTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            string nextHash = CalculateHash(nextIndex.ToString(), previousBlock.Hash, nextTimestamp.ToString(), data.ToString(), nonce);

            string zeros = new string('0', difficulty);
            while (nextHash.Substring(0, difficulty) != zeros)
            {
                nonce++;
                nextTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                nextHash = CalculateHash(nextIndex.ToString(), previousBlock.Hash, nextTimestamp.ToString(), data, nonce);
            }

            MessageBox.Show("Mining Complete");
            string data_toNode = $"%GETMININGJOB%";
            SendToServerString(data_toNode);
            //string[] details = SendToServerString(data_toNode).Split(',');
            
            ////string _nextIndex = details[0];
            ////string _lastHash = details[1];
            ////string _dataHash = details[2];
            
            //MessageBox.Show($"next Index: {_nextIndex}\n last hash: {_lastHash}\n data hash: {_dataHash}");
            
            return new Block(nextIndex, previousBlock.Hash, nextTimestamp, data, nextHash, difficulty, nonce);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy && button1.Text == "Start")
            {
                backgroundWorker1.RunWorkerAsync();
                button1.Text = "Wait";
                label3.Text = "Mining...";
            }
        }

        private void Connect()
        {
            string data = JsonLastBlockToStr();

            byte[] dataByte = Encoding.ASCII.GetBytes(data);

            stream.Write(dataByte, 0, dataByte.Length);
        }

        private string JsonLastBlockToStr()
        {
            return JsonConvert.SerializeObject(LastBlock(), Formatting.Indented);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var reversedBlocks = blocks.OrderBy(x => x.Index).Reverse();
            //textBox2.Text = JsonConvert.SerializeObject(reversedBlocks, Formatting.Indented);
            label3.Text = string.Empty;
            button1.Text = "Start";
            var lastBlock = LastBlock();
            string strJson = JsonConvert.SerializeObject(lastBlock);
            

            string data_toNode = $"%SENDMINEDBLOCK%{LastBlock().TimeStamp.ToString()},{LastBlock().Hash.ToString()},{LastBlock().Difficulty},{LastBlock().Nonce}";
            SendToServer(data_toNode);

            //MessageBox.Show(LastBlock().Index.ToString() + LastBlock().TimeStamp.ToString());

            //Connect();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            blocks.Add(MineBlock((i += 5).ToString()));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToNode();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
