using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Dividing_Presents
{
    public class DividingPresents
    {
        static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int totalSum = nums.Sum();
            int targetSum = totalSum/2;
            Dictionary<int, int> possibleSums = CalculatePossibleSums(nums, targetSum);

            int alansSum = possibleSums
                .OrderByDescending(s => s.Key)
                .First()
                .Key;
            int bobsSum = totalSum - alansSum;
            int difference = bobsSum - alansSum;

            IEnumerable<int> targetSubset = FindTargetSubset(possibleSums);

            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Alan:{alansSum} Bob:{bobsSum}");
            Console.WriteLine($"Alan takes: {string.Join(" ", targetSubset)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static IEnumerable<int> FindTargetSubset(Dictionary<int, int> possibleSums)
        {
            List<int> subset = new List<int>();
            int targetSum = possibleSums
                .OrderByDescending(s => s.Key)
                .First()
                .Key;
            while (targetSum > 0)
            {
                int lastNum = possibleSums[targetSum];
                subset.Add(lastNum);
                targetSum = targetSum - lastNum;
            }

            subset.Reverse();
            return subset;
        }

        private static Dictionary<int, int> CalculatePossibleSums(int[] nums, int targetSum)
        {
            Dictionary<int, int> possibleSums = new Dictionary<int, int>();
            possibleSums.Add(0, 0);

            for (int i = 0; i < nums.Length; i++)
            {
                Dictionary<int, int> newSums = new Dictionary<int, int>();
                foreach (var sum in possibleSums.Keys)
                {
                    int newSum = sum + nums[i];
                    if (!possibleSums.ContainsKey(newSum) && newSum <= targetSum)
                    {
                        newSums.Add(newSum, nums[i]);
                    }
                }

                foreach (var sum in newSums)
                {
                    possibleSums.Add(sum.Key, sum.Value);
                }
            }

            return possibleSums;
        }
    }
}
