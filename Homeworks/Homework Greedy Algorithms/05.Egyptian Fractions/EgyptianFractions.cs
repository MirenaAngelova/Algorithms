using System;
using System.Collections.Generic;

namespace _05.Egyptian_Fractions
{
    public class EgyptianFractions
    {
        public static void Main()
        {
            string[] parameters = Console.ReadLine()
                .Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            long numerator = long.Parse(parameters[0]);
            long denominator = long.Parse(parameters[1]);

            if (numerator / denominator >= 1)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
            }

            //GreedySolution(numerator, denominator);
            OptimizedSolution(numerator, denominator);
        }

        private static void OptimizedSolution(long numerator, long denominator)
        {
            long currentNumerator = numerator;
            long currentDenominator = denominator;
            List<Fraction> fractions = new List<Fraction>();

            while (currentNumerator > 0)
            {
                long currentFraction = (long) Math.Ceiling(currentDenominator/(double) currentNumerator);
                fractions.Add(new Fraction(currentFraction));
                currentNumerator = currentNumerator*currentFraction - currentDenominator;
                currentDenominator *= currentFraction;
            }

            Console.WriteLine($"{numerator}/{denominator} = {string.Join(" + ", fractions)}");
        }

        private static void GreedySolution(long numerator, long denominator)
        {
            long currentNumerator = numerator;
            long currentDenominator = denominator;
            long currentFraction = 2;
            List<Fraction> fractions = new List<Fraction>();

            while (currentNumerator > 0)
            {
                long fractionNumerator = currentDenominator;
                long tempNumerator = currentNumerator*currentFraction;

                if (fractionNumerator > tempNumerator)
                {
                    currentFraction++;
                    continue;
                }

                fractions.Add(new Fraction(currentFraction));
                currentNumerator = tempNumerator - fractionNumerator;
                currentDenominator *= currentFraction;
            }

            Console.WriteLine($"{numerator}/{denominator} = {string.Join(" + ", fractions)}");
        }
    }
}
