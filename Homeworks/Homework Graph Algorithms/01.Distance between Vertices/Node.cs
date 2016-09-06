using System.Collections.Generic;

namespace _01.Distance_between_Vertices
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Children= new List<Node>();
            this.Distance = -1;
        }

        public int Distance { get; set; }

        public List<Node> Children { get; set; }

        public int Value { get; set; }
    }
}