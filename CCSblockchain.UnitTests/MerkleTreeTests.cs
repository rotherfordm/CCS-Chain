using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCSblockchain.Models;
using System.Collections.Generic;

namespace CCSblockchain.UnitTests
{
    [TestClass]
    public class MerkleTreeTests
    {
        //format: method_scenario_expectedbehavior
            
        [TestMethod]
        public void Node_ManualSetCheck_Equal()
        {
            Node L1 = new Node();
            Node L2 = new Node();
            Node L1_L2 = new Node();

            Node L3 = new Node();
            Node L4 = new Node();
            Node L3_L4 = new Node();

            Node MerkleRoot = new Node();

            //Set Values
            L1.Value = HashHandler.ComputeSha256Hash("test1");
            L2.Value = HashHandler.ComputeSha256Hash("test2");
            string test = L1.Value + L1.Value;
            L1_L2.Value = HashHandler.ComputeSha256Hash(L1.Value + L1.Value);

            L3.Value = HashHandler.ComputeSha256Hash("test4");
            L4.Value = HashHandler.ComputeSha256Hash("test5");
            L3_L4.Value = HashHandler.ComputeSha256Hash(L3.Value + L4.Value);

            MerkleRoot.Value = HashHandler.ComputeSha256Hash(L1_L2.Value + L3_L4.Value);

            //Set Left & Right Nodes
            L1_L2.Left = L1;
            L1_L2.Right = L2;

            L3_L4.Left = L3;
            L3_L4.Right = L4;

            MerkleRoot.Left = L1_L2;
            MerkleRoot.Right = L3_L4;

            //Verify Values
            string ExpectedL1Value = "1b4f0e9851971998e732078544c96b36c3d01cedf7caa332359d6f1d83567014";
            string ExpectedL2Value = "60303ae22b998861bce3b28f33eec1be758a213c86c93c076dbe9f558c11c752";
            string ExpectedL1L2Value = "98866d999ba299056e0e79ba9137709a181fbccd230d6d3a6cc004da6e7bce83";

            string ExpectedL3Value = "a4e624d686e03ed2767c0abd85c14426b0b1157d2ce81d27bb4fe4f6f01d688a";
            string ExpectedL4Value = "a140c0c1eda2def2b830363ba362aa4d7d255c262960544821f556e16661b6ff";
            string ExpectedL3L4Value = "e6a5f59435aef23f707527906a695fc6efcf12eea365eec4020e763e94efe8e7";

            string ExpectedRootValue = "7f9878cb4a60aceec0bad755a979b015f415196c69be854629cb5db4e6661aae";

            Assert.AreEqual(ExpectedL1Value, L1.Value);
            Assert.AreEqual(ExpectedL2Value, L2.Value);
            Assert.AreEqual(ExpectedL1L2Value, L1_L2.Value);

            Assert.AreEqual(ExpectedL3Value, L3.Value);
            Assert.AreEqual(ExpectedL4Value, L4.Value);
            Assert.AreEqual(ExpectedL3L4Value, L3_L4.Value);

            Assert.AreEqual(ExpectedRootValue, MerkleRoot.Value);

            //Verify if the Object Reference is the same
            Assert.AreSame(L1, L1_L2.Left);
            Assert.AreSame(L2, L1_L2.Right);

            Assert.AreSame(L3, L3_L4.Left);
            Assert.AreSame(L4, L3_L4.Right);

            Assert.AreSame(L1_L2, MerkleRoot.Left);
            Assert.AreSame(L3_L4, MerkleRoot.Right);
        }

        [TestMethod]
        public void MerkleTree_SetLayersToMake_AreEqual()
        {
            //Given 10 Leaves Count how many Nodes to make per layer
            /// Ex. LayerCount = 10
            /// LayerCount / 2 = 5 Layer1 Nodes to Make
            /// 5 / 2 = 2.5 //Round off to 3 Layer2 Nodes to Make
            /// 3 / 2 = 1.5 //Round off to 2 Layer3 Nodes to Make
            /// 2 / 2 = 1 Layer4 Nodes to Make
            List<Node> Leaves = new List<Node>();

            for (int x = 0; x < 10; x++)
            {
                Leaves.Add(new Node(x.ToString()));
            }
           
            int ExpectedLayersToMake = 4;

            MerkleTree merkleTree = new MerkleTree(Leaves);
            merkleTree.SetLayersToMake();
            Assert.AreEqual(ExpectedLayersToMake, merkleTree.LayersToMake);
        }

        [TestMethod]
        public void MerkleTree_CountOfNodesToMake_AreEqual()
        {
            //Given 20 Leaves Count how many Nodes to make per layer
            List<Node> Leaves = new List<Node>();

            for (int x = 0; x < 20; x++)
            {
                Leaves.Add(new Node(x.ToString()));
            }

            MerkleTree merkleTree = new MerkleTree(Leaves);

            merkleTree.SetCountOfNodesToMake();
            Assert.AreEqual(10, merkleTree.CountOfNodesToMake);

            merkleTree.SetCountOfNodesToMake();
            Assert.AreEqual(5, merkleTree.CountOfNodesToMake);

            merkleTree.SetCountOfNodesToMake();
            Assert.AreEqual(3, merkleTree.CountOfNodesToMake);

            merkleTree.SetCountOfNodesToMake();
            Assert.AreEqual(2, merkleTree.CountOfNodesToMake);

            merkleTree.SetCountOfNodesToMake();
            Assert.AreEqual(1, merkleTree.CountOfNodesToMake);
        }

        [TestMethod]
        public void Test_Merkle_No_Digest()
        {

        }
    }
}
