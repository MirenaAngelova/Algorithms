using System;

namespace _06.Connected_Areas_in_Matrix_2
{
    public class Area : IComparable<Area>
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Size { get; set; }

        public int CompareTo(Area other)
        {
            int maxSize = this.Size.CompareTo(other.Size);
            return maxSize;
        }
    }
}