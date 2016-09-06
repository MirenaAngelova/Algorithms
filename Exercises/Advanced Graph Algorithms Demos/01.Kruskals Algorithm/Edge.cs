using System;

namespace _01.Kruskals_Algorithm
{
    public class Edge : IComparable<Edge>
    {
        public Edge(int startNode, int endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public int Weight { get; set; }

        public int EndNode { get; set; }

        public int StartNode { get; set; }

        public int CompareTo(Edge other)
        {
            var weightCompared = this.Weight.CompareTo(other.Weight);
            return weightCompared;
        }

        public override string ToString()
        {
            return $"{this.StartNode} {this.EndNode} -> {this.Weight}";
        }
    }
}