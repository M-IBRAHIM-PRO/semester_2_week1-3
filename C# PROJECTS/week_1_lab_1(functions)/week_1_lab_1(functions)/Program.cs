using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_1_lab_1_functions_
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            int n1;
            int n2, sum;
            Console.WriteLine("Enter number : ");
            n1=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number : ");
            n2=int.Parse(Console.ReadLine());
            sum = add(n1 , n2);
            Console.WriteLine("sum {0}", sum);
            Console.ReadKey();

        }
        static int add(int io, int ioo)
        {
            return io + ioo;
        }
    }
}
