using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_3_week_1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            while (true)
            {
                option = menu();
                if (option == 1)
                {

                }
                else if(option == 2)
                {

                }
                else if (option == 3)
                {
                    Console.WriteLine("Exit...");
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid input ");
                    System("cls");
                }

            }
            Console.ReadKey();
        }
        static int menu()
        {
            int op;
            Console.WriteLine("1.SIN IN ");
            Console.WriteLine("2.SIN UP");
            Console.WriteLine("3.EXIT");
            Console.WriteLine("your option ---------");
            op=int.Parse(Console.ReadLine());
            return op;
        }
    }
}
