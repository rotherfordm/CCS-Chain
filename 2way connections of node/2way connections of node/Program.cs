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

namespace _2way_connections_of_node
{
    class Program
    {
        // Server
        static TcpListener server = new TcpListener(IPAddress.Parse("192.168.254.119"), 3000);

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

        static void SampleSend(string x)
        {
            string data = x;

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

        static void ServerStart()
        {
            try
            {
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
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 3001);
                WriteLine($"Successfully connected to IP = 127.0.0.1 PORT = 3001");
                listServers.Add(client);
            }
            catch (Exception e)
            {
                //WriteLine(e);
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


                                //========================
                                string replystring = "Transaction Completed";
                                byte[] reply = new byte[replystring.Length];

                                reply = Encoding.ASCII.GetBytes(replystring);
                                stream.Write(reply, 0, reply.Length);
                                //========================

                                string dataString = Encoding.ASCII.GetString(dataByte);

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

        static string StripHeaderFromData(string x)
        {
            string[] raw = x.Split();
            string input = "";
            bool checker = false;

            foreach(string ch in raw)
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
