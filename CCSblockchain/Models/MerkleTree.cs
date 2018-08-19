using System;
using System.Collections.Generic;

namespace CCSblockchain.Models
{
    /// <summary>
    /// The Merkle Tree is a special kind of Binary Tree that allows the user to prevent 
    /// information malleability and preserve integrity by using cryptographically secure
    /// hash functions.By providing leaves you create a root by concatination and hashingself.
    /// If the root is mutated it means that the data inside the leaves was changed.You can also
    /// derive cryptographic proofs that a piece of data is inside the tree
    /// </summary>
    public class MerkleTree
    {
        public Node Root { set; get; }
        public List<Node> Tree { set; get; }
        public List<Node> Leaves { set; get; }
        public double CountOfNodesToMake { set; get; }

        public MerkleTree(List<Node> Leaves)
        {
            this.Leaves = Leaves;
            this.CountOfNodesToMake = Leaves.Count;
        }

        public string GetRootHash(string left, string right)
        {
            return HashHandler.ComputeSha256Hash(left + right);
        }

        public string MakeNodeHash(Node node)
        {
            return HashHandler.ComputeSha256Hash(node.Left.Value.ToString() + node.Right.Value.ToString());
        }

        public void SetRootHash()
        {
            this.Root.Value = MakeNodeHash(this.Root);
        }

        public void BuildTree()
        {
            this.CountOfNodesToMake = Math.Round( CountOfNodesToMake / 2, 0, MidpointRounding.AwayFromZero);
        }
    }
}
