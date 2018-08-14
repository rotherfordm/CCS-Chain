using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace MerkleTree
{
    class MerkleTree
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

        public MerkleTree()
        {

        }

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

        public bool Find(Node node, byte value)
        {
            if (node.value == null)
            {
                return false;
            }
            if (node.value == value)
            {
                return true;
            }
            return false;
        }

        public List<Nodes> RequestProof(byte value)
        {

            return 
        }

    }
}
