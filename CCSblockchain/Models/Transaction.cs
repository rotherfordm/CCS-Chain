namespace CCSblockchain.Models
{
    public class Transaction
    {

        public string AddressFrom { set; get; }
        public string AddressTo { set; get; }
        public uint Value { set; get; }
        public uint Fee { set; get; }
        public long DateCreated { set; get; }
        public string Data { set; get; } //optional
        public string SenderPublicKey { set; get; }

        public string TransactionDataHash { set; get; } //Set by  Hashing the values above (SHA256)

        public string SenderSignature { set; get; } //Sign by PrivateKey

        //Assigned when a new block is mined
        public bool TransferSuccessful { set; get; }
        public uint MinedInBlockIndex { set; get; }
        
    }
}