using System;

namespace week_2_lab_2_task_1
{
    class Program
    {
        class student
        {
            public string name;
            public string rool_n;
            public float gpa;
        }
        static void Main(string[] args)
        {
            student s1 = new student();
            s1.name = "Ali";
            s1.rool_n = "cs_122";
            s1.gpa = 3.4F;
            Console.Write("name :" + s1.name + " roll_n :" + s1.rool_n + " gpa :" + s1.gpa);
            Console.WriteLine();

            student s2 = new student();
            s2.name = "Ali aa";
            s2.rool_n = "cs_1233";
            s2.gpa = 3.7F;
            Console.Write("name :" + s2.name + " roll_n :" + s2.rool_n + " gpa :" + s2.gpa);
            Console.ReadKey();
        }
    }
}
