using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Sequences_of_Limited_Sum
{
    public class SequencesOfLimitedSum
    {
        private static int sum;
        private static int currentSum = 0;

        private static List<int> numbers;
        private static StringBuilder result; 

        public static void Main()
        {
            sum = int.Parse(Console.ReadLine());
            numbers = new List<int>();
            result = new StringBuilder();

            GeneratePermutations(0);
            Console.WriteLine(result);
        }

        private static void GeneratePermutations(int loopsCount)
        {
            if (currentSum <= sum && loopsCount > 0)
            {
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    result.Append($"{numbers[i]} ");
                }

                result.Append($"{numbers[numbers.Count - 1]}{Environment.NewLine}");
            }

            if (loopsCount <= sum)
            {
                for (int i = 1; i <= sum - currentSum; i++)
                {
                    currentSum += i;
                    numbers.Add(i);
                    GeneratePermutations(loopsCount + 1);
                    currentSum -= i;
                    numbers.RemoveAt(numbers.Count - 1);
                }
            }
        }
    }
}
