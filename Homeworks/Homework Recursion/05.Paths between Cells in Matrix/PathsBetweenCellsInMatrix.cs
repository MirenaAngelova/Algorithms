using System.Collections.Generic;

namespace _05.Paths_between_Cells_in_Matrix
{
    using System;

    public class PathsBetweenCellsInMatrix
    {
        private static char[,] lab =
        {
            {'s', ' ', ' ', ' '},
            {' ', '*', '*', ' '},
            {' ', '*', '*', ' '},
            {' ', '*', 'e', ' '},
            { ' ', ' ', ' ', ' '}
        };

        //static char[,] lab =
        //{
        //    {'s', ' ', ' ', ' ', ' ', ' '},
        //    {' ', '*', '*', ' ', '*', ' '},
        //    {' ', '*', '*', ' ', '*', ' '},
        //    {' ', '*', '*', ' ', '*', ' '},
        //    {' ', '*', 'e', ' ', ' ', ' '},
        //    {' ', ' ', ' ', '*', ' ', ' '},
        //};

        //private static char[,] lab =
        //{
        //    {'s', ' ', ' ', '*', ' ', ' ', ' '},
        //    {'*', '*', ' ', '*', ' ', '*', ' '},
        //    {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //    {' ', '*', '*', '*', '*', '*', ' '},
        //    {' ', ' ', ' ', ' ', ' ', ' ', 'e'}
        //};

        private static List<char> path = new List<char>();

        private static int totalPathsFound = 0;

        private static void Main()
        {
            FindPathToSymbol(0, 0, 'S');
            if (totalPathsFound != 0)
            {
                Console.WriteLine($"Total paths found: {totalPathsFound}");
            }
        }

        private static void FindPathToSymbol(int row, int col, char direction)
        {
            if (!IsInRange(row, col))
            {
                return;
            }

            if (lab[row, col] == 'e')
            {
                PrintLabyrinth(direction);
                totalPathsFound++;
                return;
            }

            if (lab[row, col] != ' ' && lab[row, col] != 's')
            {
                return;
            }

            lab[row, col] = 'x';
            bool isAdded = false;

            if (row > 0 || col > 0)
            {
                path.Add(direction);
                isAdded = true;
            }

            FindPathToSymbol(row, col + 1, 'R');
            FindPathToSymbol(row + 1, col, 'D');
            FindPathToSymbol(row, col - 1, 'L');
            FindPathToSymbol(row - 1, col, 'U');

            lab[row, col] = ' ';
            if (isAdded)
            {
                path.RemoveAt(path.Count - 1);
            }

        }

        private static void PrintLabyrinth(char lastDirection)
        {
            Console.WriteLine(string.Join("", path) + lastDirection);
        }

        private static bool IsInRange(int row, int col)
        {
            bool isRowInRange = row >= 0 && row < lab.GetLength(0);
            bool isColInRange = col >= 0 && col < lab.GetLength(1);

            bool isInRange = isRowInRange && isColInRange;

            return isInRange;
        }
    }
}
