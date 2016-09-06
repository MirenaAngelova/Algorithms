using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _05.Election
{
    public class Election
    {
        public static void Main()
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            var nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            var count = DynamicProgrammingSolution(nums, k);
            Console.WriteLine(count);
        }

        private static BigInteger DynamicProgrammingSolution(IEnumerable<int> nums, int k)
        {
            var combinations = new BigInteger[(100 * 1000) + 1];
            int maxSum = 0;
            combinations[0] = 1;

            foreach (var num in nums)
            {
                for (int i = maxSum; i >= 0; i--)
                {
                    if (combinations[i] > 0)
                    {
                        combinations[i + num] += combinations[i];
                        maxSum = Math.Max(maxSum, i + num);
                    }
                }
            }

            var numberOfSolutions = new BigInteger(0);
            for (int i = k; i <= maxSum; i++)
            {
                numberOfSolutions += combinations[i];
            }

            return numberOfSolutions;
        }
    }
}
