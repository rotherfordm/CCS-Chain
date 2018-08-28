using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CCSblockchain.Models
{
    public class BlockHandler
    {
        List<Block> blocks = new List<Block>();
        static int difficulty = 4;

        public BlockHandler()
        {
            AddBlock(GetGenesisBlock());
            AddBlock(MineBlock("Sample Data"));

            string strJson = JsonConvert.SerializeObject(PreviousBlock(), Formatting.Indented);
            Console.WriteLine(strJson);
        }

        public Block GetGenesisBlock()
        {
            //blockhash = ccschain genesisblock 
            return new Block(0, null, 0, null,
                            "0000000000000000000000000000000000000000",
                            "f06a803d1ad2561c20465d9fd530e1d4d363fd9a20fec722909fae74ca2ea418",
                            DateTimeOffset.UtcNow.ToUnixTimeSeconds(), 0);

        }

        private Block PreviousBlock()
        {
            return blocks.Last();
        }

        public void AddBlock(Block newBlock)
        {
            if (IsValidNewBlock(newBlock, PreviousBlock()))
            {
                blocks.Add(newBlock);
            }
        }

        public static bool IsValidNewBlock(Block newBlock, Block prevBlock)
        {
            if (prevBlock.Index + 1 != newBlock.Index)
            {
                Console.WriteLine("invalid index");
                return false;
            }
            else if (prevBlock.BlockDataHash != newBlock.PreviousBlockHash)
            {
                Console.WriteLine("invalid previous hash");
                return false;
            }
            else if (HashHandler.CalculateHashForBlock(newBlock) != newBlock.BlockDataHash)
            {
                Console.WriteLine(newBlock.BlockDataHash + ' ' + HashHandler.CalculateHashForBlock(newBlock));
                Console.WriteLine("invalid hash: " + HashHandler.CalculateHashForBlock(newBlock) + ' ' + newBlock.BlockDataHash);
                return false;
            }
            return true;
        }

        private Block MineBlock(string data)
        {
            Block previousBlock = PreviousBlock();
            uint nextIndex = previousBlock.Index + 1;
            int nonce = 0;
            long nextTimestamp = DateTime.Now.Ticks / 1000;
            string nextHash = HashHandler.CalculateHash(nextIndex.ToString(), previousBlock.BlockDataHash, nextTimestamp.ToString(), data.ToString(), nonce);

            string zeros = new string('0', difficulty);
            while (nextHash.Substring(0, difficulty) != zeros)
            {
                nonce++;
                nextTimestamp = DateTime.Now.Ticks / 1000;
                nextHash = HashHandler.CalculateHash(nextIndex.ToString(), previousBlock.BlockDataHash, nextTimestamp.ToString(), data, nonce);
            }

            return new Block(nextIndex, 
                previousBlock.BlockDataHash, nextTimestamp, data, nextHash, difficulty, nonce);
        }
    }
}