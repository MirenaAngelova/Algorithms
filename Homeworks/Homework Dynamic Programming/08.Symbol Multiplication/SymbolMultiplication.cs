using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Symbol_Multiplication
{
    public class SymbolMultiplication
    {
        private const int MaxData = 50;
        private const char TargetResult = 'a';
        private static List<char> output = new List<char>(); 

        private static char[] alphabet = new char[MaxData];
        private static char[][] table = new char[MaxData][];
        private static char[] sequence = new char[MaxData];

        private static int alphabetLength;
        private static int sequenceLength;

        static void Main()
        {
            ProcessInput();
            MultiplySymbols(output, 0, sequenceLength - 1, TargetResult);
            PrintResult();
        }

        private static void PrintResult()
        {
            if (output.Count == 0)
            {
                Console.WriteLine("No solution");
            }
            else
            {
                Console.WriteLine($"{string.Join("", output)}");
            }
        }

        private static void MultiplySymbols(List<char> buffer, int min, int max, char targetChar)
        {
            int count = max - min + 1;
            if (count <= 1)
            {
                if (sequence[min] == targetChar)
                {
                    buffer.Add(sequence[min]);
                }

                return;
            }

            int[] possibleLeft = new int[MaxData];
            int[] possibleRight = new int[MaxData];

            int possibilitiesLenght =// count of found multiplications
                FindPossibleMultiplications(possibleLeft, possibleRight, targetChar);

            List<char> leftResult = new List<char>();
            List<char> rightResult = new List<char>();

            for (int index = min; index < max; index++)
            {
                for (int possIndex = 0; possIndex < possibilitiesLenght; possIndex++)
                {
                    char left = alphabet[possibleLeft[possIndex]];
                    char right = alphabet[possibleRight[possIndex]];

                    MultiplySymbols(leftResult, min, index, left);
                    MultiplySymbols(rightResult, index + 1, max, right);
                    if (leftResult.Count > 0 && rightResult.Count > 0)
                    {
                        JoinLists(buffer, leftResult, rightResult);
                        
                        return;
                    }

                    leftResult.Clear();
                    rightResult.Clear();
                }
            }
        }

        private static void JoinLists(List<char> output, List<char> leftResult, List<char> rightResult)
        {
            foreach (var left in leftResult)
            {
                output.Add(left);
            }

            
            output.Add('*');

            foreach (var right in rightResult)
            {
                output.Add(right);
                
            }
            output.Insert(0, '(');
            output.Add(')');
            
        }

        private static int FindPossibleMultiplications(
            int[] possibleLeft, int[] possibleRight, char targetChar)
        {
            int index = 0;
            for (int row = 0; row < alphabetLength; row++)
            {
                for (int col = 0; col < alphabetLength; col++)
                {
                    if (table[row][col] == targetChar)
                    {
                        possibleLeft[index] = row;
                        possibleRight[index] = col;
                        index++;
                    }
                }
            }

            return index;
        }

        private static void ProcessInput()
        {
            alphabet = Console.ReadLine()
                .Substring(12)
                .Split(new[] { ',', '}' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            alphabetLength = alphabet.Length;

            Console.ReadLine();

            for (int i = 0; i < alphabetLength; i++)
            {
                table[i] = Console.ReadLine().Substring(2).ToCharArray();
            }

            sequence = Console.ReadLine().Substring(4).ToCharArray();
            sequenceLength = sequence.Length;
        }
    }
}
