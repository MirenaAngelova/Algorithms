using System;
using System.Linq;

namespace _03.Generate_Combinations_Iteratively
{
    public class GenerateCombinationsIteratively
    {
        private static int[] source;

        private static int[] indices;

        private static int lastRequiredIndex;

        public static void Main(string[] args)
        {
            Console.Write("Input n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Input k: ");
            int k = int.Parse(Console.ReadLine());

            //source = new[] { "apple", "banana", "orange", "pear", "apricot" };
            source = Enumerable.Range(1, n).ToArray();
            indices = new int[k];

            lastRequiredIndex = k - 1;
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = i;
            }

            GenerateCombinations(n, k);
        }

        private static void GenerateCombinations(int totalElements, int requiredElements)
        {
            while (true)
            {
                Print();
                if (indices[0] + requiredElements == totalElements)
                {
                    break;
                }
                
                int currentDigit = requiredElements - 1;

                indices[currentDigit]++;
                while (indices[currentDigit] + (lastRequiredIndex - currentDigit) == totalElements)
                {
                    currentDigit--;
                    indices[currentDigit]++;
                }

                for (int i = currentDigit + 1; i < requiredElements; i++)
                {
                    indices[i] = indices[i - 1] + 1;
                }
            }
        }

        private static void Print()
        {
            for (int i = 0; i < indices.Length; i++)
            {
                Console.Write(source[indices[i]] + " ");
            }
            Console.WriteLine();
        }
    }
}

