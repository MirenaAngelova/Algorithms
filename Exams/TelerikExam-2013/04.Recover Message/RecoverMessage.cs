using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Recover_Message
{
    public class RecoverMessage
    {
        private const int InvalidValue = -1;
        private const int SmallLettersOffset = 'a' - 'A';
        private const int TotalLettersLength = SmallLettersOffset * 2;

        private static List<Vertex> vertices = new List<Vertex>();
        private static int[] lettersOccurences = new int[TotalLettersLength];
        private static bool[] usedLetters = new bool[TotalLettersLength];

        private static int usedLettersCount;

        public static void Main()
        {
            ProcessInput();
            PrintGraph();
            FindShortestPossibleMessage();
        }

        private static void PrintGraph()
        {
            for (int cnt = 0; cnt < vertices.Count; cnt++)
            {
                Vertex vertex = vertices[cnt];
                Console.WriteLine(
                    $"ParentsCnt: {vertex.ParentsCount}, " +
                    $"Character: {vertex.Character}, " +
                    $"Children: {string.Join(", ", vertex.Children)}");
            }
        }

        private static void FindShortestPossibleMessage()
        {
            while (usedLettersCount < vertices.Count)
            {
                int smallestIndex = InvalidValue;
                int smallestCharValue = 'z' + 1;
                for (int index = 0; index < vertices.Count; index++)
                {
                    int charIndex = GetCharIndex(vertices[index].Character);
                    if (vertices[index].ParentsCount == 0 && !usedLetters[charIndex])
                    {
                        if (vertices[index].Character < smallestCharValue)
                        {
                            smallestCharValue = vertices[index].Character;
                            smallestIndex = index;
                        }
                    }
                }

                if (smallestIndex != InvalidValue)
                {
                    Console.Write((char)smallestCharValue);

                    Vertex vertex = vertices[smallestIndex];

                    int charIndex = GetCharIndex(vertex.Character);
                    usedLetters[charIndex] = true;
                    usedLettersCount++;
                    foreach (var childIndex in vertex.Children)
                    {
                        vertices[childIndex].ParentsCount--;
                    }
                }
                else
                {
                    return;
                }
            }

            Console.WriteLine();
        }

        private static void ProcessInput()
        {
            InitializeData();

            int numberOfMessages = int.Parse(Console.ReadLine());
            string message;
            for (int currentMessage = 0; currentMessage < numberOfMessages; currentMessage++)
            {
                message = Console.ReadLine();
                for (int ch = 0; ch < message.Length; ch++)
                {
                    int index = GetCharIndex(message[ch]);
                    int parentIndex = InvalidValue;
                    if (ch - 1 >= 0)
                    {
                        parentIndex = GetCharIndex(message[ch - 1]);
                    }

                    Vertex vertex;
                    if (lettersOccurences[index] == InvalidValue)
                    {
                        vertex = new Vertex()
                        {
                            Character = message[ch],
                            Children = new List<int>(),
                            ParentsCount = 0
                        };

                        vertices.Add(vertex);
                        lettersOccurences[index] = vertices.Count - 1;
                    }
                    else
                    {
                        vertex = vertices[lettersOccurences[index]];
                    }

                    if (parentIndex != InvalidValue)
                    {
                        Vertex parentVertex = vertices[lettersOccurences[parentIndex]];
                        parentVertex.Children.Add(lettersOccurences[index]);
                        vertex.ParentsCount++;
                    }
                }
            }
        }

        private static int GetCharIndex(char ch)
        {
            int index;
            if (IsCapitals(ch))
            {
                index = ch - 'A';
            }
            else
            {
                index = (ch - 'a') + SmallLettersOffset;
            }

            return index;
        }

        private static bool IsCapitals(char ch)
        {
            bool capitalLetter = ch >= 'A' && ch <= 'Z';
            return capitalLetter;
        }


        private static void InitializeData()
        {
            for (int letter = 0; letter < lettersOccurences.Length; letter++)
            {
                lettersOccurences[letter] = InvalidValue;
            }
        }
    }
}

