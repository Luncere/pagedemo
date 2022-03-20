using System;

namespace _1082007_HW1_4
{
    class Program
    {
        static int Fibonacci(int n)
        {
            if (0 == n)
            {
                return 0;
            }
            if (1 == n)
            {
                return 1;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(Fibonacci(i));
            }
        }
    }
}
