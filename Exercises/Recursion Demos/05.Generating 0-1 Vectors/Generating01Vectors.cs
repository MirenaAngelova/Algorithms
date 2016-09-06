using System;

namespace _05.Generating_0_1_Vectors
{
    public class Generating01Vectors
    {
        static void Main()
        {
            Console.Write("Enter n = ");
            int n = int.Parse(Console.ReadLine());

            int[] vector = new int[n];
            GeneratingVectors(n - 1, vector);
        }

        private static void GeneratingVectors(int index, int[] vector)
        {
            if (index < 0)
            {
                PrintVector(vector);
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    GeneratingVectors(index - 1, vector);
                }
            }
        }

        private static void PrintVector(int[] vector)
        {
            foreach (var i in vector)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }
    }
}
