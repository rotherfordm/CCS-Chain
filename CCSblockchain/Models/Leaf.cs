namespace CCSblockchain.Models
{
    public class Leaf
    {
        public string Value { set; get; }
        public Leaf Left { set; get; }
        public Leaf Right { set; get; }


        public Leaf()
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
        public Leaf(string Value, Leaf Left = null, Leaf Right = null)
        {
            this.Value = Value;
            this.Left = Left;
            this.Right = Right;
        }
    }
}
