namespace CCSblockchain.Models
{
    public class Node
    {
        public string Value { set; get; }
        public Node Left { set; get; }
        public Node Right { set; get; }
        public Node Root { set; get; }

        public Node()
        {
            Value = null;
            Left = null;
            Right = null;
            Root = null;
        }

        /*
         *  `Merkle Node constructor. Used for storing the left and right node pointersself.`

        Args:
            item (string): string object that represents the hashed value that resides in the current node
            left (Node): Reference to the left subtree or a None value if current node is leaf
            right (Node): Reference to the right subtree or a None value if current node is leaf
         */
        public Node(string item, Node left = null, Node right = null)
        {
            this.Value = item;
            this.Left = left;
            this.Right = right;
        }
    }
}
