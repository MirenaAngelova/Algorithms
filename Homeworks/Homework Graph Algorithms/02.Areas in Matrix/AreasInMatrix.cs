using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Areas_in_Matrix
{
    public class AreasInMatrix
    {
        private static List<string> matrix;
        private static bool[,] visited;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine().Substring(16));
            matrix = new List<string>();
            for (int i = 0; i < rows; i++)
            {
                matrix.Add(Console.ReadLine());
            }

            int cols = matrix[0].Length;
            visited = new bool[rows, cols];
            SortedDictionary<char, int> areas = new SortedDictionary<char, int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!visited[i, j])
                    {
                        var letter = matrix[i][j];
                        MapSubarea(i, j, letter);
                        if (!areas.ContainsKey(letter))
                        {
                            areas.Add(letter, 0);
                        }

                        areas[letter]++;
                    }
                }
            }

            Console.WriteLine($"Areas: {areas.Values.Sum()}");
            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void MapSubarea(int row, int col, char letter)
        {
            if (row < 0 || row >= matrix.Count || col < 0 || col >= matrix[0].Length)
            {
                return;
            }

            if (matrix[row][col] != letter)
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            visited[row, col] = true;

            MapSubarea(row, col + 1, letter);
            MapSubarea(row + 1, col, letter);
            MapSubarea(row, col - 1, letter);
            MapSubarea(row - 1, col, letter);
        }
    }
}
