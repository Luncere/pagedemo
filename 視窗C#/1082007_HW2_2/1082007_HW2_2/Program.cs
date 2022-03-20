using System;

namespace _1082007_HW2_2
{
    class Triangle
    {
        private double line_a;
        private double line_b;
        private double line_c;
        public void SetLengths(double a, double b, double c)
        {
            this.line_a = a;
            this.line_b = b;
            this.line_c = c;
        }
        public int TriangleType()
        {
            if (!IsTriangle)
            {
                return -1;
            }
            if (line_a * line_a == line_b * line_b + line_c * line_c)
            {
                return 0;
            }
            if (line_a * line_a < line_b * line_b + line_c * line_c)
            {
                return 1;
            }
            return 2;
        }
        public bool IsTriangle
        {
            get
            {
                double tmp;
                if (line_b > line_a)
                {
                    tmp = line_b;
                    line_b = line_a;
                    line_a = tmp;
                }
                if (line_c > line_a)
                {
                    tmp = line_c;
                    line_c = line_a;
                    line_a = tmp;
                }
                if (line_a >= line_b + line_c)
                {
                    return false;
                }
                return true;
            }
        }
        public void ShowTriangle()
        {
            Console.WriteLine("line_a:{0} \nline_b:{1} \nline_c:{2}", line_a, line_b, line_c);
            switch (TriangleType())
            {
                case -1:
                    Console.WriteLine("三角形不成立");
                    break;
                case 0:
                    Console.WriteLine("直角三角形");
                    break;
                case 1:
                    Console.WriteLine("鈍角三角形");
                    break;
                case 2:
                    Console.WriteLine("銳角三角形");
                    break;
                default:
                    break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
