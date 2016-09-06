using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Permutations
{
    public class PermutationsWithoutRepetitions
    {
        private static int n;
        private static int[] array = new int[n];
        private static int countOfPermutations = 0;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            array = Enumerable.Range(1, n).ToArray();
            GeneratePermutation(0);
            PrintCountOfPermutations(countOfPermutations);
        }

        private static void PrintCountOfPermutations(int countOfpermutations)
        {
            Console.WriteLine($"Total permutations: {countOfpermutations}");
        }

        private static void GeneratePermutation(int startIndex)
        {
            if (startIndex >= array.Length - 1)
            {
                PrintArray();
                countOfPermutations++;
            }
            else
            {
                for (int i = startIndex; i <= array.Length - 1; i++)
                {
                    Swap(ref array[startIndex], ref array[i]);
                    GeneratePermutation(startIndex + 1);
                    Swap(ref array[startIndex], ref array[i]);
                }
            }
        }

        private static void Swap(ref int p1, ref int p2)
        {
            if (p1 == p2)
            {
                return;
            }

            p1 ^= p2;
            p2 ^= p1;
            p1 ^= p2;
        }

        private static void PrintArray()
        {
            Console.WriteLine($"({string.Join(", ", array)})");
        }
    }
}
