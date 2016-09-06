using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Extend_a_Cable_Network
{
    public class ExtendACableNetwork
    {
        public static void Main()
        {
            int budget = int.Parse(Console.ReadLine().Substring(8));
            int nodes = int.Parse(Console.ReadLine().Substring(7));
            int edges = int.Parse(Console.ReadLine().Substring(7));

            Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();
            HashSet<int> connected = new HashSet<int>();

            for (int i = 0; i < nodes; i++)
            {
                graph.Add(i, new List<Edge>());
            }

            for (int i = 0; i < edges; i++)
            {
                string[] parameters = Console.ReadLine().Split();
                int parent = int.Parse(parameters[0]);
                int child = int.Parse(parameters[1]);
                int weight = int.Parse(parameters[2]);

                graph[parent].Add(new Edge(parent, child, weight));
                graph[child].Add(new Edge(child, parent, weight));

                if (parameters.Length > 3)
                {
                    connected.Add(parent);
                    connected.Add(child);
                }
            }

            PrimAlgorithm(graph, connected, budget);
        }

        private static void PrimAlgorithm(
            Dictionary<int, List<Edge>> graph,
            HashSet<int> connected, 
            int budget)
        {
            int budgetUsed = 0;
            BinaryHeap<Edge> priorityQueue = new BinaryHeap<Edge>();
            foreach (var node in connected)
            {
                foreach (var edge in graph[node])
                {
                    if (!connected.Contains(edge.Child))
                    {
                        priorityQueue.Insert(edge);
                    }
                }
            }

            while (priorityQueue.Count > 0)
            {
                var node = priorityQueue.ExtractMin();
                if (budgetUsed + node.Weight > budget || connected.Contains(node.Child))
                {
                    continue;
                }

                Console.WriteLine(node);
                budgetUsed += node.Weight;

                connected.Add(node.Child);

                foreach (var edge in graph[node.Child])
                {
                    if (!connected.Contains(edge.Child))
                    {
                        priorityQueue.Insert(edge);
                    }
                }
            }

            Console.WriteLine($"Budget used: {budgetUsed}");
        }
    }
}
