using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Combinations_Repetitions
{
    public class CombinationsGeneratorWithReps
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
            GenerateCombinationsWithReps(0, 0);
        }

        private static void GenerateCombinationsWithReps(int index, int start)
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
                    GenerateCombinationsWithReps(index + 1, i);
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
