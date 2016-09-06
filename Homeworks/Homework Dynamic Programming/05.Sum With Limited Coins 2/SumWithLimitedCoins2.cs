using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Sum_With_Limited_Coins_2
{
    public class SumWithLimitedCoins2
    {
        private static bool[] usedCoins;

        private static HashSet<string> combinations = new HashSet<string>();
        private static List<int> combination = new List<int>(); 

        static void Main()
        {
            int targetSum = int.Parse(Console.ReadLine().Substring(4));
            int[] coins = Console.ReadLine()
                .Substring(9)
                .Split(new[] {',', '}'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            usedCoins = new bool[coins.Length];
            FindCombinations(coins, combination, targetSum);
            foreach (var comb in combinations)
            {
                Console.WriteLine(string.Join(", ", comb));
            }
            Console.WriteLine(combinations.Count);
        }

        private static void FindCombinations(
            int[] coins, 
            List<int> combination, 
            int targetSum,
            int currentIndex = 0)
        {
            if (combination.Sum() == targetSum)
            {
                combinations.Add(string.Join(", ", combination));
            }
            else if (combination.Sum() < targetSum)
            {
                for (int i = currentIndex; i < coins.Length; i++)
                {
                    if (!usedCoins[i])
                    {
                        usedCoins[i] = true;
                        combination.Add(coins[i]);
                        FindCombinations(coins, combination, targetSum, i + 1);
                        combination.Remove(coins[i]);
                        usedCoins[i] = false;
                    }
                }
            }
        }
    }
}
