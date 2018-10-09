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

namespace AeternumNode
{
    class Program
    {
        // Blockchain
        static List<Block> blockChain = new List<Block>();

        // Wallets
        static Dictionary<string, int> wallets = new Dictionary<string, int>();

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
                    ProcessData(dataString);
                }
            }
        }

        static void ProcessData(string x)
        {

            if (x.Contains("%NODEDATA%"))
            {
                ReciprocateConnection(x);
            }
            else if (x.Contains("%NEWWALLET%"))
            {
                NewWalletCreated(x);
            }
            else if (x.Contains("%GETBALANCE%"))
            {

            }
            else
            {
                WriteLine(x);
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
        }

        static int GetWalletBalance(string _wallet)
        {
            _wallet = _wallet.Replace("%GETBALANCE%", "");

            return wallets[_wallet];
        }

        static void SendDataToServers()
        {
            while (true)
            {
                string data = ReadLine();

                foreach (TcpClient client in listServers)
                {
                    byte[] sendData = Encoding.ASCII.GetBytes(data);

                    if (sendData.Length != 0)
                    {
                        // Start a network stream
                        NetworkStream stream = client.GetStream();
                        stream.Write(sendData, 0, sendData.Length);
                    }
                }
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
                                Console.WriteLine("{0} disconnected!", client.Client.RemoteEndPoint);
                                listClients.Remove(client);
                            }
                        }
                    }
                }
            }
        }
    }
}
