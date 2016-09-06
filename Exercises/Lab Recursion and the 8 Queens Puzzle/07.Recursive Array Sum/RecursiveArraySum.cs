using System;
using System.Linq;

namespace _07.Recursive_Array_Sum
{
    public class RecursiveArraySum
    {
        private static double[] array;
        private static double sum;

        static void Main()
        {
            array = Console.ReadLine().Split().Select(a => double.Parse(a)).ToArray();
            double sum = RecursiveSum(0);
            PrintSum(sum);
        }

        private static double RecursiveSum(int index)
        {
            if (index >= array.Length)
            {
                return 0;
            }
            else
            {
                return array[index] + RecursiveSum(index + 1);
            }
        }

        private static void PrintSum(double sum)
        {
            Console.WriteLine($"The sum of all elements in an array is: {sum:F5}");
        }
    }
}
