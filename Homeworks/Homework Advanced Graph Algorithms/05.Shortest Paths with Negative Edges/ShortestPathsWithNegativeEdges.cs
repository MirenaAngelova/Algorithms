using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _01.Extend_a_Cable_Network;

namespace _05.Shortest_Paths_with_Negative_Edges
{
    public class ShortestPathsWithNegativeEdges
    {
        public static void Main()
        {
            int nodes = int.Parse(Console.ReadLine().Substring(7));
            string[] path = Console.ReadLine()
                .Substring(6)
                .Split(new[] {' ', '-'}, StringSplitOptions.RemoveEmptyEntries);
            int startPath = int.Parse(path[0]);
            int endPath = int.Parse(path[1]);
            int edgesCount = int.Parse(Console.ReadLine().Substring(7));

            List<Edge> edges = new List<Edge>();
            long[] distances = new long[nodes];
            int?[] previous = new int?[nodes];

            for (int i = 0; i < edgesCount; i++)
            {
                string[] parameters = Console.ReadLine().Split();
                int start = int.Parse(parameters[0]);
                int end = int.Parse(parameters[1]);
                int weight = int.Parse(parameters[2]);

                Edge edge = new Edge(start, end, weight);
                edges.Add(edge);
            }

            BellmanFord(distances, previous, edges, nodes, startPath, endPath);
        }

        private static void BellmanFord(
            long[] distances, 
            int?[] previous, 
            List<Edge> edges, 
            int nodes, 
            int start, 
            int end)
        {
            for (int i = 0; i < nodes; i++)
            {
                distances[i] = int.MaxValue;
                previous[i] = null;
            }

            distances[start] = 0;
            for (int i = 0; i < nodes - 1; i++)
            {
                foreach (var edge in edges)
                {
                    if (distances[edge.Parent] + edge.Weight < distances[edge.Child])
                    {
                        distances[edge.Child] = distances[edge.Parent] + edge.Weight;
                        previous[edge.Child] = edge.Parent;
                    }
                }
            }

            foreach (var edge in edges)
            {
                if (distances[edge.Parent] + edge.Weight < distances[edge.Child])
                {
                    Console.WriteLine("Negative cycle detected:");
                    List<int> pathNegative = new List<int>();
                    int? prevNegative = previous[edge.Child];
                    while (prevNegative != null && !pathNegative.Contains(prevNegative.Value))
                    {
                        pathNegative.Add(prevNegative.Value);
                        prevNegative = previous[prevNegative.Value];
                    }

                    pathNegative.Reverse();
                    Console.WriteLine(string.Join(" -> ", pathNegative));
                    return;
                }
            }

            List<int> path = new List<int>();
            path.Add(end);
            int? prev = previous[end];
            while (prev != null)
            {
                path.Add(prev.Value);
                prev = previous[prev.Value];
            }

            path.Reverse();

            Console.WriteLine($"Distance [{start} -> {end}]: {distances[end]}");
            Console.WriteLine($"Path: {string.Join(" -> ", path)}");
        }
    }
}
