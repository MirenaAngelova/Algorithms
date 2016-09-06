using System;
using System.Collections.Generic;

namespace _06.Renewal_2
{
    public class Renewal2
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<string> paths = new List<string>();
            List<string> build = new List<string>();
            List<string> destroy = new List<string>();

            for (int i = 0; i < n; i++)
            {
                paths.Add(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                build.Add(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                destroy.Add(Console.ReadLine());
            }

            Console.WriteLine(GetCost(paths, build, destroy));
        }

        private static int GetCost(List<string> path, List<string> build, List<string> destroy)
        {
            int n = path.Count;
            int massiveCost = 0;
            int mstCost = 0;
            // get the cost of each edge + destroy all the existing edges
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    if (path[i][j] == '0')
                        edges.Add(new Edge(i, j, GetValue(build[i][j])));
                    else
                    {
                        int val = GetValue(destroy[i][j]);
                        edges.Add(new Edge(i, j, -val));
                        massiveCost += val;
                    }
                }
            }

            // solve the MST on the graph, using Kruskal's algorithm
            edges.Sort();

            int[] color = new int[n];
            for (int i = 0; i < n; ++i)
            {
                color[i] = i;
            }

            for (int i = 0; i < edges.Count; ++i)
            {
                Edge edge = edges[i];
                // vertices of the edge are not in the same component
                if (color[edge.Parent] != color[edge.Child])
                {
                    mstCost += edge.Cost;
                    // recolor the component
                    int oldColor = color[edge.Child];
                    for (int j = 0; j < n; ++j)
                    {
                        if (color[j] == oldColor)
                            color[j] = color[edge.Parent];
                    }
                }
            }

            return massiveCost + mstCost;
        }

        private static int GetValue(char ch)
        {
            if (ch >= 'A' && ch <= 'Z')
            {
                return ch - 'A';
            }
            else
            {
                return ch - 'a' + 26;
            }
        }
    }
}
