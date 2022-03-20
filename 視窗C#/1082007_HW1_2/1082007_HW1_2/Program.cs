using System;

namespace _1082007_HW1_2
{
    class Program
    {
        static void swap(double[] line, int a, int b)
        {
            if (a < b)
            {
                if (line[a] < line[b])
                {
                    double temp = line[a];
                    line[a] = line[b];
                    line[b] = temp;
                }
            }
        }
        static string triangle(double[] line)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    swap(line, i, j);
                }
            }
            if (line[0] >= line[1] + line[2])
            {
                return "這並非三角形";
            }
            if (line[0] * line[0] > line[1] * line[1] + line[2] * line[2])
            {
                return "此三角形為鈍角三角形";
            }
            if (line[0] * line[0] < line[1] * line[1] + line[2] * line[2])
            {
                return "此三角形為銳角三角形";
            }
            return "此三角形為直角三角形";
        }
        static void Main(string[] args)
        {
            double [] line;
            line = new double[3];
            string data;
            data = Console.ReadLine();
            line[0] = double.Parse(data);
            data = Console.ReadLine();
            line[1] = double.Parse(data);
            data = Console.ReadLine();
            line[2] = double.Parse(data);
            Console.WriteLine(triangle(line));
        }
    }
}
