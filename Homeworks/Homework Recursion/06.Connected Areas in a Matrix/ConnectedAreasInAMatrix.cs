using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Connected_Areas_in_a_Matrix
{
    public class ConnectedAreasInAMatrix
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

        private static List<Area> areas = new List<Area>();

        static void Main()
        {
            FindTraversed();
            areas.Sort((a, b) => a.CompareTo(b));

            Console.WriteLine($"Total areas found: {areas.Count}");
            for (int num = 0; num < areas.Count; num++)
            {
                areas[num].Display(num + 1);
            }
        }

        private static void FindTraversed()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ' &&
                        (row == 0 || matrix[row - 1, col] != ' ') &&
                        (col == 0 || matrix[row, col -1] != ' '))
                    {
                        areas.Add(new Area(row, col));
                        ExploreArea(row, col);
                    }
                }
            }
        }

        private static void ExploreArea(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] != ' ')
            {
                return;
            }

            matrix[row, col] = 'x';
            areas.Last().IncreaseSize();

            ExploreArea(row, col + 1);// r
            ExploreArea(row + 1, col);// d
            ExploreArea(row, col - 1);// l
            ExploreArea(row - 1, col);// u
        }
    }
}
