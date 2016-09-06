using System;

namespace _07.Words
{
    public class Words
    {
        private static char[] letters;

        private static long counter;

        public static void Main()
        {
            letters = Console.ReadLine().ToCharArray();
            counter = 0;
            // int count;
            // List<int> counts = new List<int>();
            Array.Sort(letters);

            //for (int i = 0; i < letters.Length - 1; i++)
            //{
            //    count = 1;
            //    int j = i;
            //    while (j < letters.Length - 1 && letters[i].CompareTo(letters[j + 1]) == 0)
            //    {
            //        count++;
            //        j++;
            //    }
            //    if (j == letters.Length - 2)
            //    {
            //        counts.Add(count);
            //    }
            //    i = j;
            //    counts.Add(count);
            //}

            //if (letters.Length == counts.Count)
            //{
            //    counter = IterativeFactorial(letters.Length);
            //    Console.WriteLine(counter);
            //    return;
            //}

            PermuteWithRepeatingElements(letters);
            Console.WriteLine(counter);

        }

        //private static long IterativeFactorial(int length)
        //{
        //    long factorial = 1;
        //    for (int i = 1; i <= length; i++)
        //    {
        //        factorial *= i;
        //    }

        //    return factorial;
        //}

        // finds the unique permutations in lexicographical order of a sorted sequence
        private static void PermuteWithRepeatingElements(char[] letters)
        {
            while (true)
            {
                if (IsCorrect(letters))
                {
                    counter++;
                }

                int firstElement = letters.Length - 2;

                while (firstElement >= 0 && 
                    letters[firstElement].CompareTo(letters[firstElement + 1]) >= 0)
                {
                    firstElement--;
                }

                if (firstElement < 0)
                {
                    break;
                }

                int secondElement = letters.Length - 1;
                while (firstElement < secondElement && 
                    letters[firstElement].CompareTo(letters[secondElement]) >= 0)
                {
                    secondElement--;
                }

                Swap(ref letters[firstElement], ref letters[secondElement]);

                ReverseArrayInPlace(letters, firstElement + 1, letters.Length - 1);
            }

        }

        private static void ReverseArrayInPlace<T>(T[] letters, int start, int end)
        {
            while (start < end)
            {
                T temp = letters[start];
                letters[start] = letters[end];
                letters[end] = temp;
                start++;
                end--;
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private static bool IsCorrect(char[] letters)
        {
            for (int i = 1; i < letters.Length; i++)
            {
                if (letters[i] == letters[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
