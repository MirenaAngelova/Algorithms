namespace EightQueensPuzzle4
{
    using System;

    public class EightQueensPuzzle4
    {
        private const int Size = 8;
        private static int[] queens = new int[Size];
        private static bool[] cols = new bool[Size];
        private static bool[] mainDiagonal = new bool[Size * 2];
        private static bool[] antiDiagonal = new bool[Size * 2];

        static void Main()
        {
            PutQueens(0);
        }

        private static void PutQueens(int row)
        {
            for (int col = 0; col < Size; col++)
            {
                if (!cols[col] && !mainDiagonal[row + col] && !antiDiagonal[row - col + Size])
                {
                    queens[row] = col;
                    cols[col] = mainDiagonal[row + col] = antiDiagonal[row - col + Size] = true;

                    if (row == Size - 1)
                    {
                        Print();
                        return;
                    }
                    else
                    {
                        PutQueens(row + 1);
                    }

                    cols[col] = mainDiagonal[row + col] = antiDiagonal[row - col + Size] = false;
                }
            }
        }

        private static void Print()
        {
            Console.Clear();
            for (int row = 0; row < Size; row++)
            {
                int queensCol = queens[row];
                for (int col = 0; col < Size; col++)
                {
                    Console.BackgroundColor = 
                        ((row + col)%2 == 0) ? ConsoleColor.Magenta : Console.BackgroundColor;
                    Console.ForegroundColor = 
                        ((row + col)%2 == 0) ? ConsoleColor.DarkMagenta : Console.ForegroundColor;

                    Console.Write(col == queensCol ? 'Q' : ' ');
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}
