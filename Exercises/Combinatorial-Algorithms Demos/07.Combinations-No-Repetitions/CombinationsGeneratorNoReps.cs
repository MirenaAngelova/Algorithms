using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Combinations_No_Repetitions
{
    public class CombinationsGeneratorNoReps
    {
        private const int k = 3;
        private const int n = 5;

        private static string[] objects = new string[n]
        {
            "banana", "apple", "orange", "strawberry", "raspberry"
        };

        private static int[] array = new int[k];

        static void Main()
        {
            GenerateCombinationsNoReps(0, 0);
        }

        private static void GenerateCombinationsNoReps(int index, int start)
        {
            if (index >= k)
            {
                PrintCombination();
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    array[index] = i;
                    GenerateCombinationsNoReps(index + 1, i + 1);
                }
            }
        }

        private static void PrintCombination()
        {
            Console.WriteLine($"({string.Join(", ", array)}) --> " +
                              $"({string.Join(", ", array.Select(i => objects[i]))})");
        }
    }
}
