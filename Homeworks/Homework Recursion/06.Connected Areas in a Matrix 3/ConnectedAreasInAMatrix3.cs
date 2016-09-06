using System;
using Wintellect.PowerCollections;

namespace _06.Connected_Areas_in_a_Matrix_3
{
    public class ConnectedAreasInAMatrix3
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

        private static OrderedSet<ConnectedArea> connectedAreas = new OrderedSet<ConnectedArea>();

        private static int size = 0;
        private static bool[,] traversed;
        
        static void Main()
        {
            traversed = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            FindNextTraversableCell();
            PrintAreas();
        }

        private static void PrintAreas()
        {
            Console.WriteLine($"Total areas found: {connectedAreas.Count}");
            for (int i = 0; i < connectedAreas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({connectedAreas[i].X}, {connectedAreas[i].Y})," +
                                  $" size: {connectedAreas[i].Size}");
            }
        }

        private static void FindNextTraversableCell()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (!traversed[row, col])
                    {
                        if (matrix[row, col] != ' ')
                        {
                            traversed[row, col] = true;
                        }
                        else
                        {
                            TraverseMatrix(row, col);
                            ConnectedArea area = new ConnectedArea(row, col, size);
                            connectedAreas.Add(area);
                            size = 0;
                        }
                    }
                }
            }
        }

        private static void TraverseMatrix(int row, int col)
        {
            if (!IsInMatrix(row, col))
            {
                return;
            }

            if (traversed[row, col])
            {
                return;
            }

            if (matrix[row, col] != ' ')
            {
                traversed[row, col] = true;
                return;
            }

            traversed[row, col] = true;
            size++;

            TraverseMatrix(row, col - 1); // l
            TraverseMatrix(row - 1, col); // u
            TraverseMatrix(row, col + 1); // r
            TraverseMatrix(row + 1, col); // d
        }

        private static bool IsInMatrix(int row, int col)
        {
            bool isRowInMatrix = row >= 0 && row < matrix.GetLength(0);
            bool isColInMatrix = col >= 0 && col < matrix.GetLength(1);

            bool isInMatrix = isRowInMatrix && isColInMatrix;

            return isInMatrix;
        }
    }
}
