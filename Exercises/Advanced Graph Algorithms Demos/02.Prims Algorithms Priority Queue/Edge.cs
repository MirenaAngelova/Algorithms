using System;

namespace _02.Prims_Algorithms_Priority_Queue
{
    public class Edge : IComparable<Edge>
    {
        public Edge(string startNode, string endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public int Weight { get; set; }

        public string EndNode { get; set; }

        public string StartNode { get; set; }

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