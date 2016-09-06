namespace _01.Frames
{
    public class Frame
    {
        public Frame(int left, int right)
        {
            this.Left = left;
            this.Right = right;
        }

        public int Right { get; set; }

        public int Left { get; set; }

        public override string ToString()
        {
            return $"({this.Left}, {this.Right})";
        }
    }
}