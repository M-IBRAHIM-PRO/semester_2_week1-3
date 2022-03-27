using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes_objects_concept
{
    class student
    {
        public string name;
        public string roll_n;
        public float marks;
    }
    class Program
    {
        static student s2 = new student();
        static void Main(string[] args)
        {
            student s1 = new student();
            s1.name = "ali";
            s1.roll_n = "2021-CS-169";
            s1.marks = 1049F;
            nadd(ref s1);

            Console.WriteLine(s1.marks);
            Console.WriteLine(s1.name);
            Console.ReadKey();
        }
        static void nadd(ref student num)
        {
            num.marks = 555;
            
            //return num.marks;
        }
    }
}
