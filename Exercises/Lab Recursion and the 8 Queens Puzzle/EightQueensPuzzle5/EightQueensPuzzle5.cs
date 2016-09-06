using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensPuzzle5
{
    class EightQueensPuzzle5
    {
        private static int solutionsCount = 0;

        static void Main()
        {
            int size = 8;
            bool[,] chessboard = new bool[size, size];
            short[,] occupiedCells = new short[size, size];

            SolvePuzzle(chessboard, occupiedCells, 0);
            Console.WriteLine($"All distinct solutions are: {solutionsCount}");
        }

        private static void SolvePuzzle(bool[,] chessboard, short[,] occupiedCells, int currentCol)
        {
            if (currentCol == chessboard.GetLength(1))
            {
                solutionsCount++;
                PrintSolution(chessboard);
                return;
            }

            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                if (occupiedCells[row, currentCol] == 0)
                {
                    chessboard[row, currentCol] = true;
                    MarkOccupiedCells(occupiedCells, row, currentCol, 1);
                    SolvePuzzle(chessboard, occupiedCells, currentCol + 1);

                    chessboard[row, currentCol] = false;
                    MarkOccupiedCells(occupiedCells, row, currentCol, -1);
                }
            }
        }

        private static void MarkOccupiedCells(
            short[,] occupiedCells, int currentRow, int currentCol, short value)
        {
            for (int i = 0; i < occupiedCells.GetLength(0); i++)
            {
                occupiedCells[currentRow, i] += value;
                occupiedCells[i, currentCol] += value;

                if (currentRow + i < occupiedCells.GetLength(0) &&
                    currentCol + i < occupiedCells.GetLength(1))
                {
                    occupiedCells[currentRow + i, currentCol + i] += value;
                }

                if (currentRow - i >= 0 &&
                    currentCol + i < occupiedCells.GetLength(1))
                {
                    occupiedCells[currentRow - i, currentCol + i] += value;
                }
            }
        }

        private static void PrintSolution(bool[,] chessboard)
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    Console.Write("{0} ", chessboard[i, j] ? 'Q' : '-');
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
