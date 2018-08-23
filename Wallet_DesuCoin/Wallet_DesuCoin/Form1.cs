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

namespace Wallet_DesuCoin
{
    public partial class frmMain : Form
    {
        string sessionKey = "";

        public frmMain()
        {
            InitializeComponent();
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
    }
}
