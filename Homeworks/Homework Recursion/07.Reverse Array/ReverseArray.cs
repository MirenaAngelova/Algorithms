using System;
using System.Linq;

namespace _07.Reverse_Array
{
    public class ReverseArray
    {
        private static int[] array;

        static void Main()
        {
            array = Console.ReadLine().Split().Select(a => int.Parse(a)).ToArray();

            RecursiveReversedArray(array.Length - 1);
        }

        private static void RecursiveReversedArray(int n)
        {
            if (n < array.Length / 2)
            {
                PrintArray(array);
            }
            else
            {
                Swap(ref array[n], ref array[array.Length - 1 - n]);
                RecursiveReversedArray(n - 1);
            } 
        }

        private static void Swap(ref int a1, ref int a2)
        {
            int previous = a1;
            a1 = a2;
            a2 = previous;
        }

        private static void PrintArray(int[] array)
        {
            Console.WriteLine($"({string.Join(", ", array)})");
        }
    }
}
