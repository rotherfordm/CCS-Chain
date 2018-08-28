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
            return new Block(0, "0", 1465154705, "my genesis block!!", "816534932c2b7154836da6afc367695e6337db8a921823784c14378abed4f7d7", 0, 0);
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

            return new Block(nextIndex, previousBlock.BlockDataHash, nextTimestamp, data, nextHash, difficulty, nonce);
        }
    }
}