using System;
using System.Runtime.CompilerServices;

namespace _06.Renewal_2
{
    public class Edge : IComparable<Edge>
    {
        public Edge(int parent, int child, int cost)
        {
            this.Parent = parent;
            this.Child = child;
            this.Cost = cost;
        }

        public int Cost { get; set; }

        public int Child { get; set; }

        public int Parent { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Cost - other.Cost;
        }
    }
}