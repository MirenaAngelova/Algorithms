namespace _04.Fast_and_Furious
{
    public class Edge
    {
        public Edge(string parent, string child, decimal travelTime)
        {
            this.Parent = parent;
            this.Child = child;
            this.TravelTime = travelTime;
        }

        public decimal TravelTime { get; set; }

        public string Child { get; set; }

        public string Parent { get; set; }
    }
}