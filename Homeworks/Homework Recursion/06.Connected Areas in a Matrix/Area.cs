using System;

namespace _06.Connected_Areas_in_a_Matrix
{
    public class Area : IComparable<Area>
    {
        private int row;
        private int col;
        private int size;

        public Area(int row, int col)
        {
            this.row = row;
            this.col = col;
            this.size = 0;
        }

        public int Size => this.size;

        public void IncreaseSize()
        {
            this.size++;
        }

        public void Display(int num)
        {
            Console.WriteLine($"Area #{num} at ({this.row}, {this.col}), size: {this.size}");
        }

        public int CompareTo(Area other)
        {
            if (this.size > other.Size)
            {
                return -1;
            }

            if (this.size == other.Size)
            {
                return 0;
            }

            return 1;
        }
    }
}