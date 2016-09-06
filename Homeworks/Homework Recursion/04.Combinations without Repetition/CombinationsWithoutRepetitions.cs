using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Combinations_without_Repetition
{
    public class CombinationsWithoutRepetitions
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] combination = new int[k];
            GenerateCombinations(combination, n, 0, 1);
        }

        private static void GenerateCombinations(int[] combination, int n, int index, int startIndex)
        {
            if (index >= combination.Length)
            {
                PrintCombination(combination);
                return;
            }

            for (int i = startIndex; i <= n; i++)
            {
                combination[index] = i;
                GenerateCombinations(combination, n, index + 1, i + 1);
            }
        }

        private static void PrintCombination(int[] combination)
        {
            Console.WriteLine($"{string.Join(", ", combination)}");
        }
    }
}
