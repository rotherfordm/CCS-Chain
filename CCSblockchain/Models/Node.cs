namespace CCSblockchain.Models
{
    public class Leaf
    {
        public string Value { set; get; }
        public Leaf Left { set; get; }
        public Leaf Right { set; get; }
        public Leaf Parent { set; get; }
        

        public Leaf()
        {
            Value = null;
            Left = null;
            Right = null;
            Parent = null;
        }

        /// <summary>
        /// Merkle Node constructor. Used for storing the left and right node
        /// </summary>
        /// <param name="Value">Value (string): string object that represents the hashed value that resides in the current node</param>
        /// <param name="Left">left (Leaf): Reference to the left subtree or a None value if current node is leaf</param>
        /// <param name="Right">right (Leaf): Reference to the right subtree or a None value if current node is leaf</param>
        /// <param name="Parent">parent (Leaf): Reference to the parent of a leaf</param>
        public Leaf(string Value, Leaf Left = null, Leaf Right = null, Leaf Parent = null)
        {
            this.Value = Value;
            this.Left = Left;
            this.Right = Right;
            this.Parent = Parent;
        }
    }
}
