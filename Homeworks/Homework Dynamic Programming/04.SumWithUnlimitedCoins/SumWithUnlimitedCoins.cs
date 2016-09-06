using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SumWithUnlimitedCoins
{
    public class SumWithUnlimitedCoins
    {
        private static int count = 0;
        private static int[] coins;

        private static List<int> combinations = new List<int>();

        static void Main()
        {
            int sum = int.Parse(Console.ReadLine().Substring(4));
            int initialSum = sum;
            string numbers = Console.ReadLine().Substring(9);
            int[] coins = numbers
                .Split(new[] { ',', '}' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            FindCombinations(coins, initialSum, sum, 0);
            Console.WriteLine(count);
        }

        private static void FindCombinations(int[] coins, int initialSum, int sum, int index)
        {
            if (sum == 0)
            {
                count++;
                combinations.Reverse();
                Console.WriteLine($"{initialSum} = {string.Join(" + ", combinations)}");
            }
            else if (sum > 0)
            {
                for (int i = index; i < coins.Length; i++)
                {
                    sum -= coins[i];
                    combinations.Add(coins[i]);
                    FindCombinations(coins, initialSum, sum, i);
                    combinations.Remove(coins[i]);
                    sum += coins[i];
                }
            }
        }
    }
}
