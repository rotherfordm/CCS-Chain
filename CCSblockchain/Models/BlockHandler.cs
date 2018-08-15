using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using Newtonsoft.Json;

namespace Blockchain
{
    public class BlockHandler
    {
        List<Block> blocks = new List<Block>();
        static int difficulty = 4;

        public BlockHandler()
        {
            AddBlock(GetGenesisBlock());
            AddBlock(MineBlock("Sample Data"));
            //Display the blocks in reverse to see the latest blocks
            //var reversedBlocks = blocks.OrderBy(x => x.Index).Reverse();
            //string strJson = JsonConvert.SerializeObject(reversedBlocks, Formatting.Indented);
            //Console.WriteLine(strJson);
        }

        public Block GetGenesisBlock()
        {
            return new Block(0, "0", 1465154705, "my genesis block!!", "816534932c2b7154836da6afc367695e6337db8a921823784c14378abed4f7d7", 0, 0);
        }

        private Block PreviousBlock()
        {
            return blocks.Last();
        }

        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string CalculateHashForBlock(Block block)
        {
            return CalculateHash(block.Index.ToString(), block.PreviousHash, block.TimeStamp.ToString(), block.Data, block.Nonce);
        }

        public static string CalculateHash(string index, string previousHash, string timeStamp, string data, int nonce)
        {
            return ComputeSha256Hash(index + previousHash + timeStamp + data + nonce);
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
            else if (prevBlock.Hash != newBlock.PreviousHash)
            {
                Console.WriteLine("invalid previous hash");
                return false;
            }
            else if (CalculateHashForBlock(newBlock) != newBlock.Hash)
            {
                Console.WriteLine(newBlock.Hash + ' ' + CalculateHashForBlock(newBlock));
                Console.WriteLine("invalid hash: " + CalculateHashForBlock(newBlock) + ' ' + newBlock.Hash);
                return false;
            }
            return true;
        }

        private Block MineBlock(string data)
        {
            Block previousBlock = PreviousBlock();
            int nextIndex = previousBlock.Index + 1;
            int nonce = 0;
            long nextTimestamp = DateTime.Now.Ticks / 1000;
            string nextHash = CalculateHash(nextIndex.ToString(), previousBlock.Hash, nextTimestamp.ToString(), data.ToString(), nonce);

            string zeros = new string('0', difficulty);
            while (nextHash.Substring(0, difficulty) != zeros)
            {
                nonce++;
                nextTimestamp = DateTime.Now.Ticks / 1000;
                nextHash = CalculateHash(nextIndex.ToString(), previousBlock.Hash, nextTimestamp.ToString(), data, nonce);
            }

            return new Block(nextIndex, previousBlock.Hash, nextTimestamp, data, nextHash, difficulty, nonce);
        }
    }
}