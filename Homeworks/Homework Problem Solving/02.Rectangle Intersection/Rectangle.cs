using System;

namespace _02.Rectangle_Intersection
{
    public class Rectangle : IComparable<Rectangle>
    {
        public Rectangle(int minX, int maxX, int minY, int maxY)
        {
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;

        }

        public int MaxY { get; private set; }

        public int MinY { get; private set; }

        public int MaxX { get; private set; }

        public int MinX { get; private set; }

        public int CompareTo(Rectangle other)
        {
            return this.MinY.CompareTo(other.MinY);
        }
    }
}