using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Minimum_Edit_Distance
{
    public class MinimumEditDistance
    {
        private static int[,] distances;
        private static int costReplace;
        private static int costInsert;
        private static int costDelete;

        private static List<string> output = new List<string>(); 

        static void Main()
        {
            costReplace = int.Parse(Console.ReadLine().Substring(15));
            costInsert = int.Parse(Console.ReadLine().Substring(14));
            costDelete = int.Parse(Console.ReadLine().Substring(14));

            string s1 = Console.ReadLine().Substring(5);
            string s2 = Console.ReadLine().Substring(5);

            distances = new int[s1.Length + 1, s2.Length + 1];
            for (int i = 1; i <= s1.Length; i++)
            {
                distances[i, 0] = costDelete*i;
            }

            for (int i = 1; i <= s2.Length; i++)
            {
                distances[0, i] = costInsert*i;
            }

            var distance = CalcLevenshteinDistance(s1, s2);
            Console.WriteLine($"Minimum edit distance: {distance}");
            PrintChanges(s1, s2);
            PrintMatrix(s1, s2);
        }

        private static void PrintMatrix(string s1, string s2)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    Console.Write($"{distances[i, j], 3}");
                }
                Console.WriteLine();
            }
        }

        private static void PrintChanges(string s1, string s2)
        {
            int row = s1.Length;
            int col = s2.Length;
            while (row > 0 && col > 0)
            {
                int upDistance = distances[row - 1, col];
                int leftDistance = distances[row, col - 1];
                int upLeftDistance = distances[row - 1, col - 1];
                int min = Math.Min(Math.Min(upDistance, leftDistance), upLeftDistance);
                if (min == upLeftDistance)
                {
                    row--;
                    col--;
                    if (min < distances[row + 1, col + 1])
                    {
                        if (costReplace <= costDelete + costInsert)
                        {
                            output.Add($"REPLACE({row}, {s2[col]})");
                        }
                        else
                        {
                            output.Add($"INSERT({col}, {s2[col]})");
                            output.Add($"DELETE({row})");
                        }
                    }
                }
                else if (min == upDistance)
                {
                    row--;
                    if (min < distances[row + 1, col])
                    {
                        output.Add($"DELETE({row})");
                    }
                }
                else
                {
                    col--;
                    if (min < distances[row, col + 1])
                    {
                        output.Add($"INSERT({col}, {s2[col]})");
                    }
                }
            }

            while (row > 0)
            {
                int upDistance = distances[row - 1, col];
                row--;
                if (upDistance < distances[row + 1, col])
                {
                    output.Add($"DELETE({row})");
                }
            }

            while (col > 0)
            {
                int leftDistance = distances[row, col - 1];
                col--;
                if (leftDistance < distances[row, col + 1])
                {
                    output.Add($"INSERT({col}, {s2[col]})");
                }
            }

            output.Reverse();
            Console.WriteLine(string.Join(Environment.NewLine, output));
        }

        private static int CalcLevenshteinDistance(string first, string second)
        {
            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        distances[i, j] = distances[i - 1, j - 1];
                    }
                    else
                    {
                        distances[i, j] =
                            Math.Min(
                                Math.Min(distances[i - 1, j] + costDelete, 
                                distances[i, j - 1] + costInsert),
                                distances[i - 1, j - 1] + costReplace);
                    }
                }
            }

            return distances[first.Length, second.Length];
        }
    }
}
