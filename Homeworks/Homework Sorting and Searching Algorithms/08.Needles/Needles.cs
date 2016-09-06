using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Needles
{
    public class Needles
    {
        static void Main()
        {
            string tokens = Console.ReadLine();
            int[] sortedSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] needles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < needles.Length; i++)
            {
                int zeroes = 0;
                bool isFound = false;
                for (int j = 0; j < sortedSequence.Length; j++)
                {
                    if (needles[i] <= sortedSequence[j])
                    {
                        Console.Write(j - zeroes + " ");
                        isFound = true;
                        break;
                    }

                    if (sortedSequence[j] == 0)
                    {
                        zeroes++;
                    }
                    else
                    {
                        zeroes = 0;
                    }
                }
                if (!isFound)
                {
                    Console.Write(sortedSequence.Length - zeroes + " ");
                }
            }
        }
    }
}
