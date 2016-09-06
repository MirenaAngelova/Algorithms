using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shortest_Path_in_Matrix
{
    public class ShortestPathInMatrix
    {
        private static int[] prev;
        private static bool[] visited;
        private static int[,] matrix;
        private static int rows;
        private static int cols;

        public static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());

            matrix = new int[rows, cols];
            int size = rows*cols;
            prev = new int[size];
            visited = new bool[size];
            for (int i = 0; i < rows; i++)
            {
                int[] inputLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = inputLine[j];
                }
            }

            List<Node> graph = new List<Node>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int parentIndex = row*cols + col;
                    graph.Add(new Node(parentIndex, int.MaxValue));
                    if (row - 1 >= 0)
                    {
                        int childIndex = (row - 1)*cols + col;
                        int distance = matrix[row - 1, col];
                        graph[parentIndex].Edges.Add(new Edge(parentIndex,childIndex, distance));
                    }

                    if (col - 1 >= 0)
                    {
                        int childIndex = (row*cols) + col - 1;
                        int distance = matrix[row, col - 1];
                        graph[parentIndex].Edges.Add(new Edge(parentIndex, childIndex, distance));
                    }

                    if (col + 1 < cols)
                    {
                        int childIndex = (row*cols) + (col + 1);
                        int distance = matrix[row, col + 1];
                        graph[parentIndex].Edges.Add(new Edge(parentIndex, childIndex, distance));
                    }

                    if (row + 1 < rows)
                    {
                        int childIndex = (row + 1)*cols + col;
                        int distance = matrix[row + 1, col];
                        graph[parentIndex].Edges.Add(new Edge(parentIndex, childIndex, distance));
                    }
                }
            }

            Dijkstra(0, size - 1, graph);
            List<int> path = ReconstructPath(0, size - 1);
            Console.WriteLine(
                $"Length: {graph[size - 1].Distance}{Environment.NewLine}Path: {string.Join(" ", path)}");
        }

        private static List<int> ReconstructPath(int start, int end)
        {
            List<int> path =new List<int>();
            int currentRow = end/cols;
            int currentCol = end%cols;
            int prevElement = int.MaxValue;
            while (true)
            {
                path.Add(matrix[currentRow, currentCol]);
                if (prevElement == start)
                {
                    break;
                }

                prevElement = prev[(currentRow*cols) + currentCol];
                currentRow = prevElement/cols;
                currentCol = prevElement%cols;
            }

            path.Reverse();
            return path;
        }

        private static void Dijkstra(int start, int end, List<Node> graph)
        {
            int startRow = start/cols;
            int startCol = start%cols;
            graph[start].Distance = matrix[startRow, startCol];
            BinaryHeap<Node> priorityQueue = new BinaryHeap<Node>();
            priorityQueue.Insert(graph[start]);
            visited[start] = true;

            while (priorityQueue.Count() > 0)
            {
                Node current = priorityQueue.ExtractMin();
                if (current.Value == end)
                {
                    break;
                }

                foreach (var edge in current.Edges)
                {
                    if (!visited[edge.Child])
                    {
                        priorityQueue.Insert(graph[edge.Child]);
                        visited[edge.Child] = true;
                    }

                    int currentDistance = current.Distance + edge.Distance;
                    if (graph[edge.Child].Distance > currentDistance)
                    {
                        graph[edge.Child].Distance = currentDistance;
                        prev[edge.Child] = current.Value;
                        priorityQueue.Reorder(graph[edge.Child]);
                    }
                }
            }
        }
    }
}
