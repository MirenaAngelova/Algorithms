using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Nested_Rectangles_2
{
    public class Rectangle
    {
        public Rectangle()
        {
            this.ParentRectangles = new List<int>();
        }

        public int Bottom { get; set; }

        public int Right { get; set; }

        public int Left { get; set; }

        public int Top { get; set; }

        public string Name { get; set; }

        public List<int> ParentRectangles { get; set; }

        public int ChildRectsCount { get; set; }
    }

    public class NestedRectangles2
    {
        public static void Main()
        {
            var rects = ReadRectangles();
            BuildGraph(rects);
            string[] longestSeq = FindLongestSequence(rects);
            Console.WriteLine(string.Join(" < ", longestSeq));
        }

        private static string[] FindLongestSequence(Rectangle[] rects)
        {
            const int NotCalculated = -1;
            const int NoNextRect = -1;
            int[] maxSeqLength = new int[rects.Length];
            int[] childrenCount = new int[rects.Length];
            int[] nextRect = new int[rects.Length];

            for (int i = 0; i < maxSeqLength.Length; i++)
            {
                childrenCount[i] = rects[i].ChildRectsCount;
                maxSeqLength[i] = (childrenCount[i] == 0) ? 1 : NotCalculated;
                nextRect[i] = NoNextRect;
            }

            bool[] used = new bool[rects.Length];
            while (true)
            {
                var rectsWithoutChildren =
                    Enumerable.Range(0, rects.Length)
                        .Where(v => !used[v] && childrenCount[v] == 0);
                if (!rectsWithoutChildren.Any())
                {
                    break;
                }

                var currentRect = rectsWithoutChildren.First();
                used[currentRect] = true;

                foreach (var parentRect in rects[currentRect].ParentRectangles)
                {
                    childrenCount[parentRect]--;
                    if ((maxSeqLength[currentRect] + 1 > maxSeqLength[parentRect]) ||
                       (maxSeqLength[currentRect] + 1 == maxSeqLength[parentRect] &&
                        rects[currentRect].Name.CompareTo(rects[nextRect[parentRect]].Name) < 0))
                    {
                        maxSeqLength[parentRect] = maxSeqLength[currentRect] + 1;
                        nextRect[parentRect] = currentRect;
                    }
                }
            }

            int startRect = 0;
            for (int i = 0; i < maxSeqLength.Length; i++)
            {
                if ((maxSeqLength[i] > maxSeqLength[startRect]) ||
                (maxSeqLength[i] == maxSeqLength[startRect] &&
                rects[i].Name.CompareTo(rects[startRect].Name) < 0))
                {
                    startRect = i;
                }
            }

            List<string> sequence = new List<string>();
            while (startRect != NoNextRect)
            {
                sequence.Add(rects[startRect].Name);
                startRect = nextRect[startRect];
            }

            return sequence.ToArray();
        }

        private static void BuildGraph(Rectangle[] rects)
        {
            for (int u = 0; u < rects.Length; u++)
            {
                for (int v = 0; v < rects.Length; v++)
                {
                    if (u != v && IsRectangleInsideAnother(rects[v], rects[u]))
                    {
                        rects[v].ParentRectangles.Add(u);
                        rects[u].ChildRectsCount++;
                    }
                }
            }
        }

        private static bool IsRectangleInsideAnother(Rectangle innerRectangle, Rectangle outerRectangle)
        {
            bool innerInsideOuter = innerRectangle.Left >= outerRectangle.Left &&
                                    innerRectangle.Left <= outerRectangle.Right &&
                                    innerRectangle.Top <= outerRectangle.Top &&
                                    innerRectangle.Top >= outerRectangle.Bottom &&
                                    innerRectangle.Right <= outerRectangle.Right &&
                                    innerRectangle.Right >= outerRectangle.Left &&
                                    innerRectangle.Bottom >= outerRectangle.Bottom &&
                                    innerRectangle.Bottom <= outerRectangle.Top;

            return innerInsideOuter;
        }

        private static Rectangle[] ReadRectangles()
        {
            var rects = new List<Rectangle>();
            string inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                string[] lineTokens = inputLine
                    .Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                Rectangle rect = new Rectangle()
                {
                    Name = lineTokens[0],
                    Left = int.Parse(lineTokens[1]),
                    Top = int.Parse(lineTokens[2]),
                    Right = int.Parse(lineTokens[3]),
                    Bottom = int.Parse(lineTokens[4])
                };

                rects.Add(rect);
                inputLine = Console.ReadLine();
            }

            return rects.ToArray();
        }
    }
}
