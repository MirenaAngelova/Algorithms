using System;

namespace EightQueensPuzzle2
{
    public class EightQueensPuzzle2
    {
        private static int solutionsCount;

        static void Main()
        {
            solutionsCount = 0;
            int size = 8;
            int[,] chessboard = new int[size, size];
            PutQueens(chessboard, 0);
            Console.WriteLine($"Number of solutions for board with size {size} is: {solutionsCount}");
        }

        private static void PutQueens(int[,] chessboard, int col)
        {
            if (col == chessboard.GetLength(1))
            {
                solutionsCount++;
                return;
            }

            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                if (chessboard[row, col] == 0)
                {
                    MarkChessboard(chessboard, row, col, true);
                    PutQueens(chessboard, col + 1);
                    MarkChessboard(chessboard, row, col, false);
                }
            }
        }

        private static void MarkChessboard(int[,] chessboard, int row, int col, bool value)
        {
            for (int i = col; i < chessboard.GetLength(1); i++)
            {
                chessboard[row, i] += value ? 1 : -1;

                if (row + i - col < chessboard.GetLength(0))
                {
                    chessboard[row + i - col, i] += value ? 1 : -1;
                }

                if (row - i + col >= 0)
                {
                    chessboard[row - i + col, i] += value ? 1 : -1;
                }
            }
        }
    }
}
