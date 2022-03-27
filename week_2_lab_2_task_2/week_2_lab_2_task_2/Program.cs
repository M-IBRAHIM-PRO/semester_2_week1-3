using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_2_lab_2_task_2
{
    class Program
    {
        class student
        {
            public string name;
            public string roll_n;
            public float gpa;
        }
        static void Main(string[] args)
        {
            student s1 = new student();
            Console.WriteLine("Enter name : ");
            s1.name=Console.ReadLine();
            Console.WriteLine("Enter roll_n : ");
            s1.roll_n = Console.ReadLine();
            Console.WriteLine("Enter gpa : ");
            s1.gpa = float.Parse(Console.ReadLine());

            Console.WriteLine("NAME: " + s1.name + " ROLL_N : " + s1.roll_n + " GPA : " + s1.gpa);
            Console.ReadKey();
        }
    }
}
