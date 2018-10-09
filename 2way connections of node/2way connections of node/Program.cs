using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using static System.Console;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;

namespace AeternumNode
{
    class Program
    {
        // Blockchain
        static List<Block> blockChain = new List<Block>();

        // Wallets
        static Dictionary<string, int> wallets = new Dictionary<string, int>();

        // Pending and Confirmed Transaction List
        static List<Transaction> pendingTransactions = new List<Transaction>();
        static List<Transaction> confirmedTransactions = new List<Transaction>();

        // Variables
        public static string serverIpAddress = "";
        public static int serverPort;

        // Server
        static TcpListener server;

        // List of Clients
        static List<TcpClient> listClients = new List<TcpClient>();

        // List of Server
        static List<TcpClient> listServers = new List<TcpClient>();

        // List of Threads;
        static List<Thread> clientThreads = new List<Thread>();

        static void Main(string[] args)
        {
            PopulateBlockChain();
            // Start Server
            ServerStart();
            

            Thread tA = new Thread(new ThreadStart(WaitClientConnection));
            //Thread tB = new Thread(new ThreadStart(AcceptDataFromClient));
            Thread tC = new Thread(new ThreadStart(SendDataToServers));
            //Thread tD = new Thread(new ThreadStart(CheckClients));
            tA.Start();
            //tB.Start();
            tC.Start();
            //tD.Start();

            FirstConnection();

        }

        static void PopulateBlockChain()
        {
            Block _block = new Block();
            blockChain.Add(_block.getGenesisBlock());
        }

        static void SendData(string x, TcpClient client)
        {
            string data = x;

            byte[] sendData = Encoding.ASCII.GetBytes(data);

            if (sendData.Length != 0)
            {
                NetworkStream stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);
            }
        }

        static void SendPersonalNodeData(TcpClient client)
        {
            //string filePath = Directory.GetCurrentDirectory() + @"\Data\My_Node_Data.json";
            //string fileData = "%NodeData%" + File.ReadAllText(filePath);
            string myNodeData = $"%NODEDATA%{serverIpAddress},{serverPort}";

            SendData(myNodeData, client);
        }


        static void ServerStart()
        {
            //string filePath = Directory.GetCurrentDirectory() + @"\Data\My_Node_Data.json";
            //string fileData = File.ReadAllText(filePath);

            //NodeData myData = JsonConvert.DeserializeObject<NodeData>(fileData);

            Write("Enter IP Address: ");
            serverIpAddress = ReadLine();
            Write("Enter Port: ");
            serverPort = int.Parse(ReadLine());


            try
            {
                server = new TcpListener(IPAddress.Parse(serverIpAddress), serverPort);
                server.Start();
                WriteLine($"{AppendTime()}Server {server.Server.LocalEndPoint} started!");
            }
            catch (Exception e)
            {
                WriteLine($"{AppendTime()}Error starting server: {e.ToString()}");
            }
        }

        static void FirstConnection()
        {
            WriteLine($"{AppendTime()}Trying to connect to Initial Peers...");
            string filePath = Directory.GetCurrentDirectory() + @"\Data\Initial_Peers.json";
            string fileData = File.ReadAllText(filePath);

            var listNodes = JsonConvert.DeserializeObject<List<NodeData>>(fileData);

            foreach (NodeData node in listNodes)
            {
                try
                {
                    if (node.port != serverPort.ToString())
                    {
                        TcpClient client = new TcpClient(node.ipAddress, int.Parse(node.port));
                        WriteLine($"{AppendTime()}Successfully connected to {node.ipAddress}:{node.port}");
                        listServers.Add(client);

                        SendPersonalNodeData(client);
                    }
                }
                catch (Exception e)
                {
                    WriteLine($"{AppendTime()}Can't connect to {node.ipAddress}:{node.port}");
                }
            }
        }

        static void WaitClientConnection()
        {          

            WriteLine($"{AppendTime()}Waiting for connections...");
            while (true)
            {
                // Accept connections
                TcpClient client = server.AcceptTcpClient();

                clientThreads.Add(new Thread(() => HandleClient(client)));
                clientThreads.Last().Start();

                WriteLine($"{AppendTime()}{client.Client.RemoteEndPoint} connected successfully!");

                // Add the client to the list of clients
                listClients.Add(client);
            }
        }

        static void HandleClient(TcpClient _client)
        {
            NetworkStream stream = _client.GetStream();

            while (true)
            {
                if (stream.DataAvailable)
                {
                    byte[] dataByte = new byte[_client.Available];

                    stream.Read(dataByte, 0, dataByte.Length);

                    string dataString = Encoding.ASCII.GetString(dataByte);

                    // Data
                    string _result = ProcessData(dataString, _client);

                    if (_result !=  "NAN")
                    {
                        byte[] sendData = Encoding.ASCII.GetBytes(_result);
                        stream.Write(sendData, 0, sendData.Length);
                    }
                }
            }
        }

