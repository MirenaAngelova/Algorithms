using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Permutations_Repetitions
{
    public class PermutationsGeneratorWithReps
    {
        static void Main()
        {
            int[] array = {3, 5, 1, 5, 5};
            Array.Sort(array);
            GeneratePermutationsWithReps(array, 0, array.Length - 1);
        }

        private static void GeneratePermutationsWithReps(int[] array, int start, int end)
        {
            PrintPermutation(array);
            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (array[left] != array[right])
                    {
                        Swap(ref array[left], ref array[right]);
                        GeneratePermutationsWithReps(array, left + 1, end);
                    }
                }

                int firstElement = array[left];
                for (int i = left; i <= end - 1; i++)
                {
                    array[i] = array[i + 1];
                }

                array[end] = firstElement;
            }
        }

        private static void Swap(ref int p1, ref int p2)
        {
            int previous = p1;
            p1 = p2;
            p2 = previous;
        }

        private static void PrintPermutation(int[] array)
        {
            Console.WriteLine($"{string.Join(", ", array)}");
        }
    }
}
