using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_lar_num
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[3];
            int l_num = -1;
            for(int i=0; i<3; i++)
            {
                Console.WriteLine("Enter {0} {1}", i,"number :");
                num[i] =int.Parse(Console.ReadLine());
            }
            for (int i = 0; i <3; i++)
            {
                if (num[i] > l_num)
                {
                    l_num= num[i];
                }
            }
            Console.WriteLine("number : {0}",l_num);
            Console.ReadLine();
        }
    }
}
