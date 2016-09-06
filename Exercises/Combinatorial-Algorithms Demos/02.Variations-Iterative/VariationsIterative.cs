using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Variations_Iterative
{
    public class VariationsIterative
    {
        static void Main()
        {
            int n = 5;
            int k = 3;
            int[] array = new int[k];
            while (true)
            {
                PrintVariation(array);
                int digitIndex = k - 1;
                while (digitIndex >= 0 && array[digitIndex] == n -1)
                {
                    digitIndex--;
                }

                if (digitIndex < 0)
                {
                    break;
                }

                array[digitIndex]++;
                for (int i = digitIndex + 1; i < k; i++)
                {
                    array[i] = 0;
                }
            }
        }

        private static void PrintVariation(int[] array)
        {
            Console.WriteLine($"({string.Join(", ", array)})");
        }
    }
}
