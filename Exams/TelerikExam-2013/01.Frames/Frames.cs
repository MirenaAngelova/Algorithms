using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Frames
{
    public class Frames
    {
        private static Frame[] frames;
        private static Frame[] sequence;
        private static List<string> output = new List<string>();
        private static bool[] used;

        private static HashSet<string> duplicates = new HashSet<string>();
        private static int sequencesCount;

        public static void Main()
        {
            ProcessInput();
            GenerateVariations(0);
            PrintOutput();
        }

        private static void PrintOutput()
        {
            Console.WriteLine(sequencesCount);

            output.Sort();
            Console.WriteLine(string.Join(Environment.NewLine, output));
        }

        private static void GenerateVariations(int currentIndex)
        {
            if (currentIndex >= frames.Length)
            {
                StoreFrames();
                return;
            }

            for (int index = 0; index < frames.Length; index++)
            {
                if (!used[index])
                {
                    used[index] = true;
                    sequence[currentIndex] = frames[index];
                    GenerateVariations(index + 1);

                    if (sequence[currentIndex].Left != sequence[currentIndex].Right)
                    {
                        int temp = sequence[currentIndex].Left;
                        sequence[currentIndex].Left = sequence[currentIndex].Right;
                        sequence[currentIndex].Right = temp;

                        GenerateVariations(index + 1);

                        temp = sequence[currentIndex].Left;
                        sequence[currentIndex].Left = sequence[currentIndex].Right;
                        sequence[currentIndex].Right = temp;
                    }

                    used[index] = false;
                }
            }
        }

        private static void StoreFrames()
        {
            string currentSequence = String.Join(" | ", (object[]) sequence);
            if (!duplicates.Contains(currentSequence))
            {
                sequencesCount++;
                duplicates.Add(currentSequence);
                output.Add(currentSequence);
            }
        }

        private static void ProcessInput()
        {
            string[] input;
            int framesCount = int.Parse(Console.ReadLine());
            frames = new Frame[framesCount];
            sequence = new Frame[framesCount];
            used = new bool[framesCount];

            for (int i = 0; i < framesCount; i++)
            {
                input = Console.ReadLine().Split();
                frames[i] = new Frame(int.Parse(input[0]), int.Parse(input[1]));
            }
        }
    }
}
