﻿using System;
using System.Collections.Generic;

namespace _04.Dijkstra_Without_Queue
{
    public class DijkstraWithoutQueue
    {
        public static void Main()
        {
            var graph = new[,]
            {
                // 0   1   2   3   4   5   6   7   8   9  10  11
                { 0,  0,  0,  0,  0,  0, 10,  0, 12,  0,  0,  0 }, // 0
                { 0,  0,  0,  0, 20,  0,  0, 26,  0,  5,  0,  6 }, // 1
                { 0,  0,  0,  0,  0,  0,  0, 15, 14,  0,  0,  9 }, // 2
                { 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  7,  0 }, // 3
                { 0, 20,  0,  0,  0,  5, 17,  0,  0,  0,  0, 11 }, // 4
                { 0,  0,  0,  0,  5,  0,  6,  0,  3,  0,  0, 33 }, // 5
                {10,  0,  0,  0, 17,  6,  0,  0,  0,  0,  0,  0 }, // 6
                { 0, 26, 15,  0,  0,  0,  0,  0,  0,  3,  0, 20 }, // 7
                {12,  0, 14,  0,  0,  3,  0,  0,  0,  0,  0,  0 }, // 8
                { 0,  5,  0,  0,  0,  0,  0,  3,  0,  0,  0,  0 }, // 9
                { 0,  0,  0,  7,  0,  0,  0,  0,  0,  0,  0,  0 }, // 10
                { 0,  6,  9,  0, 11, 33,  0, 20,  0,  0,  0,  0 }, // 11
            };

            FindAndPrintShortestPath(graph, 0, 9);
            FindAndPrintShortestPath(graph, 0, 2);
            FindAndPrintShortestPath(graph, 0, 10);
            FindAndPrintShortestPath(graph, 0, 11);
            FindAndPrintShortestPath(graph, 0, 1);
            FindAndPrintShortestPath(graph, 0, 0);
        }

        private static void FindAndPrintShortestPath(int[,] graph, int sourceNode, int destinationNode)
        {
            Console.Write($"Shortest path [{sourceNode} -> {destinationNode}]: ");

            var path = Dijkstra(graph, sourceNode, destinationNode);
            if (path == null)
            {
                Console.WriteLine("no path");

            }
            else
            {
                int pathLength = 0;
                for (int i = 0; i < path.Count - 1; i++)
                {
                    pathLength += graph[path[i], path[i + 1]];
                }

                string formattedPath = string.Join(" -> ", path);
                Console.WriteLine($"{formattedPath}, (lenght -> {pathLength})");
            }
        }

        private static List<int> Dijkstra(int[,] graph, int sourceNode, int destinationNode)
        {
            int n = graph.GetLength(0);

            int[] distance = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[sourceNode] = 0;

            bool[] used = new bool[n];
            int?[] previous = new int?[n];

            while (true)
            {
                int minDistance = int.MaxValue;
                int minNode = 0;
                for (int node = 0; node < n; node++)
                {
                    if (!used[node] && distance[node] < minDistance)
                    {
                        minDistance = distance[node];
                        minNode = node;
                    }
                }

                if (minDistance == int.MaxValue)
                {
                    break;
                }

                used[minNode] = true;
                for (int i = 0; i < n; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int newDistance = distance[minNode] + graph[minNode, i];
                        if (newDistance < distance[i])
                        {
                            distance[i] = newDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            if (distance[destinationNode] == int.MaxValue)
            {
                return null;
            }

            var path = new List<int>();
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }

            path.Reverse();
            return path;
        }
    }
}
