using System;

namespace EightQueensPuzzle
{
    public class EightQueensPuzzle
    {
        private const int Size = 8;

        static bool[,] chessboard = new bool[Size, Size];
        static bool[] blockedCols = new bool[Size];
        static bool[] blockedLeftDiagonals = new bool[(Size - 1) * 2 + 1];
        static bool[] blockedRightDiagonal = new bool[(Size - 1) * 2 + 1];

        private static int count = 0;

        static void Main()
        {
            Console.BufferHeight = 1000;
            PutQueens(0);
            Console.WriteLine(count);
        }

        private static void PutQueens(int row)
        {
            if (row >= Size)
            {
                PrintSolution();
                return;
            }

            for (int col = 0; col < Size; col++)
            {
                if (IsValidPosition(row, col))
                {
                    MarkBlockedPositions(row, col);
                    PutQueens(row + 1);
                    UnmarkBlockedPositions(row, col);
                }
            }
        }

        private static void UnmarkBlockedPositions(int row, int col)
        {
            blockedCols[col] = false;
            blockedLeftDiagonals[(col - row) + (Size - 1)] = false;
            blockedRightDiagonal[row + col] = false;
            chessboard[row, col] = false;
        }

        private static void MarkBlockedPositions(int row, int col)
        {
            blockedCols[col] = true;
            blockedLeftDiagonals[(col - row) + (Size - 1)] = true;
            blockedRightDiagonal[row + col] = true;
            chessboard[row, col] = true;
        }

        private static bool IsValidPosition(int row, int col)
        {
            return !blockedCols[col] &&
                   !blockedLeftDiagonals[(col - row) + (Size - 1)] &&
                   !blockedRightDiagonal[col + row];
        }

        private static void PrintSolution()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var symbol = chessboard[i, j] ? 'Q' : '-';
                    Console.Write(symbol + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            count++;
        }
    }
}
