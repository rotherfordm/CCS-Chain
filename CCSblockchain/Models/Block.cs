using System;

namespace CCSblockchain.Models
{
    public class Block
    {
        public int Index { get; set; }
        public string PreviousHash { get; set; }
        public long TimeStamp { get; set; }
        public string Data { get; set; }
        public string Hash { get; set; }
        public int Difficulty { get; set; }
        public int Nonce { get; set; }

        public Block(int index, string prevHash, long timeStamp, string data, string hash, int difficulty, int nonce)
        {
            this.Index = index;
            this.PreviousHash = prevHash;
            this.TimeStamp = timeStamp;
            this.Data = data;
            this.Hash = hash;
            this.Difficulty = difficulty;
            this.Nonce = nonce;
        }
    }
}
