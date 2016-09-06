using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Connecting_Cables
{
    public class ConnectingCables
    {
        static void Main()
        {
            List<int> side1 = new List<int>();
            List<int> side2 = new List<int>();
            int[] array1 = Console.ReadLine()
                .Substring(9)
                .Split(new[] {',', '}'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            foreach (var arr in array1)
            {
                side1.Add(arr);
            }

            int[] array2 = Console.ReadLine()
                .Substring(9)
                .Split(new[] { ',', '}' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            foreach (var arr in array2)
            {
                side2.Add(arr);
            }

            int[,] field = new int[side1.Count, side2.Count];
            if (side1[0] == side2[0])
            {
                field[0, 0] = 1;
            }

            for (int col = 1; col < field.GetLength(1); col++)
            {
                var value = field[0, col - 1];
                if (side1[0] == side2[col])
                {
                    value++;
                }

                field[0, col] = value;
            }

            for (int row = 1; row < field.GetLength(0); row++)
            {
                var value = field[row - 1, 0];
                if (side1[row] == side2[0])
                {
                    value++;
                }

                field[row, 0] = value;
            }

            for (int row = 1; row < field.GetLength(0); row++)
            {
                for (int col = 1; col < field.GetLength(1); col++)
                {
                    var value = Math.Max(field[row - 1, col], field[row, col - 1]);
                    if (side1[row] == side2[col])
                    {
                        value++;
                    }

                    field[row, col] = value;
                }
            }

            var x = field.GetLength(0) - 1;
            var y = field.GetLength(1) - 1;
            var pairs = new List<int>();
            while (x  >= 0 && y >= 0)
            {
                if (side1[x] == side2[y])
                {
                    pairs.Add(side1[x]);
                    x--;
                    y--;
                }
                else if (field[x - 1, y] == field[x, y])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }
            pairs.Reverse();

            Console.WriteLine($"Maximum pairs connected: {field.Cast<int>().Max()}");
            Console.WriteLine($"Connected pairs: {string.Join(" ", pairs)}");
        }
    }
}
