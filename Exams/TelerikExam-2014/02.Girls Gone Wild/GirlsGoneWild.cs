using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Girls_Gone_Wild
{
    public class GirlsGoneWild
    {
        private const int SkirtsMaxCount = 26;// 31

        private static SortedSet<char> skirts = new SortedSet<char>();
        private static bool[] takenShirts;
        private static int[] skirtsQuantity = new int[SkirtsMaxCount];

        private static int[] shirtsSequence;
        private static char[] skirtsSequence;

        private static int shirtsCount;
        private static int girlsCount;
        private static int variationsCount;

        private static StringBuilder output = new StringBuilder();

        public static void Main()
        {
            ProcessInput();
            GeneratePossibleDressUp(0, 0);
            PrintOutput();
        }

        private static void PrintOutput()
        {
            Console.WriteLine(variationsCount);
            Console.Write(output.ToString());
        }

        private static void GeneratePossibleDressUp(int girlIndex, int shirtIndex)
        {
            if (girlIndex >= girlsCount)
            {
                StoreCurrentSequence();
                return;
            }

            for (int i = shirtIndex; i < shirtsCount; i++)
            {
                if (takenShirts[i])
                {
                    continue;
                }

                takenShirts[i] = true;
                shirtsSequence[girlIndex] = i;

                foreach (var skirt in skirts)
                {
                    if (skirtsQuantity[skirt - 'a'] > 0)
                    {
                        skirtsSequence[girlIndex] = skirt;
                        skirtsQuantity[skirt - 'a']--;

                        GeneratePossibleDressUp(girlIndex + 1, i + 1);
                        skirtsQuantity[skirt - 'a']++;
                    }
                }

                takenShirts[i] = false;
            }
        }

        private static void StoreCurrentSequence()
        {
            for (int index = 0; index < girlsCount; index++)
            {
                output.Append($"{shirtsSequence[index]}{skirtsSequence[index]}");
                if (index != girlsCount - 1)
                {
                    output.Append("-");
                }
            }

            output.AppendLine();
            variationsCount++;
        }

        private static void ProcessInput()
        {
            shirtsCount = int.Parse(Console.ReadLine());
            takenShirts = new bool[shirtsCount];

            string inputSkirts = Console.ReadLine();
            girlsCount = int.Parse(Console.ReadLine());
            shirtsSequence = new int[girlsCount];
            skirtsSequence = new char[girlsCount];

            for (int index = 0; index < inputSkirts.Length; index++)
            {
                skirts.Add(inputSkirts[index]);
                skirtsQuantity[inputSkirts[index] - 'a']++;
            }
        }
    }
}
