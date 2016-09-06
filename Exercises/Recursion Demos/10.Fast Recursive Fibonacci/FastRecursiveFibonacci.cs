namespace _10.Fast_Recursive_Fibonacci
{
    using System;

    public class FastRecursiveFibonacci
    {
        private const int MaxFibonacciSequenceMember = 1000;
        private static decimal[] fib = new decimal[MaxFibonacciSequenceMember];

        private static decimal recursiveCallsCounter = 0;

        static void Main()
        {
            int number = 100;
            decimal fibonacci = Fibonacci(number);
            Console.WriteLine($"Fibonacci({number}) = {fibonacci}");
            Console.WriteLine($"Recursive calls = {recursiveCallsCounter}");
        }

        private static decimal Fibonacci(int n)
        {
            recursiveCallsCounter++;
            if (fib[n] == 0)
            {
                if ((n == 1) || (n == 2))
                {
                    fib[n] = 1;
                }
                else
                {
                    fib[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
                }
            }

            return fib[n];
        }
    }
}
