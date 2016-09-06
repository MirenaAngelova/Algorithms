using System;

namespace _10.Binomial_Coefficient_Fast
{
    public class BinomialCoefficientFast
    {
        private const int Max = 100;
        private static decimal[,] binomialCoefficient = new decimal[Max, Max];

        static void Main()
        {
            Console.WriteLine("C(2, 4) = " + Binomial(4, 2));
            Console.WriteLine("C(4, 10) = " + Binomial(10, 4));
            Console.WriteLine("C(7, 13) = " + Binomial(13, 7));
            Console.WriteLine("C(13, 26) = " + Binomial(26, 13));
            Console.WriteLine("C(12, 30) = " + Binomial(30, 12));
            Console.WriteLine("C(22, 50) = " + Binomial(50, 22));
            Console.WriteLine("C(25, 70) = " + Binomial(70, 25));
        }

        private static decimal Binomial(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            if (binomialCoefficient[n, k] == 0)
            {
                binomialCoefficient[n, k] = Binomial(n - 1, k - 1) + Binomial(n - 1, k);
            }

            return binomialCoefficient[n , k];
        }
    }
}
