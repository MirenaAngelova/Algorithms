using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Sum_With_Limited_Coins
{
    public class SumWithLimitedCoins
    {
        private static int count = 0;
        private static int[] nums;

        private static List<int> combination = new List<int>();
        private static List<List<int>> combinations = new List<List<int>>();
         
        static void Main()
        {
            int targetSum = int.Parse(Console.ReadLine().Substring(4));
            nums = Console.ReadLine()
                .Substring(9)
                .Split(new[] {',', '}'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Array.Sort(nums);
            FindCombinations(targetSum, 0);
            Console.WriteLine(count);
        }

        private static void FindCombinations(int targetSum, int currentIndex)
        {
            if (targetSum == 0)
            {
                if (!Contains(combinations, combination))
                {
                    combinations.Add(new List<int>(combination));
                    count++;
                    Console.WriteLine($"{string.Join(", ", combination)}");
                }
            }
            else if (targetSum > 0)
            {
                for (int i = currentIndex; i < nums.Length; i++)
                {
                    targetSum -= nums[i];
                    combination.Add(nums[i]);
                    FindCombinations(targetSum, i + 1);
                    combination.Remove(nums[i]);
                    targetSum += nums[i];
                }
            }
        }

        private static bool Contains(List<List<int>> containingList, List<int> listToCheck)
        {
            foreach (var list in containingList)
            {
                if (list.SequenceEqual(listToCheck))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
