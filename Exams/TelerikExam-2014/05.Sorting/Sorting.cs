using System;
using System.Collections.Generic;

namespace _05.Sorting
{
    public class Sorting
    {
        private static HashSet<string> duplicates = new HashSet<string>();

        private static string initialNumbers;
        private static string expectedNumbers;
        private static int reverseCount;

        public static void Main()
        {
            ProcessInput();
            SortListOfNumbers();
        }

        private static void SortListOfNumbers()
        {

            Queue<Operation> operationQueue = new Queue<Operation>();

            Operation operation = new Operation()
            {
                Numbers = initialNumbers,
                Steps = 0
            };

            operationQueue.Enqueue(operation);
            duplicates.Add(initialNumbers);

            while (operationQueue.Count > 0)
            {
                Operation currentOperation = operationQueue.Dequeue();
                if (IsSorted(currentOperation.Numbers))
                {
                    PrintNumberOfOperations(currentOperation.Steps);
                    return;
                }

                string[] currentNumbers = currentOperation.Numbers.Split();
                for (int i = 0; i <= currentNumbers.Length - reverseCount; i++)
                {
                    ReverseNumbers(currentNumbers, i, i + reverseCount - 1);
                    string numbers = String.Join(" ", currentNumbers);
                    if (!duplicates.Contains(numbers))
                    {
                        duplicates.Add(numbers);
                        operationQueue.Enqueue(
                            new Operation()
                            {
                                Numbers = numbers,
                                Steps = currentOperation.Steps + 1
                            });
                    }

                    ReverseNumbers(currentNumbers, i, i + reverseCount - 1);
                }
            }

            PrintNumberOfOperations(-1);
        }

        private static void ReverseNumbers(string[] currentNumbers, int start, int end)
        {
            int endIndex = end;
            for (int i = start; i <= (start + end) / 2; i++)
            {
                if (currentNumbers[i] != currentNumbers[endIndex])
                {
                    string temp = currentNumbers[i];
                    currentNumbers[i] = currentNumbers[endIndex];
                    currentNumbers[endIndex] = temp;
                }

                endIndex--;
            }
            
        }

        private static void PrintNumberOfOperations(int steps)
        {
            Console.WriteLine(steps);
        }

        private static void ProcessInput()
        {
            Console.ReadLine();
            initialNumbers = Console.ReadLine();
            string[] numbers = initialNumbers.Split();
            Array.Sort(numbers);

            expectedNumbers = String.Join(" ", numbers);

            reverseCount = int.Parse(Console.ReadLine());
        }

        private static bool IsSorted(string initialNumbers)
        {
            return initialNumbers == expectedNumbers;
        }
    }
}
