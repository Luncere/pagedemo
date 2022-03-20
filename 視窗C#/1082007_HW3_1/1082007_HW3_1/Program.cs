using System;

namespace _1082007_HW3_1
{
    class Program
    {
        static void Main(string[] args){
            double[] line = new double[3];
            string data;
            bool check = false;
            while (!check){
                try{
                    data = Console.ReadLine();
                    line[0] = double.Parse(data);
                    if (line[0] <= 0) throw new Exception("Less_Than_Zero");
                    data = Console.ReadLine();
                    line[1] = double.Parse(data);
                    if (line[1] <= 0) throw new Exception("Less_Than_Zero");
                    data = Console.ReadLine();
                    line[2] = double.Parse(data);
                    if (line[2] <= 0) throw new Exception("Less_Than_Zero");
                    for (int i = 0; i < 3; i++){
                        for (int j = 0; j < 3; j++){
                            swap(line, i, j);
                        }
                    }
                    if (line[0] >= line[1] + line[2]){
                        throw new Exception("Not_Triangle");
                    }
                    if (line[0] * line[0] > line[1] * line[1] + line[2] * line[2]){
                        Console.WriteLine("鈍角三角形");
                    }
                    else if (line[0] * line[0] < line[1] * line[1] + line[2] * line[2]){
                        Console.WriteLine("銳角三角形");
                    }
                    else{
                        Console.WriteLine("直角三角形");
                    }
                    check = true;
                }
                catch (Exception e){
                    Console.WriteLine(e.Message + "\n");
                    Console.WriteLine("Please enter again: ");
                }
            }
        }
        static void swap(double[] line, int a, int b){
            if (a < b){
                if (line[a] < line[b]){
                    double temp = line[a];
                    line[a] = line[b];
                    line[b] = temp;
                }
            }
        }
    }
}