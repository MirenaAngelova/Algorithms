using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Find_the_Bi_Connected_Components_in_a_Graph
{
    public class FindBiConnectedComponents
    {
        private static bool[] visited;
        private static int?[] parent;
        private static int[] depth;
        private static int[] lowpoint;

        private static Stack<Edge> biConnectedComponents;
        private static Dictionary<int, List<Edge>> graph;

        public static void Main()
        {
            int nodes = int.Parse(Console.ReadLine().Substring(7));
            int edgesCount = int.Parse(Console.ReadLine().Substring(7));
            graph = new Dictionary<int, List<Edge>>();
            lowpoint = new int[nodes];
            depth = new int[nodes];
            parent = new int?[nodes];
            visited = new bool[nodes];
            biConnectedComponents = new Stack<Edge>();

            for (int i = 0; i < edgesCount; i++)
            {
                string[] parameters = Console.ReadLine().Split();
                int start = int.Parse(parameters[0]);
                int end = int.Parse(parameters[1]);

                if (!graph.ContainsKey(start))
                {
                    graph.Add(start, new List<Edge>());
                }
                if (!graph.ContainsKey(end))
                {
                    graph.Add(end, new List<Edge>());
                }
                graph[start].Add(new Edge(start, end));
                graph[end].Add(new Edge(end, start));
            }
            Console.WriteLine();
            FindBiConnectedGroups(0, 0);
        }

        private static void FindBiConnectedGroups(int node, int d)
        {
            visited[node] = true;
            depth[node] = d;
            lowpoint[node] = d;
            int childCount = 0;
            foreach (var edge in graph[node])
            {
                var childNode = edge.Child;
                if (!visited[childNode])
                {
                    biConnectedComponents.Push(edge);
                    parent[childNode] = node;
                    FindBiConnectedGroups(childNode, d + 1);
                    childCount++;
                    if (lowpoint[childNode] >= depth[node])
                    {
                        while (biConnectedComponents.Peek().Parent != node)
                        {
                            Console.Write("{0} ", biConnectedComponents.Pop().Child);
                        }

                        var lastEdge = biConnectedComponents.Pop();
                        Console.Write($"{lastEdge.Child} ");
                        Console.Write($"{lastEdge.Parent} ");
                        Console.WriteLine();
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[childNode]);
                }
                else if (childNode != parent[node] && depth[childNode] < depth[node])
                {
                    lowpoint[node] = Math.Min(lowpoint[node], depth[childNode]);
                }
            }
        }
    }
}
