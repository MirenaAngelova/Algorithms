using System;
using System.Linq;

namespace _03.Variations_No_Reps_Slow
{
    public class VariationsNoRepsSlow
    {
        private const int k = 2;
        private const int n = 10;
        private static string[] objects = new string[n]
        {
            "banana", "apple", "orange", "strawberry", "rapsberry",
            "apricot", "cherry", "lemon", "grapes", "melon"
        };

        private static int[] array = new int[k];
        private static bool[] used = new bool[n];

        static void Main()
        {
            GenerateVariationsNoRepetitions(0);
        }

        private static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= k)
            {
                PrintVariation();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        array[index] = i;
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
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
