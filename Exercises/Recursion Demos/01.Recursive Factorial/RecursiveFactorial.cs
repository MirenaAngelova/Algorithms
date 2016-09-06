namespace Recursion_Demos
{
    using System;

    public class RecursiveFactorial
    {
        static void Main()
        {
            Console.Write("Enter n = ");
            int n = int.Parse(Console.ReadLine());

            decimal factorial = Factorial(n);
            Console.WriteLine($"{n}! = {factorial}");
        }

        private static decimal Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
