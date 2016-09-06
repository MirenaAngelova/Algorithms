namespace _07.Find_the_Bi_Connected_Components_in_a_Graph
{
    public class Edge
    {
        public Edge(int parent, int child)
        {
            this.Parent = parent;
            this.Child = child;
        }

        public int Child { get; set; }

        public int Parent { get; set; }
    }
}