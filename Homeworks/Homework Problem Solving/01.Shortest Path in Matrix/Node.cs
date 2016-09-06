using System;
using System.Collections.Generic;

namespace _01.Shortest_Path_in_Matrix
{
    public class Node : IComparable<Node>
    {
        public Node(int value, int distance)
        {
            this.Value = value;
            this.Distance = distance;
            this.Edges = new List<Edge>();
        }

        public List<Edge> Edges { get; private set; }

        public int Distance { get; set; }

        public int Value { get; set; }

        public int CompareTo(Node other)
        {
            var result = this.Distance.CompareTo(other.Distance);
            if (result == 0)
            {
                result = this.Value.CompareTo(other.Value);
            }

            return result;
        }
    }
}