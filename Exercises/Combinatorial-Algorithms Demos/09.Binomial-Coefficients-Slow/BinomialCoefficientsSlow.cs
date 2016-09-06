using System;

namespace _09.Binomial_Coefficients_Slow
{
    public class BinomialCoefficientsSlow
    {
        static void Main()
        {
            Console.WriteLine("C(2, 4) = " + Binomial(4, 2));
            Console.WriteLine("C(4, 10) = " + Binomial(10, 4));
            Console.WriteLine("C(7, 13) = " + Binomial(13, 7));
            Console.WriteLine("C(13, 26) = " + Binomial(26, 13));
            Console.WriteLine("C(12, 30) = " + Binomial(30, 12));
        }

        private static int Binomial(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            return Binomial(n - 1, k - 1) + Binomial(n - 1, k);
        }
    }
}
