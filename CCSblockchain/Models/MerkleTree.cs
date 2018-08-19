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
        public int LayersToMake { set; get; }

        public MerkleTree(List<Node> Leaves)
        {
            this.Leaves = Leaves;
            CountOfNodesToMake = Leaves.Count;
            LayersToMake = 0;
        }

        /// <summary>
        /// Calls the static function of the HashHandler to Hash the Values of Left & Right side Of A Node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public string MakeNodeHash(Node node)
        {
            return HashHandler.ComputeSha256Hash(node.Left.Value.ToString() + node.Right.Value.ToString());
        }

        /// <summary>
        /// Sets the Count of Nodes to make on a Layer
        /// Rounds off if 0.5
        /// Ex. LayerCount = 10
        /// LayerCount / 2 = 5 Layer1 Nodes to Make
        /// 5 / 2 = 2.5 //Round off to 3 Layer2 Nodes to Make
        /// 3 / 2 = 1.5 //Round off to 2 Layer3 Nodes to Make
        /// 2 / 2 = 1 Layer4 Nodes to Make
        /// </summary>
        public void SetCountOfNodesToMake()
        {
            CountOfNodesToMake = Math.Round(CountOfNodesToMake / 2, 0, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Counts how many layers to make in the tree by dividing till you get one Root Node
        /// </summary>
        public void SetLayersToMake()
        {
            for (double i = Leaves.Count; i != 1;)
            {
                i = Math.Round(i / 2, 0, MidpointRounding.AwayFromZero);
                LayersToMake++;
            }
        }


        /// <summary>
        /// Builds a Tree and its nodes based on the number of LayersToMake
        /// </summary>
        public void BuildTree()
        {
            SetLayersToMake();

            for (int i = 0; i < LayersToMake; i++)
            {
                SetCountOfNodesToMake();
                CheckIfNodeCountIsOdd();
                BuildNodeLayer();
            }
        }

        /// <summary>
        /// Checks if the Node is odd and adds a copy of the Left Node of The Last Node to the List
        /// </summary>
        public void CheckIfNodeCountIsOdd()
        {
            if (CountOfNodesToMake % 2 != 0)
            {
                this.Leaves.Add(Leaves[-2]);
            }
        }

        /// <summary>
        /// Builds a new Layer based on how many nodes to make
        /// </summary>
        public void BuildNodeLayer()
        {
            for (int i = 0; i < CountOfNodesToMake; i++)
            {
                this.Leaves.Add(new Node(MakeNodeHash(Leaves[i]), Leaves[i].Left, Leaves[i].Right));
            }
        }
    }
}
