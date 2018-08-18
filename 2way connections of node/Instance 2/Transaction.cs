using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2way_connections_of_node
{
    class Transaction
    {
        public string from { get; set; }
        public string to { get; set; }
        public string value { get; set; }
        public string fee { get; set; }
        public string dateCreated { get; set; }
        public string data { get; set; }
        public string senderPubKey { get; set; }
        public string transactiondatahash { get; set; }
        public string senderSignature { get; set; }
        public string minedInBlockIndex { get; set; }
        public string transferSuccessfull { get; set; }

        public Transaction()
        {

        }

    }
}
