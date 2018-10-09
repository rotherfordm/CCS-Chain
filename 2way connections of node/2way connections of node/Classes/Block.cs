using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeternumNode
{
    class Block
    {
        public int index { get; set; }
        public string previousHash { get; set; }
        public long timeStamp { get; set; }
        public List<Transaction> data { get; set; }
        public string hash { get; set; }
        public int difficulty { get; set; }
        public int nonce { get; set; }

        public Block() { }

        public Block(int _index, string _prevHash, long _timeStamp, List<Transaction> _data, string _hash, int _difficulty, int _nonce)
        {
            index = _index;
            previousHash = _prevHash;
            timeStamp = _timeStamp;
            data = _data;
            hash = _hash;
            difficulty = _difficulty;
            nonce = _nonce;
        }

        public Block getGenesisBlock()
        {
            Block genBlock = new Block();

            genBlock.index = 0;
            genBlock.previousHash = "0000000000000000000000000000000000000000000000000000000000000000";
            genBlock.timeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            genBlock.data = null;
            genBlock.hash = "2BFB4518733A85B42F684872D69C8623EB8EC5624B5291FA6F5F543B918921AE";
            genBlock.difficulty = 0;
            genBlock.nonce = 0;

            return genBlock;
        }
    }
}
