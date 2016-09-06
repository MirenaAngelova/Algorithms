using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Non_Crossing_Bridges
{
    public  class NonCrossingBridges
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bridges = new int[numbers.Length];
            bool[] used = new bool[numbers.Length];

            for (int i = 1; i < numbers.Length; i++)
            {
                bridges[i] = bridges[i - 1];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (numbers[i] == numbers[j])
                    {
                        if (bridges[i] < bridges[j] + 1)
                        {
                            bridges[i] = bridges[j] + 1;
                            used[i] = true;
                            used[j] = true;
                        }
                    }
                }
            }

            int foundBridges = bridges[bridges.Length - 1];
            if (foundBridges == 0)
            {
                Console.WriteLine("No bridges found");
            }
            else if(foundBridges == 1)
            {
                Console.WriteLine("1 bridge found");
            }
            else
            {
                Console.WriteLine($"{foundBridges} bridges found");
            }

            StringBuilder exit = new StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (used[i])
                {
                    exit.Append(numbers[i]);
                }
                else
                {
                    exit.Append("X");
                }

                exit.Append(" ");
            }

            Console.WriteLine(exit.ToString());
        }
    }
}
