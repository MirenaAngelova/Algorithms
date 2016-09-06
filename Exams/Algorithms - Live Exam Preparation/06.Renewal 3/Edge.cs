using System;

namespace _06.Renewal_3
{
    public class Edge : IComparable<Edge>
    {
        public Edge(int source, int destination, int cost, bool exists)
        {
            this.Source = source;
            this.Destination = destination;
            this.Cost = cost;
            this.Exists = exists;
        }

        public bool Exists { get; set; }

        public int Cost { get; set; }

        public int Destination { get; set; }

        public int Source { get; set; }

        public int CompareTo(Edge other)
        {
            if (this.Exists && !other.Exists)
            {
                return -1;
            }
            else if (!this.Exists && other.Exists)
            {
                return 1;
            }

            if (this.Exists)
            {
                return other.Cost - this.Cost;
            }
            else
            {
                return this.Cost - other.Cost;
            }
        }

        public override string ToString()
        {
            int first;
            int second;
            if (this.Source > this.Destination)
            {
                first = this.Source;
                second = this.Destination;
            }
            else
            {
                first = this.Destination;
                second = this.Source;
            }

            return first.ToString() + second;
        }
    }
}