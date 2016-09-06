using System;

namespace _04.Towns
{
    public class Towns
    {
        private static string[] towns;
        private static int[] populations;
        private static int[] ascOrderLength;
        private static int[] descOrderLength;

        private static int maxPathLength;

        public static void Main()
        {
            ProcessInput();
            FindMaxPath();
            PrintOutput();
        }

        private static void PrintOutput()
        {
            Console.WriteLine(maxPathLength);
        }

        private static void FindMaxPath()
        {
            for (int currentTown = 0; currentTown < towns.Length; currentTown++)
            {
                for (int prevTown = 0; prevTown < currentTown; prevTown++)
                {
                    if (populations[currentTown] > populations[prevTown] && 
                        ascOrderLength[currentTown] <= ascOrderLength[prevTown])
                    {
                        ascOrderLength[currentTown] = ascOrderLength[prevTown] + 1;
                    }

                    if (populations[currentTown] < populations[prevTown])
                    {
                        descOrderLength[currentTown] = Math.Max(
                            Math.Max(ascOrderLength[prevTown], descOrderLength[prevTown]) + 1,
                            descOrderLength[currentTown]);
                    }
                }

                CheckMaxPathLength(ascOrderLength[currentTown]);
                CheckMaxPathLength(descOrderLength[currentTown]);
            }
        }

        private static void CheckMaxPathLength(int length)
        {
            if (length > maxPathLength)
            {
                maxPathLength = length;
            }
        }

        private static void ProcessInput()
        {
            int townsCount = int.Parse(Console.ReadLine());
            InitializeData(townsCount);

            for (int i = 0; i < townsCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                towns[i] = input[1];
                populations[i] = int.Parse(input[0]);
            }
        }

        private static void InitializeData(int townsCount)
        {
            towns = new string[townsCount];
            populations = new int[townsCount];
            ascOrderLength = new int[townsCount];
            descOrderLength = new int[townsCount];

            for (int i = 0; i < townsCount; i++)
            {
                ascOrderLength[i] = 1;
                descOrderLength[i] = 1;
            }
        }
    }
}
