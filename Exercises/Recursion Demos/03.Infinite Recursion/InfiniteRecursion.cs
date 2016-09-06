namespace _03.Infinite_Recursion
{
    public class InfiniteRecursion
    {
        static void Main()
        {
            Calculate(5);
        }

        private static long Calculate(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            return Calculate(n - 1) + Calculate(n + 1);
        }
    }
}
