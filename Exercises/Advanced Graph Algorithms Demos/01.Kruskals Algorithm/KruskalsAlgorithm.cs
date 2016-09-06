using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Kruskals_Algorithm
{
    public class KruskalsAlgorithm
    {
        public static void Main()
        {
            var verticesCount = 9;
            var graphEdges = new List<Edge>()
            {
                new Edge(6, 8, 7),
                new Edge (4, 7, 10),
                new Edge(3, 8, 20),
                new Edge(3, 6, 8),
                new Edge(3, 5, 2),
                new Edge(2, 6, 12),
                new Edge(1, 7, 7),
                new Edge(1, 4, 8),
                new Edge(0, 8, 5),
                new Edge(0, 5, 4), 
                new Edge(0, 3, 9)
            };

            var minimumSpanningForest = Kruskals(verticesCount, graphEdges);
            Console.WriteLine($"Minimum spanning forest weight: " +
                              $"{minimumSpanningForest.Sum(e => e.Weight)}");
            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }

        private static List<Edge> Kruskals(int n, List<Edge> edges)
        {
            edges.Sort();
            var child = new int[n];
            for (int i = 0; i < n; i++)
            {
                child[i] = i;
            }

            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                var rootStartEdge = FindRoot(edge.StartNode, child);
                var rootEndEdge = FindRoot(edge.EndNode, child);
                if (rootStartEdge != rootEndEdge)
                {
                    spanningTree.Add(edge);
                    child[rootStartEdge] = rootEndEdge;
                }
            }

            return spanningTree;
        }

        private static int FindRoot(int node, int[] child)
        {
            int root = node;
            while (child[root] != root)
            {
                root = child[root];
            }

            while (node != root)
            {
                var oldChild = child[node];
                child[node] = root;
                node = oldChild;
            }

            return root;
        }
    }
}
