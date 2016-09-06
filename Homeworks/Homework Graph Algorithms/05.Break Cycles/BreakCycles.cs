using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Break_Cycles
{
    public class BreakCycles
    {
        private static SortedDictionary<string, List<string>> graph; 
        private static HashSet<string> visited;
         
        private static int removedEdges = 0;
         
        public static void Main()
        {
            graph = new SortedDictionary<string, List<string>>();
            StringBuilder result = new StringBuilder();

            Console.WriteLine("Enter input lines and finish with empty line:");
            string input = Console.ReadLine();
            while (input != String.Empty)
            {
                string[] parameters = input
                    .Split(new[] {' ', '-', '>', ','}, StringSplitOptions.RemoveEmptyEntries);
                string key = parameters[0];
                graph.Add(key, new List<string>());
                for (int i = 1; i < parameters.Length; i++)
                {
                    graph[key].Add(parameters[i]);
                }

                input = Console.ReadLine();
            }

            foreach (var key in graph.Keys)
            {
                graph[key].Sort();
                for (int i = 0; i < graph[key].Count; i++)
                {
                    var end = graph[key][i];
                    graph[key].RemoveAt(i);
                    graph[end].Remove(key);
                    if (CalculateRemovedEdges(key, end))
                    {
                        removedEdges++;
                        result.Append($"{key} - {end}{Environment.NewLine}");
                    }
                    else
                    {
                        graph[key].Insert(i, end);
                        graph[end].Add(key);

                    }
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges}");
            Console.WriteLine(result.ToString());
        }

        private static bool CalculateRemovedEdges(string start, string end)
        {
            var visited = new HashSet<string>();
            var nodes = new Queue<string>();
            visited.Add(start);
            nodes.Enqueue(start);
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                if (node == end)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        nodes.Enqueue(child);
                    }
                }
            }

            return false;
        }
    }
}
