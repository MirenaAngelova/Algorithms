using System;
using System.Linq;

namespace _02.Generate_Permutations_Iteratively
{
    public class GeneratePermutationsIteratively
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbersArray = Enumerable.Range(1, n).ToArray();
            var controlArray = Enumerable.Range(0, n + 1).ToArray();

            int index = 1;
            int j;
            int countOfPermutations = 1;
            Console.WriteLine($"{string.Join(", ", numbersArray)}");

            while (index < n)
            {
                controlArray[index]--;
                j = index%2*controlArray[index];
                Swap(ref numbersArray[j], ref numbersArray[index]);

                index = 1;
                while (controlArray[index] == 0)
                {
                    controlArray[index] = index;
                    index++;
                }

                countOfPermutations++;
                Console.WriteLine($"{string.Join(", ", numbersArray)}");
            }

            Console.WriteLine($"Total permutations: {countOfPermutations}");
        }

        private static void Swap(ref int p1, ref int p2)
        {
            p1 ^= p2;
            p2 ^= p1;
            p1 ^= p2;
        }
    }
}
