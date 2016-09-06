using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _06.Renewal_3
{
    public class Renewal3
    {
        private const int SmallLettersOffset = 26;

        private static HashSet<string> duplicateEdges = new HashSet<string>();
        private static bool[,] matrix;
        private static int[,] buildingCosts;
        private static int[,] destructionCosts;
        private static bool[] visited;

        private static int verticesCount;

        public static void Main()
        {
            ProcessInput();
            int result = FindMinSumForRenewal(0);
            PrintOutput(result);
        }

        private static void PrintOutput(int result)
        {
            Console.WriteLine(result);
        }

        private static int FindMinSumForRenewal(int startVertex)
        {
            BinaryHeap<Edge> heap = new BinaryHeap<Edge>();
            int result = 0;
            visited[startVertex] = true;

            AddChildrenToHeap(startVertex, heap);
            while (heap.Count > 0)
            {
                Edge currentEdge = heap.ExtractMin();
                int source = currentEdge.Source;
                int destination = currentEdge.Destination;

                if (visited[source] ^ visited[destination])
                {
                    if (!currentEdge.Exists)
                    {
                        result += currentEdge.Cost;
                    }

                    visited[destination] = true;

                    AddChildrenToHeap(destination, heap);
                }
                else if(currentEdge.Exists)
                {
                    result += currentEdge.Cost;
                }
            }

            return result;
        }

        private static void AddChildrenToHeap(int startVertex, BinaryHeap<Edge> heap)
        {
            for (int childIndex = 0; childIndex < verticesCount; childIndex++)
            {
                if (childIndex == startVertex)
                {
                    continue;
                }

                Edge edge = new Edge(
                    startVertex, 
                    childIndex, 
                    destructionCosts[startVertex, childIndex],
                    true);

                if (duplicateEdges.Contains(edge.ToString()))
                {
                    continue;
                }

                duplicateEdges.Add(edge.ToString());

                if (matrix[startVertex, childIndex])
                {
                    heap.Insert(edge);
                }
                else
                {
                    edge.Cost = buildingCosts[startVertex, childIndex];
                    edge.Exists = false;
                    heap.Insert(edge);
                }
            }
        }

        private static void ProcessInput()
        {
            string input;
            verticesCount = int.Parse(Console.ReadLine());
            matrix = new bool[verticesCount, verticesCount];
            buildingCosts = new int[verticesCount, verticesCount];
            destructionCosts = new int[verticesCount, verticesCount];
            visited = new bool[verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                input = Console.ReadLine();
                for (int j = 0; j < verticesCount; j++)
                {
                    matrix[i, j] = input[j] == '0' ? false : true;
                }
            }

            for (int i = 0; i < verticesCount; i++)
            {
                input = Console.ReadLine();
                for (int j = 0; j < verticesCount; j++)
                {
                    int cost = 0;
                    if (SmallLetter(input[j]))
                    {
                        cost = (input[j] - 'a') + SmallLettersOffset;
                    }
                    else
                    {
                        cost = input[j] - 'A';
                    }

                    buildingCosts[i, j] = cost;
                }
            }

            for (int i = 0; i < verticesCount; i++)
            {
                input = Console.ReadLine();
                for (int j = 0; j < verticesCount; j++)
                {
                    int cost = 0;
                    if (SmallLetter(input[j]))
                    {
                        cost = (input[j] - 'a') + SmallLettersOffset;
                    }
                    else
                    {
                        cost = input[j] - 'A';
                    }

                    destructionCosts[i, j] = cost;
                }
            }
        }

        private static bool SmallLetter(char ch)
        {
            return ch >= 'a' && ch <= 'z';
        }
    }
}
