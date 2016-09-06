using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Prims_Algorithm_With_Adjacency_Matrix
{
    public class PrimsAlgorithmAdjacencyMatrix
    {
        public static void Main()
        {
            int n = 9;
            var graphEdges = new List<Edge>()
            {
                new Edge(0, 3, 9),
                new Edge(0, 5, 4),
                new Edge(0, 8, 5),
                new Edge(1, 4, 8),
                new Edge(1, 7, 7),
                new Edge(2, 6, 12),
                new Edge(3, 5, 2),
                new Edge(3, 6, 8),
                new Edge(3, 8, 20),
                new Edge(4, 7, 10),
                new Edge(6, 8, 7)
            };

            var minimumSpanningForest = Prim(n, graphEdges);
            Console.WriteLine("Minimum spanning forest weight = " + minimumSpanningForest.Sum(e => e.Weight));
            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }

        private static List<Edge> Prim(int n, List<Edge> graphEdges)
        {
            var graphMatrix = new int?[n, n];
            foreach (var edge in graphEdges)
            {
                graphMatrix[edge.StartNode, edge.EndNode] = edge.Weight;
                graphMatrix[edge.EndNode, edge.StartNode] = edge.Weight;
            }
            
            var usedNodes = new bool[n];
            var spanningTreeEdges = new List<Edge>();

            for (int startNode = 0; startNode < n; startNode++)
            {
                if (!usedNodes[startNode])
                {
                    Prim(n, graphMatrix, startNode, usedNodes, spanningTreeEdges);
                }
            }

            return spanningTreeEdges;
        }

        private static void Prim(
            int n, int?[,] graphMatrix, int startNode, bool[] usedNodes, List<Edge> spanningTreeEdges)
        {
            usedNodes[startNode] = true;
            int[] edgeNode = new int[n];
            int[] nearest = new int[n];

            for (int i = 0; i < n; i++)
            {
                nearest[i] = int.MaxValue;
                if (graphMatrix[startNode, i] != null)
                {
                    nearest[i] = graphMatrix[startNode, i].Value;
                    edgeNode[i] = startNode;
                }
            }

            while (true)
            {
                int minimumDistance = int.MaxValue;
                int nearestNode = 0;

                for (int i = 0; i < n; i++)
                {
                    if (!usedNodes[i] && nearest[i] < minimumDistance)
                    {
                        minimumDistance = nearest[i];
                        nearestNode = i;
                    }
                }

                if (minimumDistance == int.MaxValue)
                {
                    return;
                }

                usedNodes[nearestNode] = true;
                spanningTreeEdges.Add(new Edge(edgeNode[nearestNode], nearestNode, minimumDistance));

                for (int i = 0; i < n; i++)
                {
                    if (!usedNodes[i] &&
                        graphMatrix[nearestNode, i] != null &&
                        graphMatrix[nearestNode, i] < nearest[i])
                    {
                        nearest[i] = graphMatrix[nearestNode, i].Value;
                        edgeNode[i] = nearestNode;
                    }
                }
            }
        }
    }
}
