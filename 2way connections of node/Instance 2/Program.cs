using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using static System.Console;
using System.Threading;

namespace Instance_2
{
    class Program
    {
        // Server
        static TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 3001);

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
            tA.Start();
            tB.Start();
            tC.Start();

            //SampleSend();
        }

        static void SampleSend()
        {
            string data = "Success MotherFucker!";

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
                TcpClient client = new TcpClient("127.0.0.1", 3000);
                WriteLine($"Successfully connected to IP = 127.0.0.1 PORT = 3000");
                listServers.Add(client);
            }
            catch (Exception e)
            {
                WriteLine(e);
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
                for (int i = 0; i < listClients.Count; i++)
                {
                    TcpClient client = listClients[i];

                    NetworkStream stream = client.GetStream();

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
    }
}
