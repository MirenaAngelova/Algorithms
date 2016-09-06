using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Graph_Cycles
{
    public class GraphCycles
    {
        private static List<int>[] graph;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                int parent = int.Parse(parameters[0].Trim());
                graph[parent] = new List<int>();
                if (parameters.Length > 1)
                {
                    int[] child = parameters[1].Trim().Split().Select(int.Parse).Distinct().ToArray();
                    for (int j = 0; j < child.Length; j++)
                    {
                        graph[parent].Add(child[j]);
                    }
                }
            }

            int cycles = 0;
            for (int edges = 0; edges < n; edges++)
            {
                graph[edges].Sort();
                foreach (var child1 in graph[edges])
                {
                    if (edges < child1)
                    {
                        graph[child1].Sort();
                        foreach (var child2 in graph[child1])
                        {
                            if (edges < child2 && child2 != child1)
                            {
                                if (graph[child2].Contains(edges))
                                {
                                    cycles++;
                                    Console.WriteLine($"{{{edges}-> {child1} -> {child2}}}");
                                }
                            }
                        }
                    }

                }
            }

            if (cycles == 0)
            {
                Console.WriteLine("No cycles found");
            }
        }
    }
}