        static string ProcessData(string x, TcpClient _client)
        {
            if (x.Contains("%NODEDATA%"))
            {
                ReciprocateConnection(x);
                return "NAN";
            }
            else if (x.Contains("%NEWWALLET%"))
            {
                NewWalletCreated(x);

                // BroadCast
                BroadCastToOtherNodes(x);
                return "Successfully Created a New Wallet!";
            }
            else if (x.Contains("%GETBALANCE%"))
            {
                string balance = GetWalletBalance(x).ToString();
                return balance;
            }
            else if (x.Contains("%GETMININGJOB%"))
            {
                WriteLine($"{AppendTime()}Miner Requested a Job!");

                WriteLine($"{AppendTime()}A Job was given to Miner!");

                return $"{blockChain.Count()},{blockChain.Last().hash},{GetHash(pendingTransactions)}";
            }
            else if (x.Contains("%SENDMINEDBLOCK%"))
            {
                if (CreateNewBlock(x))
                {
                    WriteLine($"{AppendTime()}New Block was found!");

                    // BroadCast
                    BroadCastToOtherNodes(x);
                    return "Sucessfully Created a new block!";
                }
                else
                    return "New Block Creation Failed!";
            }
            else if (x.Contains("%SENDCOINS%"))
            {
                if (SendCoins(x))
                {
                    WriteLine($"{AppendTime()}New Pending Transaction Received!");
                    // BroadCast
                    BroadCastToOtherNodes(x);
                    return "Transaction Pending!";
                }
                else
                {
                    return "Transaction Failed!";
                }
            }
            else if (x.Contains("%EXPLORERDETAILS%"))
            {
                return GetExplorerDetails();
            }
            else if (x.Contains("%SYNCBLOCKCHAIN%"))
            {
                return SyncNodes();
            }
            else
            {
                //WriteLine(x);
                //return "NAN";
                return "NAN";
            }

        }

        static string SyncNodes()
        {
            string data = "%SYNCBLOCKCHAIN%";

            foreach (Block block in blockChain)
            {
                data += $"{block.index},{block.previousHash},{block.timeStamp},{block.data},{block.hash},{block.difficulty},{block.nonce}%";
            }

            return data;
        }

        static string GetExplorerDetails()
        {
            string data = "";

            data += $"{blockChain.Count.ToString()}%";
            data += $"{blockChain.Last().hash}%";

            for (int i = 0; i < confirmedTransactions.Count; i++)
            {
                Transaction tx = confirmedTransactions[i];
                data += $"{tx.from},{tx.to},{tx.data},{i},confirmed%";
            }

            for (int i = 0; i < pendingTransactions.Count; i++)
            {
                Transaction tx = pendingTransactions[i];
                int id = confirmedTransactions.Count + 1;
                data += $"{tx.from},{tx.to},{tx.data},{id},pending%";
            }

            return data;
        }

        static bool CreateNewBlock(string x)
        {
            try
            {
                string[] details = x.Replace("%SENDMINEDBLOCK%", "").Split(',');
                int _index = blockChain.Count();
                string _prevhash = blockChain.Last().hash;
                long _timeStamp = long.Parse(details[0]);
                List<Transaction> _data = pendingTransactions;
                string _newhash = details[1];
                int _diifficulty = int.Parse(details[2]);
                int _nonce = int.Parse(details[3]);

                Block newBlock = new Block(_index, _prevhash, _timeStamp, _data, _newhash, _diifficulty, _nonce);

                blockChain.Add(newBlock);

                ExecutePendingTransactions();

                return true;
            }
            catch
            {
                return false;
            }

        }

        static void ExecutePendingTransactions()
        {
            foreach (Transaction tx in pendingTransactions)
            {
                SendConfirmedCoins(tx.from, tx.to, int.Parse(tx.data));
                confirmedTransactions.Add(tx);
            }

            pendingTransactions.Clear();
        }


        static string GetHash(List<Transaction> _pending)
        {
            using (SHA256 _hash = SHA256.Create())
            {
                string value = "";
                foreach (Transaction x in _pending)
                {
                    value += x.from + x.to + x.fee + x.dateCreated;
                }
                byte[] bytes = _hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                StringBuilder str = new StringBuilder();
                foreach (byte x in bytes)
                {
                    str.Append(x.ToString("x2"));
                }

                return str.ToString();
            }
        }

        static string AppendTime()
        {
            return $"{DateTime.Now.ToString("HH:mm:ss tt")} >> ";
        }

