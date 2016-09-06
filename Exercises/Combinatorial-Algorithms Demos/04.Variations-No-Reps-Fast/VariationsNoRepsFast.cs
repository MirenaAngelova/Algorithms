using System;

namespace _04.Variations_No_Reps_Fast
{
    public class VariationsNoRepsFast
    {
        private const int k = 3;
        private const int n = 4;

        private static int[] array = new int[k];
        private static int[] free = new int[n] {1, 2, 3, 4};

        static void Main()
        {
            GenerateVariationsNoRepetitionsFast(0);
        }

        private static void GenerateVariationsNoRepetitionsFast(int index)
        {
            if (index >= k)
            {
                PrintVariation();
            }
            else
            {
                for (int i = index; i < n; i++)
                {
                    array[index] = free[i];
                    Swap(ref free[i], ref free[index]);
                    GenerateVariationsNoRepetitionsFast(index + 1);
                    Swap(ref free[i], ref free[index]);
                }
            }
        }

        private static void Swap(ref int v1, ref int v2)
        {
            int previous = v1;
            v1 = v2;
            v2 = previous;
        }

        private static void PrintVariation()
        {
            Console.WriteLine($"({string.Join(", ", array)})");
        }
    }
}
