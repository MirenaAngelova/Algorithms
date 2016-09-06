using System;
using System.Collections.Generic;

namespace _04.Fast_and_Furious
{
    public class Node : IComparable<Node>
    {
        public Node(string name, decimal travelTime)
        {
            this.Name = name;
            this.TravelTime = travelTime;
            this.Edges = new List<Edge>();
        }

        public decimal TravelTime { get; set; }

        public List<Edge> Edges { get; set; }

        public string Name { get; set; }

        public int CompareTo(Node other)
        {
            return this.TravelTime.CompareTo(other.TravelTime);
        }
    }
}