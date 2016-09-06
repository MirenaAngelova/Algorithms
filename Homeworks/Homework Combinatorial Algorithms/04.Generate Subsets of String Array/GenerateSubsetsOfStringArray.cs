using System;

namespace _04.Generate_Subsets_of_String_Array
{
    public class GenerateSubsetsOfStringArray
    {
        private static string[] words;

        private static int subsets;

        private static string[] result;

        public static void Main(string[] args)
        {
            Console.WriteLine("Input strings on the same line seperated by comas:");
            words = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            //words = new string[] { "test", "rock", "fun" };
            Console.WriteLine("Input length of the subset:");
            subsets = int.Parse(Console.ReadLine());
            result = new string[subsets];
            Permute(words, 0, 0);

        }

        private static void Permute(string[] elements, int currentLoop, int currentIndex)
        {
            if (currentLoop == subsets)
            {
                Print();
            }
            else
            {
                for (int i = currentIndex; i < elements.Length; i++)
                {
                    result[currentLoop] = elements[i];
                    Permute(elements, currentLoop + 1, i + 1);
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine($"({string.Join(" ", result)})");
        }
    }
}
