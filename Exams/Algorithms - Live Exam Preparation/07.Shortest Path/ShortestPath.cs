using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Shortest_Path
{
    public class ShortestPath
    {
        private static SortedSet<string> results = new SortedSet<string>();
        private static char[] map;

        static void Main()
        {
            string bitsString = Console.ReadLine();
            map = bitsString.ToCharArray();
            Solve(0);
            var output = new StringBuilder();
            output.AppendLine(results.Count.ToString());
            foreach (var result in results)
            {
                output.AppendLine(result);
            }

            Console.WriteLine(output.ToString());
        }

        private static void Solve(int index)
        {
            if (index == map.Length)
            {
                results.Add(new string(map));
                return;
            }
            else if (map[index] != '*')
            {
                Solve(index + 1);
            }
            else
            {
                map[index] = 'R';
                Solve(index + 1);
                map[index] = 'L';
                Solve(index + 1);
                map[index] = 'S';
                Solve(index + 1);
                map[index] = '*';
            }
        }
    }
}
