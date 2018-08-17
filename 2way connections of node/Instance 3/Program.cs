using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using static System.Console;

namespace Instance_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient("192.168.254.119", 3000);
                WriteLine($"Successfully connected to IP = 192.168.254.119 PORT = 3000");



                NetworkStream stream = client.GetStream();

                string data = "TRIAL";

                byte[] dataByte = Encoding.ASCII.GetBytes(data);

                stream.Write(dataByte, 0, dataByte.Length);


                byte[] byteReceived = new byte[100];
                stream.Read(byteReceived, 0, byteReceived.Length);
                string recvdString = Encoding.ASCII.GetString(byteReceived);

                WriteLine(recvdString);

            }
            catch (Exception e)
            {
                WriteLine(e);
            }

           
            ReadKey();
        }
    }
}
