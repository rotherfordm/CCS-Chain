using System;
using CCSblockchain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCSblockchain.UnitTests
{
    [TestClass]
    public class HashHandlerTests
    {
        [TestMethod]
        public void ComputeSha256Hash_AreEqual_True()
        {
            string Input = "cryptographic hash functions";
            string ExpectedOutput = "b8921348ed613a01d5ace11c754f459214b6f81d5e7937354c561eb25fb9e7ce";
            string Output = HashHandler.ComputeSha256Hash(Input);
            string ErrorFeedback = $"Incorrect Values: Expected - {ExpectedOutput}, Received - {Output} ";
            Assert.AreEqual(ExpectedOutput, Output, ErrorFeedback);
        }

        [TestMethod]
        public void CalculateHash_AreEqual_True()
        {
            uint index = 2;
            string previousHash = "b8921348ed613a01d5ace11c754f459214b6f81d5e7937354c561eb25fb9e7ce";
            string timeStamp = "1512845815";
            string data = "Test Block";
            uint nonce = 0;
            string ExpectedOutput = "1d2fbc9e5b458798d667b24386f6a76f0bd24268e184e209bf4cc51d6168b24e";
            string Output = HashHandler.CalculateHash(index.ToString(), previousHash, timeStamp, data, nonce);
            string ErrorFeedback = $"Incorrect Values: Expected - {ExpectedOutput}, Received - {Output} ";
            Assert.AreEqual(ExpectedOutput, Output, ErrorFeedback);
        }

        [TestMethod]
        public void CalculateHashForBlock_AreEqual_True()
        {
            uint index = 2;
            string previousHash = "b8921348ed613a01d5ace11c754f459214b6f81d5e7937354c561eb25fb9e7ce";
            long timeStamp = 1512845815;
            string data = "Test Block";
            string hash = "d1436fa411c6072a89ba0de742c6703a428b7477105decf544254fee7bb23282";
            int difficulty = 0;
            int nonce = 0;

            Block block = new Block(index, previousHash, timeStamp, data, hash, difficulty, nonce);

            string ExpectedOutput = "1d2fbc9e5b458798d667b24386f6a76f0bd24268e184e209bf4cc51d6168b24e";
            string Output = HashHandler.CalculateHashForBlock(block);

            string ErrorFeedback = $"Incorrect Values: Expected - {ExpectedOutput}, Received - {Output} ";
            Assert.AreEqual(ExpectedOutput, Output, ErrorFeedback);
        }

    }
}
