using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensPuzzle6
{
    class EightQueensPuzzle6
    {
        private static int solutions = 0;

        static void Main()
        {
            int size = 8;
            Enumerate(size);
            Console.WriteLine(solutions);
        }

        private static void Enumerate(int size)
        {
           int[] array = new int[size];
            Enumerate(array, 0);
        }

        private static void Enumerate(int[] queens, int n)
        {
            int length = queens.Length;
            if (n == length)
            {
                PrintQueens(queens);
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    queens[n] = i;
                    if (IsConsistent(queens, n))
                    {
                        Enumerate(queens, n + 1);
                    }
                }
            }
        }

        private static bool IsConsistent(int[] queens, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (queens[i] == queens[n])
                {
                    return false;
                }

                if (queens[i] - queens[n] == n - i)
                {
                    return false;
                }

                if (queens[n] - queens[i] == n - i)
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintQueens(int[] queens)
        {
            int length = queens.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (queens[i] == j)
                    {
                        Console.Write("Q ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            solutions++;
        }
    }
}
