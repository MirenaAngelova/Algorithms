using System.Collections.Generic;

namespace _04.Recover_Message
{
    public class Vertex
    {
        public char Character { get; set; }

        public List<int> Children { get; set; }

        public int ParentsCount { get; set; }
    }
}