using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.Signer.Crypto;
using System.Security.Cryptography;

namespace Wallet_DesuCoin
{
    public partial class TransactionWallet : UserControl
    {
        private static TransactionWallet _instance;

        public static string privKeySession;
        public static string addressSession;
        public static string pubKeySession;

        string Sender, Receiver, value, fee, dateCreated, data, senderPubKey, transactionDataHash, senderSignature, minedInBlockIndex, TransferSuccess, JsonTrans;

        public static TransactionWallet Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TransactionWallet();
                return _instance;

            }
        }

        public void AddLog(string s)
        {
            this.txtTransSender.Text = s;
        }


        public TransactionWallet()
        {
            InitializeComponent();
        }


        private void btnSignTransact_Click(object sender, EventArgs e)
        {
            Sender = txtTransSender.Text;
            Receiver = txtTransRecip.Text;
            value = txtTransValue.Text;
            fee = "100";
            //dateCreated = "1534495254";
            dateCreated = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            data = "";
            senderPubKey = pubKeySession;
            minedInBlockIndex = "index";
            TransferSuccess = "success?";
            var SignPrivKey = new EthECKey(privKeySession);
            string msg = Sender + Receiver + value + fee + dateCreated + data + senderPubKey  + minedInBlockIndex;
            //string msg = Sender + Receiver + value + fee + dateCreated + data + senderPubKey + transactionDataHash + minedInBlockIndex;
            //string msg = "Sean";
            byte[] msgBytes = Encoding.UTF8.GetBytes(msg);
            byte[] msgHash = new Sha3Keccack().CalculateHash(msgBytes);
            var signature = SignPrivKey.SignAndCalculateV(msgHash);
            transactionDataHash = sha256(msg);


            var walletJsonData = new { From = Sender, To = Receiver, value = value, fee = fee, dateCreated = dateCreated, data = data, senderPubKey= senderPubKey, transactionDataHash = transactionDataHash, senderSignature = signature.V[0] - 27 + signature.R.ToHex() + signature.S.ToHex(), minedInBlockIndex = minedInBlockIndex, TransferSuccess = TransferSuccess};
            JsonTrans = JsonConvert.SerializeObject(walletJsonData, Formatting.Indented);
            txtTransData.Text = JsonTrans;
        }

        private void TransactionWallet_Load(object sender, EventArgs e)
        {
            txtTransSender.Text = addressSession;
        }

        static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

    }
}
