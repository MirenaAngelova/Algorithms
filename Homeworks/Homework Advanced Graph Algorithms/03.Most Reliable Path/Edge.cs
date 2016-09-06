using System;

namespace _03.Most_Reliable_Path
{
    public class Edge : IComparable<Edge>
    {
        public Edge(int parent, int child, double weight)
        {
            this.Parent = parent;
            this.Child = child;
            this.Weight = weight;
        }

        public double Weight { get; set; }

        public int Child { get; set; }

        public int Parent { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }

        public override string ToString()
        {
            return $"({this.Parent} {this.Child}) -> {this.Weight}";
        }
    }
}