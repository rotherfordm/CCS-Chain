using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCSblockchain.Models;
using System.Text;

namespace CCSblockchain.UnitTests
{
    [TestClass]
    public class MerkleTreeTests
    {
        //format: method_scenario_expectedbehavior

        [TestMethod]
        public void test()
        {
            //arrange

            //act

            //assert
        }



        [TestMethod]
        public void Node_Check_NotEmpty()
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            Node MerkleRoot = new Node();

            Node L1 = new Node();
            Node L2 = new Node();
            Node L1_L2 = new Node();

            Node L3 = new Node();
            Node L4 = new Node();
            Node L3_L4 = new Node();

            


            //act

            //assert
        }


        [TestMethod]
        public void Test_Merkle_No_Digest()
        {
            int[] treeEvenData = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] treeOddData = new int[] { 1, 2, 3, 4, 5};

            MerkleTree treeEven = new MerkleTree(treeEvenData);
            MerkleTree treeOdd = new MerkleTree(treeOddData);

            string EvenErrorFeedback = $"Incorrect Root: Expected - {"12345656"}, Received - {treeEven.Root.Value} ";
            string OddErrorFeedback = $"Incorrect Root: Expected - {"12345555"}, Received - {treeOdd.Root.Value} ";

            Assert.AreEqual(treeEven.Root.Value, "12345656", EvenErrorFeedback);
            Assert.AreEqual(treeEven.Root.Value, "12345555", OddErrorFeedback);
        }

        public void Test_Merkle_With_Cryptographic_Digest()
        {
            string[] EvenSequence = { "tx1", "tx2", "tx3", "tx4" };
            int[] OddSequence = { 1, 2, 3, 8, 9, 9, 9, 9 };

            ///TODO Add hash refer to python code
            
            MerkleTree TreeEven = MerkleTree(EvenSequence, );
            
        }


    }
}