        static void ReciprocateConnection(string x)
        {
            string[] input = x.Replace("%NODEDATA%", "").Split(',');

            try
            {
                TcpClient client = new TcpClient(input[0], int.Parse(input[1]));
                
                WriteLine($"{AppendTime()}Successfullly connected to {client.Client.RemoteEndPoint}");

                listServers.Add(client);
            }
            catch
            {
                WriteLine($"{AppendTime()}Connection to {input[0]}:{input[1]} can't be established!");
            }

        }

        static void NewWalletCreated(string _wallet)
        {
            _wallet = _wallet.Replace("%NEWWALLET%", "");

            wallets.Add(_wallet, 10);
            WriteLine($"{AppendTime()}New Wallet Created..");
        }

        static string GetWalletBalance(string _wallet)
        {
            _wallet = _wallet.Replace("%GETBALANCE%", "");

            if (wallets.ContainsKey(_wallet))
                return wallets[_wallet].ToString();
            else
                return "Wallet Doesn't Exist!!";
        }

        static bool SendCoins(string x)
        {
            try
            {
                string[] details = x.Replace("%SENDCOINS%", "").Split(',');

                string _sender = details[0];
                string _recvr = details[1];
                string _amount = details[2];

                if (wallets.ContainsKey(_sender) && wallets.ContainsKey(_recvr) && wallets[_sender] >= int.Parse(_amount))
                {

                    Transaction tx = new Transaction();
                    tx.from = _sender;
                    tx.to = _recvr;
                    tx.data = _amount;

                    pendingTransactions.Add(tx);

                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
            
        }

        static void SendConfirmedCoins(string _sender, string _recvr, int _amount)
        {
            wallets[_sender] -= _amount;
            wallets[_recvr] += _amount;
        }

        static void SendDataToServers()
        {
            while (true)
            {
                string data = ReadLine();

                foreach (TcpClient client in listServers)
                {
                    // Start a network stream
                    NetworkStream stream = client.GetStream();

                    byte[] sendData = Encoding.ASCII.GetBytes(data);

                    if (sendData.Length != 0)
                    {                  
                        stream.Write(sendData, 0, sendData.Length);

                        //ADDED
                        Thread.Sleep(1000);
                        if (stream.DataAvailable)
                        {
                            byte[] dataByte = new byte[client.Available];

                            stream.Read(dataByte, 0, dataByte.Length);

                            string dataString = Encoding.ASCII.GetString(dataByte);

                            WriteLine(dataString);
                        }

                    }

                }
            }
        }

        static void BroadCastToOtherNodes(string data)
        {
            //while (true)
            //{
            //string data = ReadLine();

            foreach (TcpClient client in listServers)
            {
                // Start a network stream
                NetworkStream stream = client.GetStream();

                byte[] sendData = Encoding.ASCII.GetBytes(data);

                if (sendData.Length != 0)
                {
                    stream.Write(sendData, 0, sendData.Length);

                    //ADDED
                    Thread.Sleep(1000);
                    if (stream.DataAvailable)
                    {
                        byte[] dataByte = new byte[client.Available];

                        stream.Read(dataByte, 0, dataByte.Length);

                        string dataString = Encoding.ASCII.GetString(dataByte);

                        WriteLine(dataString);
                    }

                }

            }
            //}
        }

        private static void ProcessSync(string _data)
        {
            if (_data.Contains("%SYNCBLOCKCHAIN%"))
            {
                _data = _data.Replace("%SYNCBLOCKCHAIN%", "");
                SynBlockChain(_data);
            }
        }

        private static void SynBlockChain(string _data)
        {
            string[] data = _data.Split('%');
            
            for (int i = 1; i < data.Length; i++)
            {
                string[] procData = data[i].Split(',');

                blockChain.Add(new Block() {
                    index = int.Parse(procData[0]),
                    previousHash = procData[1],
                    timeStamp = long.Parse(procData[2]),
                    hash = procData[4],
                    difficulty = int.Parse(procData[5]),
                    nonce = int.Parse(procData[6])
                });
            }
           
        }

        public static void CheckClients()
        {
            while (true)
            {
                if (listClients.Count != 0)
                {
                    for (int i = 0; i < listClients.Count; i++)
                    {
                        TcpClient client = listClients[i];

                        if (client.Client.Poll(0, SelectMode.SelectRead))
                        {
                            try
                            {
                                byte[] buff = new byte[1];
                                client.Client.Receive(buff, SocketFlags.Peek);
                            }
                            catch
                            {
                                Console.WriteLine($"{AppendTime()}{0} disconnected!", client.Client.RemoteEndPoint);
                                listClients.Remove(client);
                            }
                        }
                    }
                }
            }
        }
    }
}
