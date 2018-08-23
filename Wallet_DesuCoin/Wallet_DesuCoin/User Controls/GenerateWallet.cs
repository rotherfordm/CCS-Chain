using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
    public partial class GenerateWallet : UserControl
    {
        private static GenerateWallet _instance;
        TransactionWallet transWal;
        
        public static GenerateWallet Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GenerateWallet();
                return _instance;
            }
        }

            
        public GenerateWallet()
        {
            InitializeComponent();
        }

        private void btnGenWallet_Click(object sender, EventArgs e)
        {
            var sprivKey = EthECKey.GenerateKey();
            try
            {
                //var sprivKey = EthECKey.GenerateKey();
                //Console.Write("Private Key: ");
                //string privxKey = Console.ReadLine();
                var privKey = new EthECKey(sprivKey.GetPrivateKeyAsBytes().ToHex());
                byte[] pubKeyCompressed = new ECKey(privKey.GetPrivateKeyAsBytes(), true).GetPubKey(true);
                byte[] pubKeyShaRIPE = RipeMD160(pubKeyCompressed);
                //Console.WriteLine("Private key: {0}", privKey.GetPrivateKey().Substring(4));
                //Console.WriteLine("Public key: {0}", privKey.GetPubKey().ToHex().Substring(2));
                //Console.WriteLine("Public key (compressed): {0}", pubKeyCompressed.ToHex());
                //Console.WriteLine("Public key (RIPEMD160): {0}", pubKeyShaRIPE.ToHex());

                //txtGenWallet.Text = sprivKey.GetPrivateKeyAsBytes().ToHex();
                txtGenWallet.Text = $"Generated Private Key:\n{sprivKey.GetPrivateKeyAsBytes().ToHex()}\nExtracted Public Key:\n{pubKeyCompressed.ToHex()} \nAddress:\n{pubKeyShaRIPE.ToHex()}";

                TransactionWallet.addressSession = pubKeyShaRIPE.ToHex();
                TransactionWallet.pubKeySession = pubKeyCompressed.ToHex();
                TransactionWallet.privKeySession = sprivKey.GetPrivateKeyAsBytes().ToHex();
                //transWal.AddLog(sprivKey.GetPrivateKeyAsBytes().ToHex());
            }
            catch
            {
                txtGenWallet.Text = sprivKey.GetPrivateKeyAsBytes().ToHex();
            }
            
        }

        public static byte[] RipeMD160(byte[] dataArray)
        {
            RIPEMD160Managed hashString = new RIPEMD160Managed();
            return hashString.ComputeHash(dataArray);
        }
    }
}
