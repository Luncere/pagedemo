using System;

namespace _1082007_HW1_3
{
    class Program
    {
        static double CI(double A,double r,double n)
        {
            return A * Math.Pow((1 + r), n);
        }
        static void Main(string[] args)
        {
            double A, r, n;
            string data;
            data = Console.ReadLine();
            A = double.Parse(data);
            data = Console.ReadLine();
            r = double.Parse(data);
            data = Console.ReadLine();
            n = double.Parse(data);
            Console.WriteLine(CI(A, r, n));
        }
    }
}
