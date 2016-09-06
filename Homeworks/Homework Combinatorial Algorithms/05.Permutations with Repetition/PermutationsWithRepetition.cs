using System;

namespace _05.Permutations_with_Repetition
{
    public class PermutationsWithRepetition
    {
        private static int countOfPermutations = 0;
        static void Main()
        {
            Console.WriteLine("Input elements in a single line seperated by space");
            //string[] numbers = Console.ReadLine()
                //.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //string[] numbers = new[] { "1", "3", "5", "5" };
            int[] numbers = new []
            {
                1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5
            };

            Array.Sort(numbers);

            PermuteWithRepeatingElements(numbers);

            // P(1, 27) = ((1 + 27)!) / (1! * 27!) = 28;
            Console.WriteLine($"Count of permutations with repetition: {countOfPermutations}");
        }

        private static void PermuteWithRepeatingElements<T>(T[] elements) where T : IComparable<T>
        {
            while (true)
            {
                Print(elements);
                countOfPermutations++;

                int firstElement = elements.Length - 2;

                while (firstElement >= 0 && 
                    elements[firstElement].CompareTo(elements[firstElement + 1]) >= 0)
                {
                    firstElement--;
                }

                if (firstElement < 0)
                {
                    break;
                }

                int secondElement = elements.Length - 1;
                while (elements[secondElement].CompareTo(elements[firstElement]) < 0)
                {
                    secondElement--;
                }

                Swap(ref elements[firstElement], ref elements[secondElement]);

                ReverseArrayInPlace(elements, firstElement + 1, elements.Length - 1);
            }

        }

        private static void ReverseArrayInPlace<T>(T[] array, int start, int end)
        {
            while (start < end)
            {
                T temp = array[start];
                array[start] = array[end];
                array[end] = temp;
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

        private static void Print<T>(T[] elements)
        {
            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
