using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain
{
    public class BlockHandler
    {
        int difficulty = 4;

        public Block getLatestBlock()
        {
            Block block;
            return block;
        }

        public string calculateHash(int nextIndex, string previousBlockHash, DateTime nextTimestamp, string blockData)
        {
            //TODO: Implement SHA256 hashing use C# hash
            string hash = "";

            return hash;
        }

        public Block generateNextBlock(string blockData)
        {
            Block previousBlock = getLatestBlock();
            int nextIndex = previousBlock.index + 1;
            //TODO: some universal unix time converstion
            DateTime nextTimestamp = new DateTime();
            string nextHash = calculateHash(nextIndex, previousBlock.hash, nextTimestamp, blockData);
            return new Block(nextIndex, previousBlock.hash, nextTimestamp, blockData, nextHash);
        }

        public Block getGenesisBlock()
        {
            return new Block(0, "0", DateTime.Now, "my genesis block!!", 
                "816534932c2b7154836da6afc367695e6337db8a921823784c14378abed4f7d7", 0, 0);
        }
    }
}
