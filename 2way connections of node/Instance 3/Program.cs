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
                TcpClient client = new TcpClient("127.0.0.1", 3000);
                WriteLine($"Successfully connected to IP = 127.0.0.1 PORT = 3000");
            }
            catch (Exception e)
            {
                WriteLine(e);
            }

            ReadKey();
        }
    }
}
