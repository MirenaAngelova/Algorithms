using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Cycles_in_a_Graph
{
    public class CyclesInAGraph
    {
        private static HashSet<string> visited;
        private static Dictionary<string, List<string>> graph;

        private static bool isAcyclic;
         
        public static void Main()
        {
            isAcyclic = true;
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();

            Console.WriteLine("Enter parameters and fihish input with empty line!");
            string parameters = Console.ReadLine();

            while (parameters != String.Empty)
            {
                string[] parametersArray = parameters
                    .Split(new[] {' ', '-'}, StringSplitOptions.RemoveEmptyEntries);
                string start = parametersArray[0];
                string end = parametersArray[1];

                parameters = Console.ReadLine();

                if (!graph.ContainsKey(start))
                {
                    graph.Add(start, new List<string>());
                }

                if (!graph.ContainsKey(end))
                {
                    graph.Add(end, new List<string>());
                }

                graph[start].Add(end);
                graph[end].Add(start);
            }

            CheckIsAcyclic(graph.Keys.First());
            Console.WriteLine("Acyclic: {0}", isAcyclic ? "Yes" : "No");
        }

        private static void CheckIsAcyclic(string node, string previousNode = null)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                foreach (var child in graph[node])
                {
                    if (child != previousNode)
                    {
                        CheckIsAcyclic(child, node);
                    }
                }
            }
            else
            {
                isAcyclic = false;
            }
        }
    }
}
