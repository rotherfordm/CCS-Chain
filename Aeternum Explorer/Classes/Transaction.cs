using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Aeternum_Explorer.Classes
{
    class Transaction
    {
        public string address { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string value { get; set; }

        public Transaction()
        {

        }

        public Transaction(string _from, string _to, string _value, string _id)
        {
            address = sha256(_from + _to + _value + _id);
            from = _from;
            to = _to;
            value = _value;
        }

        static string sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = "";
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
