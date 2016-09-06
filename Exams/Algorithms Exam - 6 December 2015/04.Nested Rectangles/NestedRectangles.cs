using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Nested_Rectangles
{
    public class Rectangle
    {
        public Rectangle(string name, int x1, int x2, int y1, int y2)
        {
            this.Name = name;
            this.X1 = x1;
            this.X2 = x2;
            this.Y1 = y1;
            this.Y2 = y2;
            this.Children = new List<Rectangle>();
            this.Depth = 0;
        }

        public Rectangle Successor { get; set; }

        public int Depth { get; set; }

        public List<Rectangle> Children { get; private set; }

        public int Y2 { get; set; }

        public int Y1 { get; set; }

        public int X2 { get; set; }

        public int X1 { get; set; }

        public string Name { get; set; }
    }

    public class NestedRectangles
    {
        static void Main()
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            string inputLine = Console.ReadLine();
            while (inputLine != "End")
            {
                string[] parameters = inputLine
                    .Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = parameters[0];
                int x1 = int.Parse(parameters[1]);
                int y2 = int.Parse(parameters[2]);
                int x2 = int.Parse(parameters[3]);
                int y1 = int.Parse(parameters[4]);

                Rectangle rectangle = new Rectangle(name, x1, x2, y1, y2);
                rectangles.Add(rectangle);

                inputLine = Console.ReadLine();
            }

            rectangles = rectangles
                .OrderBy(x => x.X1)
                .ThenByDescending(x => x.X2)
                .ThenBy(x => x.Y1)
                .ThenByDescending(x => x.Y2)
                .ThenBy(x => x.Name)
                .ToList();
            for (int i = 0; i < rectangles.Count; i++)
            {
                Rectangle currentRectangle = rectangles[i];
                for (int j = i + 1; j < rectangles.Count; j++)
                {
                    if (rectangles[j].X2 > currentRectangle.X2 ||
                        rectangles[j].Y1 < currentRectangle.Y1 ||
                        rectangles[j].Y2 > currentRectangle.Y2)
                    {
                        continue;
                    }

                    currentRectangle.Children.Add(rectangles[j]);
                }
            }

            for (int i = 0; i < rectangles.Count; i++)
            {
                DFS(rectangles[i]);
            }

            Rectangle parent = rectangles.OrderByDescending(r => r.Depth).ThenBy(r => r.Name).First();
            int depth = parent.Depth;
            while (true)
            {
                Console.Write(parent.Name); //Alpha < Zeta < Delta
                depth -= 1;
                parent = parent.Successor;
                if (parent == null || depth == 0)
                {
                    Console.WriteLine();
                    break;
                }

                Console.Write(" < ");
            }
        }

        private static int DFS(Rectangle rectangle)
        {
            if (rectangle.Depth > 0)
            {
                return rectangle.Depth;
            }

            rectangle.Depth = 1;
            rectangle.Successor = null;
            foreach (var child in rectangle.Children)
            {
                int currentDepth = DFS(child) + 1;
                if (currentDepth > rectangle.Depth || 
                    (currentDepth == rectangle.Depth && 
                    child.Name.CompareTo(rectangle.Successor.Name) < 0))
                {
                    rectangle.Depth = currentDepth;
                    rectangle.Successor = child;
                }
            }

            return rectangle.Depth;
        }
    }
}
