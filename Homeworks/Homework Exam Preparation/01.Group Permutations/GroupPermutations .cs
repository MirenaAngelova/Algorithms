using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _01.Group_Permutations
{
    public class GroupPermutations
    {
        private static Dictionary<char, int> lettersCount;
        private static StringBuilder result;
         
        static void Main()
        {
            string words = Console.ReadLine();
            lettersCount = new Dictionary<char, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (!lettersCount.ContainsKey(words[i]))
                {
                    lettersCount.Add(words[i], 0);
                }

                lettersCount[words[i]]++;
            }

            char[] uniqueWords = words.ToCharArray().Distinct().ToArray();
            GeneratePermutation(uniqueWords, 0);
        }

        private static void GeneratePermutation(char[] uniqueWords, int currentIndex)
        {
            if (currentIndex == uniqueWords.Length - 1)
            {
                Print(uniqueWords);
            }
            else
            {
                for (int i = currentIndex; i < uniqueWords.Length; i++)
                {
                    Swap(ref uniqueWords[i], ref uniqueWords[currentIndex]);
                    GeneratePermutation(uniqueWords, currentIndex + 1);
                    Swap(ref uniqueWords[i], ref uniqueWords[currentIndex]);
                }   
            }
        }

        private static void Swap(ref char ch1, ref char ch2)
        {
            if (ch1 == ch2)
            {
                return;
            }

            char old = ch1;
            ch1 = ch2;
            ch2 = old;
        }

        private static void Print(char[] uniqueWord)
        {
            result = new StringBuilder();
            for (int i = 0; i < uniqueWord.Length; i++)
            {
                result.Append(new string(uniqueWord[i], lettersCount[uniqueWord[i]]));
            }

            Console.WriteLine(result);
        }
    }
}
