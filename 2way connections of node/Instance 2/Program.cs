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
using _2way_connections_of_node;

namespace Instance2
{
    class Program
    {
        // Server
        static TcpListener server;

        // List of Clients
        static List<TcpClient> listClients = new List<TcpClient>();

        // List of Server
        static List<TcpClient> listServers = new List<TcpClient>();

        static void Main(string[] args)
        {
            // Start Server
            ServerStart();
            FirstConnection();

            Thread tA = new Thread(new ThreadStart(WaitClientConnection));
            Thread tB = new Thread(new ThreadStart(AcceptDataFromClient));
            Thread tC = new Thread(new ThreadStart(SendDataToServers));
            Thread tD = new Thread(new ThreadStart(CheckClients));
            tA.Start();
            tB.Start();
            tC.Start();
            tD.Start();

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
            string filePath = Directory.GetCurrentDirectory() + @"\Data\My_Node_Data.json";
            string fileData = "%NodeData%" + File.ReadAllText(filePath);

            SendData(fileData, client);
        }


        static void ServerStart()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\Data\My_Node_Data.json";
            string fileData = File.ReadAllText(filePath);

            NodeData myData = JsonConvert.DeserializeObject<NodeData>(fileData);

            try
            {
                server = new TcpListener(IPAddress.Parse(myData.ipAddress), int.Parse(myData.port));
                server.Start();
                WriteLine($"Server {server.Server.LocalEndPoint} started!");
            }
            catch (Exception e)
            {
                WriteLine($"Error starting server: {e.ToString()}");
            }
        }

        static void FirstConnection()
        {
            WriteLine("Trying to connect to Initial Peers...");
            string filePath = Directory.GetCurrentDirectory() + @"\Data\Initial_Peers.json";
            string fileData = File.ReadAllText(filePath);

            var listNodes = JsonConvert.DeserializeObject<List<NodeData>>(fileData);

            foreach (NodeData node in listNodes)
            {
                try
                {
                    TcpClient client = new TcpClient(node.ipAddress, int.Parse(node.port));
                    WriteLine($"Successfully connected to {node.ipAddress}:{node.port}");
                    listServers.Add(client);

                    SendPersonalNodeData(client);
                }
                catch (Exception)
                {
                    WriteLine($"Can't connect to {node.ipAddress}:{node.port}");
                }
            }
        }

        static void WaitClientConnection()
        {

            WriteLine("Waiting for connections...");
            while (true)
            {
                // Accept connections
                TcpClient client = server.AcceptTcpClient();
                WriteLine($"{client.Client.RemoteEndPoint} connected successfully!");

                // Add the client to the list of clients
                listClients.Add(client);
            }
        }

        static void AcceptDataFromClient()
        {
            while (true)
            {
                if (listClients.Count != 0)
                {
                    for (int i = 0; i < listClients.Count; i++)
                    {
                        try
                        {
                            TcpClient client = listClients[i];

                            NetworkStream stream = client.GetStream();

                            if (stream.DataAvailable)
                            {
                                byte[] dataByte = new byte[client.Available];

                                stream.Read(dataByte, 0, dataByte.Length);


                                //Sending automatic reply=====================
                                //string replystring = "Transaction Completed";
                                //byte[] reply = new byte[replystring.Length];

                                //reply = Encoding.ASCII.GetBytes(replystring);
                                //stream.Write(reply, 0, reply.Length);
                                //========================

                                string dataString = Encoding.ASCII.GetString(dataByte);
                                ProcessData(dataString);


                                WriteLine(dataString);

                                //WriteLine(StripHeaderFromData(dataString));
                                //SampleSend(/*ProcessReceivedData(*/dataString/*)*/);

                                //ProcessTransaction(StripHeaderFromData(dataString));

                            }
                        }
                        catch { }


                    }
                }
            }
        }

        static void ProcessData(string x)
        {

            if (x.Contains("NodeData"))
            {
                ReciprocateConnection(x);
            }
            else
            {

            }


        }

        static void ReciprocateConnection(string x)
        {
            string input = x.Replace("%NodeData%", "");

            NodeData nodeData = JsonConvert.DeserializeObject<NodeData>(input);

            try
            {
                TcpClient client = new TcpClient(nodeData.ipAddress, int.Parse(nodeData.port));

                WriteLine($"Successfullly connected to {client.Client.RemoteEndPoint}");

                listServers.Add(client);
            }
            catch
            {
                WriteLine($"Connection to {nodeData.ipAddress}:{nodeData.port} can't be established!");
            }

        }

        static string ParseDataToJsonString(string x)
        {
            string[] raw = x.Split();
            string input = "";
            bool checker = false;

            if (x.Contains('['))
            {
                // Reserverd for Json array
            }
            else if (x.Contains('%'))
            {
                foreach (string ch in raw)
                {
                    if (ch == "%")
                        checker = true;
                    else if (ch == "}")
                    {
                        input += ch;
                        checker = false;
                    }

                    if (checker)
                        input += ch;
                }
            }
            else
            {
                foreach (string ch in raw)
                {
                    if (ch == "{")
                        checker = true;
                    else if (ch == "}")
                    {
                        input += ch;
                        checker = false;
                    }

                    if (checker)
                        input += ch;
                }
            }

            return input;
        }

        static void ProcessTransaction(string x)
        {
            Transaction jsonDeserialized = JsonConvert.DeserializeObject<Transaction>(x);

            WriteLine(jsonDeserialized.data);

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
