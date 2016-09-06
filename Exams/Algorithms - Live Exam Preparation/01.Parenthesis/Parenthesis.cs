using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Parenthesis
{
    public class Parenthesis
    {
        private static readonly StringBuilder result = new StringBuilder();
        private static int openingCount;
        private static int closingCount;
        private static char[] parenthesis;
        private static int n;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            parenthesis = new char[n * 2];
            parenthesis[0] = '(';
            openingCount++;

            GenerateParenthesis(1);
            Console.WriteLine(result.ToString());
        }

        private static void GenerateParenthesis(int index)
        {
            if (index == parenthesis.Length)
            {
                result.AppendLine(string.Join("", parenthesis));
                return;
            }

            if (openingCount < n)
            {
                parenthesis[index] = '(';
                openingCount++;
                GenerateParenthesis(index + 1);
                openingCount--;
            }

            if (closingCount < openingCount)
            {
                parenthesis[index] = ')';
                closingCount++;
                GenerateParenthesis(index + 1);
                closingCount--;
            }
        }
    }
}
