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
        TcpClient server;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToNode();
            Generatewallet();
        }

        private void ConnectToNode()
        {
            server = new TcpClient("127.0.0.1", 3000);
        }

        private void Generatewallet()
        {
            string data = "%NEWWALLET%faucetWallet";

            SendToServer(data);  
        }

        private void btnGiveAeternum_Click(object sender, EventArgs e)
        {
            string data = $"%SENDCOINS%faucetWallet,{txtAddress.Text},1";

            SendToServer(data);
        }

        private void SendToServer(string _data)
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

                    lblResponse.Text = dataString;
                }

            }
        }
    }
}
