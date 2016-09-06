using System;

namespace _05.Dijkstra_With_Priority_Queue
{
    public class Node : IComparable<Node>
    {
        public Node(int index, int distance = int.MaxValue)
        {
            this.Index = index;
            this.DistanceFromStart = distance;
        }

        public int DistanceFromStart { get; set; }

        public int Index { get; set; }

        public int CompareTo(Node other)
        {
            return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
        }

        public override string ToString()
        {
            return this.Index.ToString();
        }
    }
}