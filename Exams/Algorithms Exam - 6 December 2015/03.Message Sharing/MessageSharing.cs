using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Message_Sharing
{
    public class MessageSharing
    {
        private static Dictionary<string, List<string>> graph;
        private static SortedDictionary<string, int> distances;
        private static string[] start;
         
        public static void Main()
        {
            graph = new Dictionary<string, List<string>>();
            string[] peopleNames = Console.ReadLine()
                .Substring(8)
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peopleNames.Length; i++)
            {
                graph.Add(peopleNames[i], new List<string>());
            }

            string[] connections = Console.ReadLine()
                .Substring(13)
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < connections.Length; i++)
            {
                string[] parameters = connections[i]
                    .Split(new string[] {" - "}, StringSplitOptions.RemoveEmptyEntries);
                graph[parameters[0]].Add(parameters[1]);
                graph[parameters[1]].Add(parameters[0]);
            }

            distances = new SortedDictionary<string, int>();
            foreach (var name in peopleNames)
            {
                distances.Add(name, -1);
            }

            start = Console.ReadLine()
                .Substring(7)
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var person in start)
            {
                distances[person] = 0;
            }

            BFS();
        }

        private static void BFS()
        {
            Queue<string> visitedPerson = new Queue<string>();
            foreach (var startPerson in start)
            {
                visitedPerson.Enqueue(startPerson);
            }

            while (visitedPerson.Count > 0)
            {
                string currentPerson = visitedPerson.Dequeue();
                foreach (var child in graph[currentPerson])
                {
                    if (distances[child] == -1)
                    {
                        distances[child] = distances[currentPerson] + 1;
                        visitedPerson.Enqueue(child);
                    }
                }
            }

            if (distances.ContainsValue(-1))
            {
                Console.WriteLine
                    ($"Cannot reach: " +
                     $"{string.Join(", ", distances.Keys.Where(d => distances[d] == -1).ToList())}");
            }
            else
            {
                int maxDistances = distances.Values.Max();
                Console.WriteLine($"All people reached in {maxDistances} steps");
                Console.WriteLine($"People at last step: " +
                                  $"{string.Join(", ", distances.Keys.Where(d => distances[d] == maxDistances))}");
            }
        }
    }
}
