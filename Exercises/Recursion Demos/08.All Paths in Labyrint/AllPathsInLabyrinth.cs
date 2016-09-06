#define DEBUG_MODE

namespace _08.All_Paths_in_Labyrint
{
    using System;
    using System.Collections.Generic;
    
    public class AllPathsInLabyrinth
    {
        private static char[,] lab =
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'}
        };

        private static List<char> path = new List<char>();

        static void Main()
        {
            FindPathExit(0, 0, 'S');
        }

        private static void FindPathExit(int row, int col, char direction)
        {
            #if DEBUG_MODE
                PrintLabyrinth(row, col);
            #endif

            if (!IsInRange(row, col))
            {
                return;
            }

            path.Add(direction);
            if (lab[row, col] == 'e')
            {
                PrintPath(path);
            }

            if (lab[row, col] == ' ')
            {
                lab[row, col] = 's';

                FindPathExit(row, col - 1, 'L');
                FindPathExit(row - 1, col, 'U');
                FindPathExit(row, col + 1, 'R');
                FindPathExit(row + 1, col, 'D');

                lab[row, col] = ' ';
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath(List<char> path)
        {
            Console.Write("Found path to exit: ");
            Console.WriteLine(string.Join("", path));
            Console.WriteLine();
        }

        private static bool IsInRange(int row, int col)
        {
            bool isRowInRange = row >= 0 && row < lab.GetLength(0);
            bool isColInRange = col >= 0 && col < lab.GetLength(1);

            bool isInRange = isRowInRange && isColInRange;

            return isInRange;
        }

        private static void PrintLabyrinth(int currentRow, int currentCol)
        {
            for (int row = -1; row <= lab.GetLength(0); row++)
            {
                Console.WriteLine();
                for (int col = -1; col <= lab.GetLength(1); col++)
                {
                    if (row == currentRow && col == currentCol)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write('x');
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (!IsInRange(row, col))
                    {
                        Console.Write(' ');
                    }
                    else if (lab[row, col] == ' ')
                    {
                        Console.Write('-');
                    }
                    else 
                    {
                        Console.Write(lab[row, col]);   
                    }

                    Console.Write(' ');
                }
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
