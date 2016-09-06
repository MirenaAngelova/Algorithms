using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Tower_of_Hanoi
{
    public class TowerOfHanoi
    {
        private static Stack<int> source;

        private static Stack<int> destination = new Stack<int>();

        private static Stack<int> spare = new Stack<int>();

        private static int stepsTaken;

        private static void Main()
        {
            Console.Write("Enter number of disks: ");
            int numberOfDisks = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());

            PrintRods();
            MoveDisks(source.Count, source, destination, spare);
            CheckSolution(destination, numberOfDisks);

            Console.WriteLine($"Steps taken are: {stepsTaken} = 2 ^ {numberOfDisks} - 1");
        }

        private static void CheckSolution(Stack<int> destination, int numberOfDisks)
        {
            if (destination.Count != numberOfDisks)
            {
                throw new ArgumentException("Invalid solution!");
            }

            var arr = destination.ToArray();
            for (int i = 0; i < numberOfDisks; i++)
            {
                if (arr[i] != i + 1)
                {
                    throw new ArgumentException("Invalid solution!");
                }
            }
        }

        private static void MoveDisks(
            int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                stepsTaken++;
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{stepsTaken}: Moved disk {bottomDisk}");
                PrintRods();
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);
                stepsTaken++;
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{stepsTaken}: Moved disk {bottomDisk}");
                PrintRods();
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }
    }
}

