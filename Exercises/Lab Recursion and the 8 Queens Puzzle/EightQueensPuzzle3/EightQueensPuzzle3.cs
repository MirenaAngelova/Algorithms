using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensPuzzle3
{
    public class EightQueensPuzzle3
    {
        private const int Size = 8;

        static readonly bool[,] chessboard = new bool[Size, Size];
        static readonly HashSet<int> blockedRows = new HashSet<int>();
        static readonly HashSet<int> blockedCols = new HashSet<int>();
        static readonly HashSet<int> blockedLeftDiagonals = new HashSet<int>();
        static readonly HashSet<int> blockedRightDiagonals = new HashSet<int>();

        private static int foundSolutions = 0;

        static void Main()
        {
            PutQueens(0);
            Console.WriteLine($"Found solutions = {foundSolutions}");
        }

        private static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();

                return;
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkBlockedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkBlockedPositions(row, col);
                    }
                }
            }
        }

        private static void UnmarkBlockedPositions(int row, int col)
        {
            blockedRows.Remove(row);
            blockedCols.Remove(col);
            blockedLeftDiagonals.Remove(col - row);
            blockedRightDiagonals.Remove(row + col);
            chessboard[row, col] = false;
        }

        private static void MarkBlockedPositions(int row, int col)
        {
            blockedRows.Add(row);
            blockedCols.Add(col);
            blockedLeftDiagonals.Add(col - row);
            blockedRightDiagonals.Add(row + col);
            chessboard[row, col] = true;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            if (blockedRows.Contains(row) ||
                blockedCols.Contains(col) ||
                blockedLeftDiagonals.Contains(col - row) ||
                blockedRightDiagonals.Contains(row + col))
            {
                return false;
            }

            return true;
        }

        private static void PrintSolution()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (chessboard[i, j])
                    {
                        Console.Write('Q');
                    }
                    else
                    {
                        Console.Write('-');
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            foundSolutions++;
        }
    }
}
