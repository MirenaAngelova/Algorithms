using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Businessmen
{
    public class Businessmen
    {
        private static long[] results;

        public static void Main()
        {
            ProcessAlgorithm();
        }

        private static void ProcessAlgorithm()
        {
            int countOfBusinessmen = ProcessInput();
            Console.WriteLine(CalcMaxShakes(countOfBusinessmen));
        }

        private static long CalcMaxShakes(int countOfBusinessmen)
        {
            if (countOfBusinessmen <= 0)
            {
                return 1;
            }
            else if (results[countOfBusinessmen] != 0)
            {
                return results[countOfBusinessmen];
            }

            long result = 0;
            int totalPossibleShakes = countOfBusinessmen - 2;
            for (int i = 0; i <= totalPossibleShakes; i += 2)
            {
                long currentResult = 1;
                currentResult *= CalcMaxShakes(i);
                currentResult *= CalcMaxShakes(totalPossibleShakes - i);
                result += currentResult;
            }

            results[countOfBusinessmen] = result;
            return result;
        }

        private static int ProcessInput()
        {
            int count = int.Parse(Console.ReadLine());
            results = new long[count + 1];

            return count;
        }
    }
}
