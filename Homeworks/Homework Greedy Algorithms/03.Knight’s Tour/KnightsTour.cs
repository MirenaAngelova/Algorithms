using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Knight_s_Tour
{
    public class KnightsTour
    {
        private static readonly int[] RowChanges = {1, -1, 2, 1, -1, -2, 2, -2};
        private static readonly int[] ColChanges = { 2, 2, 1, -2, -2, 1, -1, -1 };

        private static int[,] matrix;
        private static int size;
        private static int currentMove;

        public static void Main()
        {
            size = int.Parse(Console.ReadLine());
            matrix = new int[size, size];

            matrix[0, 0] = 1;
            currentMove = 2;

            int row = 0;
            int col = 0;
            int roof = size*size;
            while (currentMove <= roof)
            {
                int minRow = 0;
                int minCol = 0;
                int min = int.MaxValue;

                for (int i = 0; i < RowChanges.Length; i++)
                {
                    int currentMin = GetMoves(row + RowChanges[i], col + ColChanges[i]);
                    if (currentMin < min)
                    {
                        min = currentMin;
                        minRow = row + RowChanges[i];
                        minCol = col + ColChanges[i];
                    }
                }

                row = minRow;
                col = minCol;
                matrix[row, col] = currentMove;
                currentMove++;
            }

            Print();
        }

        private static void Print()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{matrix[i, j], 5}");
                }

                Console.WriteLine();
            }
        }

        private static int GetMoves(int row, int col)
        {
            if (!IsViableLocation(row, col))
            {
                return int.MaxValue;
            }

            int moves = 0;
            for (int i = 0; i < RowChanges.Length; i++)
            {
                if (IsViableLocation(row + RowChanges[i], col + ColChanges[i]))
                {
                    moves++;
                }
            }

            return moves;
        }

        private static bool IsViableLocation(int row, int col)
        {
            if (row < 0 || row >= size || col < 0 || col >= size)
            {
                return false;
            }

            if (matrix[row, col] != 0)
            {
                return false;
            }

            return true;
        }
    }
}
