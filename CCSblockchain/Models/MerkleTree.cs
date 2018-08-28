using System;
using System.Collections.Generic;
using System.Linq;

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
        public Leaf Root { set; get; }
        public List<Leaf> Leaves { set; get; }
        public List<List<Leaf>> Layers { set; get; }
        public double CountOfNodesToMake { set; get; }

        public int LayersToMake { set; get; }

        public MerkleTree(List<Leaf> Leaves)
        {
            this.Leaves = Leaves;
            CountOfNodesToMake = Leaves.Count;
            LayersToMake = 1;
        }

        /// <summary>
        /// Sets the Count of Nodes to make on a Layer
        /// Rounds off if 0.5
        //Given 10 Leaves Count how many Nodes to make per layer
        /// Ex. LayerCount = 10// L1
        /// LayerCount / 2 = 5 // L2
        /// 5 / 2 = 2.5 // L3
        /// 3 / 2 = 1.5 // L4
        /// 2 / 2 = 1 //L5
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
            for(double i = Leaves.Count; i != 1;)
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

            List<Leaf> NodesToBeAddLayer = Leaves;
            Layers = new List<List<Leaf>>();
            Layers.Add(Leaves);

            for (int i = 1; LayersToMake > i; LayersToMake--)
            {
                SetCountOfNodesToMake();
                Layers.Add(BuildNodeLayer(CheckIfNodeCountIsOdd(NodesToBeAddLayer)));
                NodesToBeAddLayer = Layers.Last();
            }
            LayersToMake = Layers.Count; //actaully you can remove this, this is for module testing
        }

        /// <summary>
        /// Checks if the Node is odd and adds a copy of the Left Node of The Last Node to the List
        /// </summary>
        public List<Leaf> CheckIfNodeCountIsOdd(List<Leaf> nodesToBeLayered)
        {
            if (!(nodesToBeLayered.Count == 1))
            {
                if (nodesToBeLayered.Count % 2 != 0)
                {
                    nodesToBeLayered.Add(Leaves.Last());
                }
            }

            return nodesToBeLayered;
        }

        /// <summary>
        /// Builds a new Layer based on how many nodes to make
        /// </summary>
        public List<Leaf> BuildNodeLayer(List<Leaf> NodesToBeAddLayer)
        {
            List<Leaf> NewNodeLayer = new List<Leaf>();

            int j = 0;
            for (int i = 0; i < CountOfNodesToMake; i++)
            {
                Leaf node = new Leaf();
                node.Left = NodesToBeAddLayer[j];

                if (CountOfNodesToMake != 1)
                {
                    j++;
                }
                 
                node.Right = NodesToBeAddLayer[j];
                node.Value = HashHandler.ComputeSha256Hash(node.Left.Value + node.Right.Value);
                
                NewNodeLayer.Add(node);
                j++;
            }

            return NewNodeLayer;
        }
    }
}
