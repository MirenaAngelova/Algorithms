namespace _06.Maximum_Tasks_Assignment
{
    public class Edge
    {
        public Edge(string parent, string child)
        {
            this.Parent = parent;
            this.Child = child;
        }

        public string Child { get; set; }

        public string Parent { get; set; }

        public bool Used { get; set; }
    }
}