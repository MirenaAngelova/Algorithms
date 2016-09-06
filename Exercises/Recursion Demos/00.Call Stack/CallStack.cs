using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Call_Stack
{
    class CallStack
    {
        static void Main()
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var primes = PrimesInRange(start, end);

            Console.WriteLine(string.Join(" ", primes));
        }

        static List<int> PrimesInRange(int start, int end)
        {
            var primes = new List<int>();
            for (int primeCandidate = start; primeCandidate <= end; primeCandidate++)
            {
                if (IsPrime(primeCandidate))
                {
                    primes.Add(primeCandidate);
                }
            }

            return primes;
        }

        static bool IsPrime(int num)
        {
            var maxDivider = Math.Sqrt(num);
            for (int divider = 2; divider <= maxDivider; divider++)
            {
                if (num % divider == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
