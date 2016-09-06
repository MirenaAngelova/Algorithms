namespace _02.Factorial_Performance
{
    using System;

    public class FactorialPerformance
    {
        static void Main()
        {
            var startTime = DateTime.Now;
            for (int i = 0; i < 10000000; i++)
            {
                decimal factorial = RecursiveFactorial(15);
            }

            var endTime = DateTime.Now;
            Console.WriteLine($"Recursive factorial time: {endTime - startTime}");

            startTime = DateTime.Now;
            for (int i = 0; i < 10000000; i++)
            {
                decimal factorial = IterativeFactorial(15);
            }

            endTime = DateTime.Now;
            Console.WriteLine($"Iterative factorial time: {endTime - startTime}");
        }

        private static long IterativeFactorial(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        private static long RecursiveFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n*RecursiveFactorial(n - 1);
            }
        }
    }
}
