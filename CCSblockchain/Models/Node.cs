using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSblockchain.Models
{
    class Node
    {
        public byte value { set; get; }
        public Node left { set; get; }
        public Node right { set; get; }
        public Node root { set; get; }


        public Node()
        {
            value = 0;
            left = null;
            right = null;
            root = null;
        }

        /*
         *  `Merkle Node constructor. Used for storing the left and right node pointersself.`

        Args:
            item (bytes): Bytes object that represents the hashed value that resides in the current node
            left (Node): Reference to the left subtree or a None value if current node is leaf
            right (Node): Reference to the right subtree or a None value if current node is leaf
         */
        public Node(byte item, Node left, Node right)
        {
            this.value = item;
            this.left = left;
            this.right = right;

        }
    }
}
