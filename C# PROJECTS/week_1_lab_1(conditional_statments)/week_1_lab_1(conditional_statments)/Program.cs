using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_1_lab_1_conditional_statments_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            int sum = 0;
            do
            {
                Console.WriteLine("Enter any number : ");
                num=int.Parse(Console.ReadLine());
                sum=sum+num;
          
            }
            while (num !=-1);
            sum = sum + 1;
            Console.WriteLine("Total sum {0}", sum);
            Console.ReadKey();
        }
    }
}
