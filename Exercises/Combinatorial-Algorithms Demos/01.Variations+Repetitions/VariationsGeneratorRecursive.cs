using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Variations_Repetitions
{
    public class VariationsGeneratorRecursive
    {
        private const int k = 3;
        private const int n = 10;

        private static string[] objects = new string[n]
        {
            "banana", "apple", "orange", "strawberry", "raspberry",
            "apricot", "cherry", "lemon", "grapes", "melon"
        };

        private static int[] array = new int[k];

        static void Main()
        {
            GenerateVariationsWithRepetitions(0);
        }

        private static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= k)
            {
                PrintVariation();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    array[index] = i;
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }

        private static void PrintVariation()
        {
            Console.WriteLine($"({string.Join(", ", array)}) --> " +
                              $"({string.Join(", ", array.Select(i => objects[i]))})");
        }
    }
}
