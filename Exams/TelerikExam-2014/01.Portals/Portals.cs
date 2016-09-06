using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Portals
{
    public class Portals
    {
        private const int ResultNotFount = -1;
        private static int[,] matrix;
        private static bool[,] taken;
        private static int coordX;
        private static int coordY;

        public static void Main()
        {
            ProcessInput();
           int  maxPower = FindMaxPower(coordX, coordY);

            Console.WriteLine(maxPower);
        }

        private static int FindMaxPower(int row, int col)
        {
            if (!AreValidCoord(row, col) || matrix[row, col] == ResultNotFount || taken[row, col])
            {
                return 0;
            }

            int currentPower = matrix[row, col];
            int currentMaxPower = 0;
            taken[row, col] = true;

            currentMaxPower = Math.Max(currentMaxPower, FindMaxPower(row, col + currentPower));
            currentMaxPower = Math.Max(currentMaxPower, FindMaxPower(row + currentPower, col));
            currentMaxPower = Math.Max(currentMaxPower, FindMaxPower(row, col - currentPower));
            currentMaxPower = Math.Max(currentMaxPower, FindMaxPower(row - currentPower, col));

            taken[row, col] = false;
            if (IsValidEndpoint(row, col, currentPower))
            {
                return currentMaxPower + currentPower;
            }
            else
            {
                return 0;
            }
            
        }

        private static bool IsValidEndpoint(int row, int col, int currentPower)
        {
            if (AreValidCoord(row, col + currentPower) && matrix[row, col + currentPower] != ResultNotFount)
            {
                return true;
            }

            if (AreValidCoord(row + currentPower, col) && matrix[row+ currentPower, col ] != ResultNotFount)
            {
                return true;
            }

            if (AreValidCoord(row, col - currentPower) && matrix[row, col - currentPower] != ResultNotFount)
            {
                return true;
            }

            if (AreValidCoord(row - currentPower, col) && matrix[row - currentPower, col] != ResultNotFount)
            {
                return true;
            }

            return false;
        }

        private static bool AreValidCoord(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        private static void ProcessInput()
        {
            string[] input = Console.ReadLine().Split();
            coordX = int.Parse(input[0]);
            coordY = int.Parse(input[1]);

            input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            matrix = new int[rows, cols];
            taken = new bool[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                input = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col] != "#" ? int.Parse(input[col]) : ResultNotFount;
                }
            }
        }
    }
}
