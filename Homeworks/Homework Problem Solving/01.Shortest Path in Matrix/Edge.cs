namespace _01.Shortest_Path_in_Matrix
{
    public class Edge
    {
        public Edge(int parent, int child, int distance)
        {
            this.Parent = parent;
            this.Child = child;
            this.Distance = distance;
        }

        public int Distance { get; set; }

        public int Child { get; set; }

        public int Parent { get; set; }
    }
}