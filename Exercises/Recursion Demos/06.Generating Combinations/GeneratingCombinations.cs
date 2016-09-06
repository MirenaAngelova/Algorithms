using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Generating_Combinations
{
    public class GeneratingCombinations
    {
        static void Main()
        {
            int n = 3;
            int startNum = 4;
            int endNum = 8;
             
            int[] array = new int[n];
            GeneratingComb(array, 0, startNum, endNum);
        }

        private static void GeneratingComb(int[] array, int index, int startNum, int endNum)
        {
            if (index >= array.Length)
            {
                PrintNumber(array);
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    array[index] = i;
                    GeneratingComb(array, index + 1, i + 1, endNum);
                }
            }
        }

        private static void PrintNumber(int[] array)
        {
            Console.WriteLine("(" + string.Join(", ", array) + ")");
        }
    }
}
