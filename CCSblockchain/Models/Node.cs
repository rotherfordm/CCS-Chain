namespace CCSblockchain.Models
{
    public class Node
    {
        public string Value { set; get; }
        public Node Left { set; get; }
        public Node Right { set; get; }

        public Node()
        {
            Value = null;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Merkle Node constructor. Used for storing the left and right node
        /// </summary>
        /// <param name="Value">Value (string): string object that represents the hashed value that resides in the current node</param>
        /// <param name="Left">left (Node): Reference to the left subtree or a None value if current node is leaf</param>
        /// <param name="Right">right (Node): Reference to the right subtree or a None value if current node is leaf</param>
        public Node(string Value, Node Left = null, Node Right = null)
        {
            this.Value = Value;
            this.Left = Left;
            this.Right = Right;
        }
    }
}
