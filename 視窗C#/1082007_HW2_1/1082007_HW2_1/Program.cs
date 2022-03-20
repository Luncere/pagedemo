using System;

namespace _1082007_HW2_1
{
    class Student
    {
        private int id;
        private string name;
        Student(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int ID
        {
            get
            {
                return this.id;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
        } 
        private float math_s;
        private float english_s;
        private float bcc_s;
        public float Mat
        {
            set
            {
                if (0 <= value && 100 >= value)
                {
                    this.math_s = value;
                }
            }
        }
        public float Eng
        {
            set
            {
                if (0 <= value && 100 >= value)
                {
                    this.english_s = value;
                }
            }
        }
        public float Bcc
        {
            set
            {
                if (0 <= value && 100 >= value)
                {
                    this.bcc_s = value;
                }
            }
        }
        public float GetAvg() {
            return (math_s + english_s + bcc_s) / 3;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
