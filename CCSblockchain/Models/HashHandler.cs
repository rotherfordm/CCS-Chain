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
            //Concat all of the hashtransactions
            string transactionHash = "";

            foreach (Transaction transaction in block.Transactions)
            {
                transactionHash = transaction.TransactionDataHash + transaction;
            }

            return ComputeSha256Hash(block.Index + transactionHash + block.Difficulty + block.PreviousBlockHash + block.MinedBy);
        }

        public static string CalculateHashForTransaction(Transaction transaction)
        {
            return ComputeSha256Hash(transaction.AddressFrom +
                                     transaction.AddressTo +
                                     transaction.Value +
                                     transaction.Fee +
                                     transaction.DateCreated + 
                                     transaction.Data + 
                                     transaction.SenderPublicKey);
        }

    }
}