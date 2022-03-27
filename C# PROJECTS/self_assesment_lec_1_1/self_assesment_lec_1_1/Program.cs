using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assesment_lec_1_1
{
    internal class Program
    {
        static int sum(int n1, int n2)
        {
            return n1 + n2;
        }
        static void Main(string[] args)
        {
            int num1;
            int num2;
            Console.WriteLine("Enter number 1 : ");
            num1=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number 2 : ");
            num2 = int.Parse(Console.ReadLine());
            int result=sum(num1,num2);
            Console.WriteLine(result);
            Console.ReadKey();
        }
       
    }
}       
