using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace input_output_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            int sum=0;
            Console.WriteLine("Enter any number : ");
            num = int.Parse(Console.ReadLine());
            while (num!= -1)
            {
                sum = sum + num;
                Console.WriteLine("Enter any number : ");
                num = int.Parse(Console.ReadLine());
               
            }
            Console.WriteLine("Sum : {0}",sum);
            
            Console.ReadKey();
        }
    }
}
