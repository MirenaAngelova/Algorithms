using System;

namespace _12.Gray_Code
{
    class GrayCode
    {
        private const int n = 4;
        private static int[] array = new int[n];

        static void Main()
        {
            ForwardGray(n - 1);
        }

        private static void ForwardGray(int k)
        {
            if (k < 0)
            {
                PrintArray();
            }
            else
            {
                array[k] = 0;
                ForwardGray(k - 1);
                array[k] = 1;
                BackwardGray(k - 1);
            }
        }

        private static void BackwardGray(int k)
        {
            if (k < 0)
            {
                PrintArray();
            }
            else
            {
                array[k] = 1;
                ForwardGray(k - 1);
                array[k] = 0;
                BackwardGray(k - 1);
            }
        }

        private static void PrintArray()
        {
            Console.WriteLine($"({string.Join(", ", array)})");
        }
    }
}
