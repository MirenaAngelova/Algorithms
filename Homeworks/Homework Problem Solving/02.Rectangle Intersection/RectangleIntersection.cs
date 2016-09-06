using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Rectangle_Intersection
{
    public class RectangleIntersection
    {
        public static void Main()
        {
            List<Rectangle> allRectangles = new List<Rectangle>();
            List<int> x = new List<int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int minX = parameters[0];
                int maxX = parameters[1];
                int minY = parameters[2];
                int maxY = parameters[3];
                Rectangle rectangle = new Rectangle(minX, maxX, minY, maxY);

                allRectangles.Add(rectangle);
                x.Add(minX);
                x.Add(maxX);
            }

            allRectangles.Sort();
            x.Sort();

            List<Rectangle>[] rect = new List<Rectangle>[x.Count - 1];
            for (int i = 0; i < x.Count - 1; i++)
            {
                rect[i] = new List<Rectangle>();
            }

            foreach (var rectangle in allRectangles)
            {
                for (int i = 0; i < x.Count - 1; i++)
                {
                    if (rectangle.MaxX > x[i] && rectangle.MinX < x[i + 1])
                    {
                        rect[i].Add(rectangle);
                    }
                }
            }

            long sum = 0;
            for (int i = 0; i < rect.Length; i++)
            {
                if (rect[i].Count < 2)
                {
                    continue;
                }

                List<int> y = new List<int>();
                foreach (var rectangle in rect[i])
                {
                    y.Add(rectangle.MinY);
                    y.Add(rectangle.MaxY);
                }

                y.Sort();

                int[] overlapCount = new int[y.Count - 1];
                foreach (var rectangle in rect[i])
                {
                    for (int j = 0; j < y.Count - 1; j++)
                    {
                        if (rectangle.MaxY > y[j] && rectangle.MinY < y[j + 1])
                        {
                            overlapCount[j]++;
                        }
                    }
                }

                for (int j = 0; j < overlapCount.Length; j++)
                {
                    if (overlapCount[j] > 1)
                    {
                        int distanceX = x[i + 1] - x[i];
                        int distanceY = y[j + 1] - y[j];
                        long area = distanceX*distanceY;
                        sum += area;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
