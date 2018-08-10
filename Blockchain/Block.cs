using System;

namespace Blockchain
{
    public class Block
    {
        public int index { set; get; }
        public string previousHash { set; get; }
        public DateTime timeStamp { set; get; }
        public string data { set; get; }
        public string hash { set; get; }
        public string difficulty { set; get; }
        public string nonce { set; get; }

        public Block(int index, string previousHash, DateTime timeStamp, string data, string hash, string difficulty, string nonce)
        {
            this.index = index;
            this.previousHash = previousHash;
            this.timeStamp = timeStamp;
            this.data = data;
            this.hash = hash;
            this.difficulty = difficulty;
            this.nonce = nonce;     
        }


    }
}
