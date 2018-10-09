using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.Signer.Crypto;
using System.Numerics;
using System.Globalization;
using Wallet_DesuCoin;
using System.Threading;
using System.Net.Sockets;

namespace Wallet_DesuCoin
{
    public partial class OpenWallet : UserControl
    {
        private static OpenWallet _instance;
        TransactionWallet transWal;

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
                    MainForm.LabelText = dataString;
                }
            }
        }

        public frmMain MainForm
        {
            get
            {
                var parent = Parent;
                while (parent != null && (parent as frmMain) == null)
                {
                    parent = parent.Parent;
                }
                return parent as frmMain;
            }
        }

        public static OpenWallet Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new OpenWallet();
                return _instance;
            }
        }

        public OpenWallet()
        {
            InitializeComponent();
        }

        private void OpenWallet_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenWallet_Click(object sender, EventArgs e)
        {
            try
            {
                //var sprivKey = EthECKey.GenerateKey();
                //Console.Write("Private Key: ");
                var privKey = new EthECKey(txtOpenWalletPK.Text);
                byte[] pubKeyCompressed = new ECKey(privKey.GetPrivateKeyAsBytes(), true).GetPubKey(true);
                byte[] pubKeyShaRIPE = RipeMD160(pubKeyCompressed);
                //Console.WriteLine("Private key: {0}", privKey.GetPrivateKey().Substring(4));
                //Console.WriteLine("Public key: {0}", privKey.GetPubKey().ToHex().Substring(2));
                //Console.WriteLine("Public key (compressed): {0}", pubKeyCompressed.ToHex());
                //Console.WriteLine("Public key (RIPEMD160): {0}", pubKeyShaRIPE.ToHex());
                
                txtOpenWallet.Text = $"Private Key:\n{txtOpenWalletPK.Text}\nExtracted Public Key:\n{pubKeyCompressed.ToHex()} \nAddress:\n{pubKeyShaRIPE.ToHex()}";
                TransactionWallet.addressSession = pubKeyShaRIPE.ToHex();
                TransactionWallet.pubKeySession = pubKeyCompressed.ToHex();
                MainForm.LabelTextAddress = pubKeyShaRIPE.ToHex();
                SendToServerGetBalance(pubKeyShaRIPE.ToHex());
            }
            catch (Exception fuku)
            {
                txtOpenWallet.Text = fuku.ToString(); 
            }
           
        }

        public static byte[] HexToByte(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new Exception("Invalid Hex");
            }

            byte[] retArray = new byte[hexString.Length / 2];

            for (int i = 0; i < retArray.Length; i++)
            {
                retArray[i] = byte.Parse(hexString.Substring(i * 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);

            }
            return retArray;
        }

        public static string ByteToHex(byte[] pubKeySha)
        {
            byte[] data = pubKeySha;
            string hex = BitConverter.ToString(data);
            return hex;
        }


        public static byte[] RipeMD160(byte[] dataArray)
        {
            RIPEMD160Managed hashString = new RIPEMD160Managed();
            return hashString.ComputeHash(dataArray);
        }
    }
}
