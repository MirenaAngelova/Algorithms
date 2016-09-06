using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Longest_Zigzag_Subsequence
{
    public class LongestZigzagSubsequence
    {
        private static int maxLength = 0;
        private static int lastIndex = -1;

        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            int[] longestZigZagSubsequence = FindSubsequence(numbers);

            Console.WriteLine($"{string.Join(" ", longestZigZagSubsequence)}");
        }

        private static int[] FindSubsequence(int[] numbers)
        {
            int[] oddEvenLength = new int[numbers.Length]; // odd, EVEN, odd, EVEN,.... = small, BIG, small,...
            int[] oddEvenBacktrack = new int[numbers.Length]; // indices of predecessor of numbers[i]
            int[] evenOddLength = new int[numbers.Length]; // ODD, even, ODD, even,... = BIG, small,....
            int[] evenOddBacktrack = new int[numbers.Length]; // indices of predecessor of numbers[i]

            bool evenOddIsSmaller = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                oddEvenLength[i] = 1;
                oddEvenBacktrack[i] = -1;
                evenOddLength[i] = 1;
                evenOddBacktrack[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (oddEvenLength[j] + 1 > oddEvenLength[i])
                    {
                        if (oddEvenLength[j] % 2 == 0 && numbers[j] > numbers[i] ||
                            oddEvenLength[j] % 2 == 1 && numbers[j] < numbers[i])
                        {
                            oddEvenLength[i] = oddEvenLength[j] + 1;
                            oddEvenBacktrack[i] = j;
                        }
                    }

                    if (evenOddLength[j] + 1 > evenOddLength[i])
                    {
                        if (evenOddLength[j] % 2 == 0 && numbers[j] < numbers[i] ||
                            evenOddLength[j] % 2 == 1 && numbers[j] > numbers[i])
                        {
                            evenOddLength[i] = evenOddLength[j] + 1;
                            evenOddBacktrack[i] = j;
                        }
                    }
                }

                if (oddEvenLength[i] > maxLength)
                {
                    evenOddIsSmaller = false;
                    maxLength = oddEvenLength[i];
                    lastIndex = i;
                }

                if (evenOddLength[i] > maxLength)
                {
                    evenOddIsSmaller = true;
                    maxLength = evenOddLength[i];
                    lastIndex = i;
                }
            }

            var list = new List<int>();
            ReconstructSequence(list, evenOddIsSmaller ? evenOddBacktrack : oddEvenBacktrack, numbers);
            list.Reverse();

            return list.ToArray();
        }

        private static void ReconstructSequence(List<int> list, int[] backtrack, int[] numbers)
        {
            while (lastIndex != -1)
            {
                list.Add(numbers[lastIndex]);
                lastIndex = backtrack[lastIndex];
            }
        }
    }
}
