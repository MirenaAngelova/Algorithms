using System;
using System.Linq;

namespace _04.Line_Inverter
{
    public class LineInverter
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool[,] board = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                string inputLine = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    if (inputLine[j] == 'W')
                    {
                        board[i, j] = true;
                    }
                }
            }

            int iterations = 0;
            int moves = n + n; // rows + cols
            while (true)
            {
                int[] rowsWhite = new int[n];
                int[] colsWhite = new int[n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (board[i, j])
                        {
                            rowsWhite[i]++;
                            colsWhite[j]++;
                        }
                    }
                }

                int maxRowWhite = rowsWhite.Max();
                int maxColWhite = colsWhite.Max();
                if (maxRowWhite == 0 && maxColWhite == 0)
                {
                    Console.WriteLine(iterations);
                    break;
                }

                if (maxRowWhite >= maxColWhite)
                {
                    int rowIndex = FindIndex(rowsWhite, maxRowWhite);
                    for (int i = 0; i < n; i++)
                    {
                        board[rowIndex, i] = !board[rowIndex, i];
                    }
                }
                else
                {
                    int colIndex = FindIndex(colsWhite, maxColWhite);
                    for (int i = 0; i < n; i++)
                    {
                        board[i, colIndex] = !board[i, colIndex];
                    }
                }

                iterations++;
                if (iterations >= moves)
                {
                    Console.WriteLine(-1);
                    break;
                }
            }
        }

        private static int FindIndex(int[] arrayWhite, int maxValue)
        {
            for (int i = 0; i < arrayWhite.Length; i++)
            {
                if (arrayWhite[i] == maxValue)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
