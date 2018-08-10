using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain
{
    class BlockHandler
    {
        public Block getLatestBlock()
        {
            Block block = new Block();
            return block;
        }

        public string calculateHash()
        {
            string hash = "";

            return hash;
        }

        public Block generateNextBlock()
        {
            Block block = new Block();
            Block previousBlock = getLatestBlock();
            int nextIndex = previousBlock.index + 1;
            //TODO: some universal unix time converstion
            DateTime nextTimestamp = new DateTime();

            return block;
        }
    }
}
