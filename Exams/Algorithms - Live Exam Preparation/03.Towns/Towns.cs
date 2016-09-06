using System;

namespace _03.Towns
{
    public class Towns
    {
        static void Main()
        {
            // Test with hard-coded input
             Console.WriteLine(FindLongestPath(new[] { 1, 2, 4, 1, 5, 1 }));

            // Generate tests
             new TestsGenerator().GenerateTests();

            int numberOfTowns = int.Parse(Console.ReadLine());
            int[] citizens = new int[numberOfTowns];
            for (int i = 0; i < numberOfTowns; i++)
            {
                string[] input = Console.ReadLine().Split();
                citizens[i] = int.Parse(input[0]);
            }

            int maxLongestPath = FindLongestPath(citizens);
            Console.WriteLine(maxLongestPath);
        }

        private static int FindLongestPath(int[] citizens)
        {
            var longestPathAscending = new int[citizens.Length];
            for (int currentTown = 0; currentTown < longestPathAscending.Length; currentTown++)
            {
                longestPathAscending[currentTown] = 1;
                for (int previousTown = 0; previousTown < currentTown; previousTown++)
                {
                    if (citizens[currentTown] > citizens[previousTown])
                    {
                        longestPathAscending[currentTown] =
                            Math.Max(longestPathAscending[currentTown], 
                            longestPathAscending[previousTown] + 1);
                    }
                }
            }

            var longestPathDescending = new int[citizens.Length];
            for (int currentTown = longestPathDescending.Length - 1; currentTown >= 0; currentTown--)
            {
                longestPathDescending[currentTown] = 1;
                for (int previousTown = longestPathDescending.Length - 1; previousTown > currentTown; previousTown--)
                {
                    if (citizens[currentTown] > citizens[previousTown])
                    {
                        longestPathDescending[currentTown] =
                            Math.Max(longestPathDescending[currentTown],
                                longestPathDescending[previousTown] + 1);
                    }
                }
            }

            int maxPath = 0;
            for (int currentTown = 0; currentTown < longestPathAscending.Length; currentTown++)
            {
                int currentPath = longestPathAscending[currentTown] +
                                  longestPathDescending[currentTown] - 1;
                maxPath = Math.Max(currentPath, maxPath);
            }

            return maxPath;
        }
    }
}
