namespace _07.Paths_in_Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class PathsInLabyrinth
    {
        private static char[,] lab =
       {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'}
        };

        private static List<Tuple<int, int>> paths = new List<Tuple<int, int>>();

        static void Main()
        {
            //int size = 10;
            //lab = new char[size, size];

            //for (int row = 0; row < size; row++)
            //{
            //    for (int col = 0; col < size; col++)
            //    {
            //        lab[row, col] = ' ';
            //    }
            //}

            //lab[size - 1, size - 1] = 'e';

            FindPathExit(0, 0);
        }

        private static void FindPathExit(int row, int col)
        {
            if (!IsInRange(row, col))
            {
                return;
            }

            if (lab[row, col] == 'e')
            {
                PrintPaths(row, col);
            }

            if (lab[row, col] != ' ')
            {
                return;
            }

            lab[row, col] = 's';
            paths.Add(new Tuple<int, int>(row, col));

            FindPathExit(row, col - 1); // left -> Order is very important. "Left" should be first.
            FindPathExit(row - 1, col); // up
            FindPathExit(row, col + 1); // right
            FindPathExit(row + 1, col); // down
            
            lab[row, col] = ' ';
            paths.RemoveAt(paths.Count - 1);
        }

        private static void PrintPaths(int finalRow, int finalCol)
        {
            Console.WriteLine("Found exit:");
            foreach (var path in paths)
            {
                Console.Write($"({path.Item1},{path.Item2}) -> ");
            }

            Console.WriteLine($"({finalRow},{finalCol})");
            Console.WriteLine();
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
