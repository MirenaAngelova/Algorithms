using System.Collections.Generic;

namespace _08.Supplement_Graph_to_Make_It_Strongly_Connected
{
    public class Vertex
    {
        public Vertex(List<int> descendants, List<int> predecessors, int descendantsCount, int predecessorsCount)
        {
            this.Descendants = new List<int>(descendants);
            this.Predecessors = new List<int>(predecessors);
            this.DescendantsCount = descendantsCount;
            this.PredecessorsCount = predecessorsCount;
        }

        public int PredecessorsCount { get; set; }

        public int DescendantsCount { get; set; }

        public List<int> Predecessors { get; set; }

        public List<int> Descendants { get; set; }
    }
}