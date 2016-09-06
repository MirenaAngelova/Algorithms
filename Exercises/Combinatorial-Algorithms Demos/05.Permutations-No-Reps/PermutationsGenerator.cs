using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Permutations_No_Reps
{
    public class PermutationsGenerator
    {
        static void Main()
        {
            string[] array = {"apple", "banana", "orange"};
            GeneratePermutation(array, 0);
        }

        private static void GeneratePermutation<T>(T[] array, int k)
        {
            if (k >= array.Length)
            {
                PrintPermutation(array);
            }
            else
            {
                GeneratePermutation<T>(array, k + 1);
                for (int i = k + 1; i < array.Length; i++)
                {
                    Swap(ref array[k], ref array[i]);
                    GeneratePermutation<T>(array, k + 1);
                    Swap(ref array[k], ref array[i]);
                }
            }
        }

        private static void Swap<T>(ref T p1, ref T p2)
        {
            T previous = p1;
            p1 = p2;
            p2 = previous;
        }

        private static void PrintPermutation<T>(T[] array)
        {
            Console.WriteLine($"{string.Join(", ", array)}");
        }
    }
}
