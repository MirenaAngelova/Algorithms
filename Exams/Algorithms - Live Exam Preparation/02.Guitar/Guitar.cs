using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Guitar
{
    public class Guitar
    {
        static void Main()
        {
            string[] inputLine = Console.ReadLine()
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);

            int initialVolume = int.Parse(Console.ReadLine());
            int highestVolume = int.Parse(Console.ReadLine());

            int[] volume = new int[inputLine.Length];
            for (int i = 0; i < volume.Length; i++)
            {
                volume[i] = int.Parse(inputLine[i]);
            }

            int[,] changeVolume = new int[volume.Length + 1, highestVolume + 1];
            changeVolume[0, initialVolume] = 1;
            for (int i = 1; i < volume.Length + 1; i++)
            {
                for (int j = 0; j < highestVolume + 1; j++)
                {
                    if (changeVolume[i -1, j] == 1)
                    {
                        int x = volume[i - 1];
                        if (j - x >= 0)
                        {
                            changeVolume[i, j - x] = 1;
                        }

                        if (j + x <= highestVolume)
                        {
                            changeVolume[i, j + x] = 1;
                        }
                    }
                }
            }

            
            for (int i = highestVolume; i >= 0; i--)
            {
                if (changeVolume[volume.Length, i] == 1)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine(-1);
        }
    }
}
