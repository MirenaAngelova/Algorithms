using System;
using System.Collections.Generic;

namespace _03.Most_Reliable_Path
{
    public class MostReliablePath
    {
        public static void Main()
        {
            int nodes = int.Parse(Console.ReadLine().Substring(7));
            string[] path = Console.ReadLine()
                .Substring(6)
                .Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            int startPath = int.Parse(path[0]);
            int endPath = int.Parse(path[1]);
            int edgesCount = int.Parse(Console.ReadLine().Substring(7));

            int[] previous = new int[nodes];
            bool[] visited = new bool[nodes];
            List<Node> graph = new List<Node>();

            for (int i = 0; i < nodes; i++)
            {
                graph.Add(new Node(i, -1));
            }

            for (int i = 0; i < edgesCount; i++)
            {
                string[] parameters = Console.ReadLine().Split();
                int start = int.Parse(parameters[0]);
                int end = int.Parse(parameters[1]);
                double reliability = double.Parse(parameters[2]);

                Edge edge = new Edge(start, end, reliability);
                Edge reverseEdge = new Edge(end, start, reliability);

                graph[start].Edges.Add(edge);
                graph[end].Edges.Add(reverseEdge);
            }

            Dijkstra(startPath, endPath, visited, graph, previous);

            List<int> result = ReconstructPath(previous, startPath, endPath, graph);

            Console.WriteLine("Most reliable path reliability: {0:0.00}", graph[endPath].Reliability);
            Console.WriteLine(result.Count > 0 ? string.Join(" -> ", result) : "Unreachable");
        }

        private static List<int> ReconstructPath(
            int[] previous,
            int start,
            int end,
            List<Node> graph)
        {
            if (graph[end].Reliability < 0)
            {
                return new List<int>();
            }

            List<int> path = new List<int>();
            path.Add(end);
            while (end != start)
            {
                path.Add(previous[end]);
                end = previous[end];
            }

            path.Reverse();
            return path;
        }

        private static void Dijkstra(
            int node,
            int end,
            bool[] visited,
            List<Node> graph,
            int[] previous)
        {
            graph[node].Reliability = 100;
            BinaryHeap<Node> priorityQueue = new BinaryHeap<Node>();
            priorityQueue.Insert(graph[node]);
            visited[node] = true;

            while (priorityQueue.Count > 0)
            {
                Node currentNode = priorityQueue.ExtractMax();
                if (currentNode.Value == end)
                {
                    break;
                }

                foreach (var edge in currentNode.Edges)
                {
                    if (!visited[edge.Child])
                    {
                        priorityQueue.Insert(graph[edge.Child]);
                        visited[edge.Child] = true;

                        double currentReliability = (currentNode.Reliability * edge.Weight) / 100;
                        if (graph[edge.Child].Reliability < currentReliability)
                        {
                            graph[edge.Child].Reliability = currentReliability;
                            previous[edge.Child] = edge.Parent;
                            priorityQueue.Reorder(graph[edge.Child]);
                        }
                    }
                }
            }
        }
    }
}
