using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Shortest_Path_2
{
    public class ShortestPath2
    {
        private const int DirectionsCount = 3;

        private static string map;
        private static char[] directions = {'L', 'R', 'S'};
        private static int[] sequence;
        private static StringBuilder output = new StringBuilder();

        private static int k;
        private static int variationsCount;

        public static void Main()
        {
            ProcessInput();
            GenerateVariations(0);
            PrintOutput();
        }

        private static void PrintOutput()
        {
            Console.WriteLine(variationsCount);
            Console.WriteLine(output.ToString());
        }

        private static void GenerateVariations(int currentIndex)
        {
            if (currentIndex >= k)
            {
                variationsCount++;
                PrintCurrentMap();
                return;
            }

            for (int directionIndex = 0; directionIndex < DirectionsCount; directionIndex++)
            {
                sequence[currentIndex] = directionIndex;
                GenerateVariations(currentIndex + 1);
            }
        }

        private static void PrintCurrentMap()
        {
            int sequenceIndex = 0;
            for (int index = 0; index < map.Length; index++)
            {
                if (map[index] != '*')
                {
                    output.Append(map[index]);
                }
                else
                {
                    output.Append(directions[sequence[sequenceIndex]]);
                    sequenceIndex++;
                }
            }

            output.AppendLine();
        }

        private static void ProcessInput()
        {
            map = Console.ReadLine();
            for (int index = 0; index < map.Length; index++)
            {
                if (map[index] == '*')
                {
                    k++;
                }
            }

            sequence = new int[k];
        }
    }
}
