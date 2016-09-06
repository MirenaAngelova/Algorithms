using System.Collections.Generic;

namespace _05.Dijkstra_With_Priority_Queue
{
    public class DijkstraAlgorithm
    {
        public static List<int> Dijkstra(
            Dictionary<Node, Dictionary<Node, int>> graph,
            Dictionary<int, Node> nodes, int sourceNode, int destinationNode)
        {
            bool[] visited = new bool[graph.Count];
            int[] previous = new int[graph.Count];

            PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

            var startNode = nodes[sourceNode];
            startNode.DistanceFromStart = 0;
            for (int i = 0; i < previous.Length; i++)
            {
                previous[i] = -1;
            }

            priorityQueue.Enqueue(startNode);
            while (priorityQueue.Count() > 0)
            {
                var currentNode = priorityQueue.ExtractMin();
                if (currentNode.Index == destinationNode)
                {
                    break;
                }

                foreach (var node in graph[currentNode])
                {
                    if (!visited[node.Key.Index])
                    {
                        priorityQueue.Enqueue(node.Key);
                        visited[node.Key.Index] = true;
                    }

                    var distance = currentNode.DistanceFromStart + node.Value;
                    if (distance < node.Key.DistanceFromStart)
                    {
                        node.Key.DistanceFromStart = distance;
                        previous[node.Key.Index] = currentNode.Index;
                        priorityQueue.DecreaseKey(node.Key);
                    }
                }
            }

            if (previous[destinationNode] == -1)
            {
                return null;
            }

            List<int> path = new List<int>();
            int currentElement = previous[destinationNode];
            while (currentElement != -1)
            {
                path.Add(currentElement);
                currentElement = previous[currentElement];
            }

            path.Reverse();
            return path;
        }
    }
}