using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Maximum_Tasks_Assignment
{
    public class MaximumTasksAssignment
    {
        private static bool pathFound = false;
        private static bool[] tasksFinished;
        private static Dictionary<int, List<int>> graph;
        private static int[] path;
        private static int tasks;
        private static int counter;
        
        public static void Main()
        {
            int persons = int.Parse(Console.ReadLine().Substring(8));
            tasks = int.Parse(Console.ReadLine().Substring(7));

            graph = new Dictionary<int, List<int>>();
            path = new int[tasks];
            tasksFinished = new bool[tasks];
            counter = 0;

            for (int i = 0; i < persons; i++)
            {
                graph.Add(i, new List<int>());
                string inputLine = Console.ReadLine();
                for (int j = 0; j < inputLine.Length; j++)
                {
                    if (inputLine[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }

            FindAugmentingPathDFS(0, graph);
            if (counter < tasks)
            {
                Console.WriteLine("Impossible.");
            }
            else
            {
                for (int i = 0; i < tasks; i++)
                {
                    Console.WriteLine($"{(char)('A' + i)}-{path[i] + 1}");
                }
            }
        }

        private static void FindAugmentingPathDFS(int node, Dictionary<int, List<int>> dictionary)
        {
            if (node == tasks)
            {
                pathFound = true;
                return;
            }

            foreach (var child in graph[node])
            {
                if (!tasksFinished[child])
                {
                    tasksFinished[child] = true;
                    path[node] = child;
                    counter++;
                    FindAugmentingPathDFS(node + 1, graph);
                    tasksFinished[child] = false;
                    if (pathFound)
                    {
                        return;
                    }

                    counter--;
                }
            }
        }
    }
}
