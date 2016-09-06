using System;
using System.Collections.Generic;

namespace _03.Most_Reliable_Path
{
    public class Node : IComparable<Node>
    {
        public Node(int value, double reliability)
        {
            this.Value = value;
            this.Edges = new List<Edge>();
            this.Reliability = reliability;
        }

        public double Reliability { get; set; }

        public List<Edge> Edges { get; private set; }

        public int Value { get; set; }

        public int CompareTo(Node other)
        {
            return this.Reliability.CompareTo(other.Reliability);
        }
    }
}