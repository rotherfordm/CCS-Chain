using System.Security.Cryptography;
using System.Text;

namespace CCSblockchain.Models
{
    public static class HashHandler
    {
        public static string ComputeSha256Hash(string rawData)
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
    }
}