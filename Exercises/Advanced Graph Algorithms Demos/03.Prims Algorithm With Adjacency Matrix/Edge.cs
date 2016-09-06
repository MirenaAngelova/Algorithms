using System.Runtime.CompilerServices;

namespace _03.Prims_Algorithm_With_Adjacency_Matrix
{
    public class Edge
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

        public override string ToString()
        {
            return $"({this.StartNode} {this.EndNode} -> {this.Weight})";
        }
    }
}