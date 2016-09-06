using System;
using Wintellect.PowerCollections;

namespace _06.Connected_Areas_in_Matrix_2
{
    public class ConnectedAreasInMatrix2
    {
        private static char[,] matrix =
       {
            {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
            {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
            {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' '}
        };

        //private static char[,] matrix =
        //{
        //    {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        //    {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        //    {'*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' '},
        //    {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        //    {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        //};

        private static int currentAreaSize = 0;

        // SortedSet<areaSize, Tuple<row, col>>
        private static OrderedBag<Area> connectedAreas = 
            new OrderedBag<Area>(new DescendingComparer<Area>());

        static void Main()
        {
            FindConnectedAreas();
            PrintMatrix();
            PrintFoundAreas();
        }

        private static void PrintFoundAreas()
        {
            Console.WriteLine($"Total areas found: {connectedAreas.Count}");

            int count = 1;
            foreach (var connectedArea in connectedAreas)
            {
                Console.WriteLine(
                    $"Area #{count} at ({connectedArea.Row}, {connectedArea.Col}), " +
                    $"size: {connectedArea.Size}");
                count++;
            }
        }

        private static void PrintMatrix()
        {
            Console.WriteLine(new string('^', matrix.GetLength(1) + 2));
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write('|');
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);   
                }

                Console.WriteLine('|');
            }

            Console.WriteLine(new string('^', matrix.GetLength(1) + 2));
        }

        private static void FindConnectedAreas()
        {
            TraverseAndMarkConnectedCells();
            ClearMarkedPositions();
        }

        private static void ClearMarkedPositions()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'x')
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void TraverseAndMarkConnectedCells()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        MarkConnectedArea(row, col);
                        connectedAreas.Add(new Area()
                        {
                            Row = row,
                            Col = col,
                            Size = currentAreaSize
                        });

                        currentAreaSize = 0;
                    }
                }
            }
        }

        private static void MarkConnectedArea(int row, int col)
        {
            if (!IsValidPosition(row, col))
            {
                return;
            }

            if (matrix[row, col] != ' ')
            {
                return;
            }

            currentAreaSize++;
            matrix[row, col] = 'x';

            MarkConnectedArea(row, col + 1); // r
            MarkConnectedArea(row + 1, col); // d
            MarkConnectedArea(row, col - 1); // l
            MarkConnectedArea(row - 1, col); // u
        }

        private static bool IsValidPosition(int row, int col)
        {
            bool isValidRowPosition = row >= 0 && row < matrix.GetLength(0);
            bool isValidColPosition = col >= 0 && col < matrix.GetLength(1);

            bool isValidPosition = isValidRowPosition && isValidColPosition;

            return isValidPosition;
        }
    }
}
