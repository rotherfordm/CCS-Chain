using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CCSblockchain.Models
{

    /* 
   * 
   * `The Merkle Tree is a special kind of Binary Tree that allows the user to prevent 
  information malleability and preserve integrity by using cryptographically secure
  hash functions. By providing leaves you create a root by concatination and hashingself.
  If the root is mutated it means that the data inside the leaves was changed. You can also
  derive cryptographic proofs that a piece of data is inside the tree`

  Comments:
     Complexities - This part can be improved by doing couple of modifications 

       */
    public class MerkleTree
    {
        public Node Root { set; get; }

        public MerkleTree(int[] iterable)
        {
            //do something
        }
        
        /// <summary>
        /// This method builds a Merkle Root from the passed in iterable.
        /// After the data is preprocessed, it calls the internal __build_root
        /// function to build the actual Merkle Root.
        /// </summary>
        /// <param name="nodes">iterable (list_iterator): The collection you want to create the root from</param>
        /// <returns>root - The newly built root of the Merkle Tree </returns>
        public Node BuildRoot(List<Node> nodes)
        {
            Node root = new Node();
            if (!(nodes == null))
            {
                return null;
            }
            return root;
        }

        public bool Contains(object value)
        {
            if (value == null) { return false; }

            return false;
        }


        /// <summary>
        /// The request_proof method provides to the 
        /// caller a merkle branch in order to prove
        /// that the integrity of the data is in tact.
        /// The caller can use the same digest and
        /// verify it himself
        /// </summary>
        /// <param name="value">The item you want proof for</param>
        /// <returns>List<></returns>
        public List<Nodes> RequestProof(byte[] value)
        {
             HashedValue = "";


        }

        private Node BuildRoot()
        {
           return new Node();
        }


        /// <summary>
        /// Recursive Method in finding the node by its value
        /// and searching to its left and right nodes.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <throw>On invalid value or one that is not
        /// contained in the tree</throw>
        private Node FindByValue(Node node, string value)
        {
            if (node == null)
            {
                throw new NullReferenceException();
            }

            if (node.Value == value)
            {
                return node;
            }
            else
            {
                if (FindByValue(node.Left, value).Value == byte.Parse(value))
                {
                    return node.Left;
                }

                if (FindByValue(node.Right, value).Value == byte.Parse(value))
                {
                    return node.Right;
                }
            }
            return null;
        }

        /// <summary>
        /// The contains method checks whether the item passed in as an
        /// argument is in the
        /// tree and returns True/False.
        /// It is used only externally.It's internal equivalent
        /// is __find
        /// </summary>
        /// <param name="value">The value you are searching for</param>
        /// <returns></returns>
        public bool Contains(object value)
        {
            if (value == null || Root == null)
            {
                return false;
            }
            // hashed_value = self.digest(value)
            string HashedValue = "";
            return FindByValue(Root, HashedValue);

        }

        private void Print(Node node, object indent) //TODO: check indent type
        {
            if (node == null)
            {
                throw new NullReferenceException();
            }

            Console.WriteLine("{0} ")

        }

    }
}
