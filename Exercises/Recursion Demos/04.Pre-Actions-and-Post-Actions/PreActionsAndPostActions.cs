namespace Pre_Actions_and_Post_Actions
{
    using System;

    public class PreActionsAndPostActions
    {
        static void Main()
        {
            Console.Write("Enter n = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            PrintAction(n);
            Console.WriteLine();
        }

        private static void PrintAction(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new string('$', n));

            PrintAction(n - 1);

            Console.WriteLine(new string('@', n));
        }
    }
}
