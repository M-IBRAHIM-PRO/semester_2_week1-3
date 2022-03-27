using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_1_lab_1_basic_operation_
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int b;
            int height;
            int area;
            Console.WriteLine("Enter base :");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter height:");
            height = int.Parse(Console.ReadLine());
            area = b * height;
            Console.WriteLine("area");
            Console.WriteLine(area);
            Console.ReadKey();
        }
    }
}
