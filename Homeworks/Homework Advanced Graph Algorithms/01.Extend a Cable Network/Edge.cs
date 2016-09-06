using System;

namespace _01.Extend_a_Cable_Network
{
    public class Edge : IComparable<Edge>
    {
        public Edge(int parent, int child, int weight)
        {
            this.Parent = parent;
            this.Child = child;
            this.Weight = weight;
        }

        public int Weight { get; set; }

        public int Child { get; set; }

        public int Parent { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }

        public override string ToString()
        {
            return $"{{{this.Parent}, {this.Child}}} -> {this.Weight}";
        }
    }
}