using System;

namespace _1082007_HW1_1
{
    class Program
    {
        static double CLM(double x1, double x2, double y1, double y2)
        {
            return x1 * y2 - x2 * y1;
        }
        static string Find_ans(double a1, double b1, double c1, double a2, double b2, double c2)
        {
            if (0 == CLM(a1, a2, b1, b2))
            {
                if (0 == CLM(c1, c2, b1, b2) && 0 == CLM(a1, a2, c1, c2))
                {
                    return "無限多組解";
                }
                return "無解";
            }
            return "x="+ CLM(c1, c2, b1, b2) / CLM(a1, a2, b1, b2)+ " y="+ CLM(a1, a2, c1, c2) / CLM(a1, a2, b1, b2);
        }
        static void Main(string[] args)
        {
            double a1, b1, c1, a2, b2, c2;
            string data;
            data = Console.ReadLine();
            a1 = double.Parse(data);
            data = Console.ReadLine();
            b1 = double.Parse(data);
            data = Console.ReadLine();
            c1 = double.Parse(data);
            data = Console.ReadLine();
            a2 = double.Parse(data);
            data = Console.ReadLine();
            b2 = double.Parse(data);
            data = Console.ReadLine();
            c2 = double.Parse(data);
            Console.WriteLine(Find_ans(a1, b1, c1, a2, b2, c2));
        }
    }
}
