using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Net.Sockets;

namespace Aeternum_Faucet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient client;
        NetworkStream stream;

        string ip;
        int port;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public Form1(string ip, int port)
        {
            this.ip = ip;
            this.port = port;

            InitializeComponent();

            Form2 form2 = new Form2();

            client = new TcpClient(ip, port);
            stream = client.GetStream();
        }
    }
}
