using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Aeternum_Explorer.Classes;

namespace Aeternum_Explorer
{
    public partial class frmMain : MetroForm
    {
        TcpClient server;

        List<Transaction> pendingTransactions = new List<Transaction>();
        List<Transaction> confirmedTransactions = new List<Transaction>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ConnectToNode();

            SendToServer("%EXPLORERDETAILS%");
        }

        private void ConnectToNode()
        {
            server = new TcpClient("127.0.0.1", 3000);
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

                    processData(dataString);
                }

            }
        }

        private void processData(string _data)
        {
            string[] newData = _data.Split('%');

            lblNumBlocks.Text = newData[0];
            lblPrevHash.Text = newData[1];

            // Clear the Lists
            pendingTransactions.Clear();
            confirmedTransactions.Clear();

            foreach(string str in newData)
            {
                if (str.Contains(','))
                {
                    if (str.Contains("confirmed"))
                    {
                        string[] data = str.Split(',');

                        confirmedTransactions.Add(new Transaction(data[0], data[1], data[2], data[3]));
                    }
                    else if (str.Contains("pending"))
                    {
                        string[] data = str.Split(',');

                        pendingTransactions.Add(new Transaction(data[0], data[1], data[2], data[3]));
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SendToServer("%EXPLORERDETAILS%");
        }

        private void cbTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTransactions.Text == "Confirmed Transactions")
                dtgTransactions.DataSource = confirmedTransactions;
            else
                dtgTransactions.DataSource = pendingTransactions;

            dtgTransactions.ClearSelection();
        }

        private void txtPendingSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtPendingSearch.Text;

            if (cbTransactions.Text == "Confirmed Transactions")
            {
                dtgTransactions.DataSource = confirmedTransactions.Where(x => x.address.Contains(filter)).ToList();
            }
            else
            {
                dtgTransactions.DataSource = pendingTransactions.Where(x => x.address.Contains(filter)).ToList();
            }
        }
    }
}
