namespace _09.Harmful_Recursion
{
    using System;

    public class RecursiveFibonacciSlow
    {
        static void Main()
        {
            Console.Write("Fibonacci(10) = ");
            decimal fib10 = Fibonacci(10);
            Console.WriteLine(fib10);

            Console.Write("Fibonacci(50) = ");
            decimal fib50 = Fibonacci(50);
            Console.WriteLine(fib50);
        }

        private static decimal Fibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n -2);
            }
        }
    }
}
