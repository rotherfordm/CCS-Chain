using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.Signer.Crypto;
using System.Security.Cryptography;
using System.Threading;
using System.Net.Sockets;

namespace Wallet_DesuCoin
{
    public partial class frmMain : Form
    {
        string sessionKey = "";
        public static TcpClient server;

        private void ConnectToNode()
        {
            server = new TcpClient("127.0.0.1", 3000);
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

        private void SendToServerGetBalance(string _data)
        {
            NetworkStream stream = frmMain.server.GetStream();

            byte[] sendData = Encoding.ASCII.GetBytes($"%GETBALANCE%{_data}");

            if (sendData.Length != 0)
            {
                stream.Write(sendData, 0, sendData.Length);
                //ADDED
                Thread.Sleep(1000);
                if (stream.DataAvailable)
                {
                    byte[] dataByte = new byte[frmMain.server.Available];

                    stream.Read(dataByte, 0, dataByte.Length);

                    string dataString = Encoding.ASCII.GetString(dataByte);
                    LabelText = dataString;
                }
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        public string LabelText
        {
            get
            {
                return this.lblAccBalance.Text;
            }
            set
            {
                this.lblAccBalance.Text = value;
            }
        }


        public string LabelTextAddress
        {
            get
            {
                return this.lblAddressUsed.Text;
            }
            set
            {
                this.lblAddressUsed.Text = value;
            }
        }

        private void link_lbl_Create_Wallet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!panelMain.Controls.Contains(GenerateWallet.Instance))
            {
                panelMain.Controls.Add(GenerateWallet.Instance);
                GenerateWallet.Instance.Dock = DockStyle.Fill;
                GenerateWallet.Instance.BringToFront();
            }
            else
            {
                GenerateWallet.Instance.BringToFront();
            }
        }

        private void link_lbl_Open_Wallet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!panelMain.Controls.Contains(OpenWallet.Instance))
            {
                panelMain.Controls.Add(OpenWallet.Instance);
                OpenWallet.Instance.Dock = DockStyle.Fill;
                OpenWallet.Instance.BringToFront();
            }
            else
            {
                OpenWallet.Instance.BringToFront();
            }
        }

        private void link_lbl_send_trans_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!panelMain.Controls.Contains(TransactionWallet.Instance))
            {
                panelMain.Controls.Add(TransactionWallet.Instance);
                TransactionWallet.Instance.Dock = DockStyle.Fill;
                TransactionWallet.Instance.BringToFront();
            }
            else
            {
                TransactionWallet.Instance.BringToFront();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ConnectToNode();
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if(lblAddressUsed.Text != "No Address Loaded")
            {
                SendToServerGetBalance(lblAddressUsed.Text);
            }

            
        }
    }
}
