using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assesment_lec_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int age;
            int price_machine;
            int price_toy;
            int total_save;
            int money=0;
            int toy_money;
            int odd_counter=0;
            int even_counter = 0;
            Console.WriteLine("Enter age : ");
            age =int.Parse(Console.ReadLine());
            Console.WriteLine("Enter machine price : ");
            price_machine = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter toy price : ");
            price_toy = int.Parse(Console.ReadLine());

            for(int i=1; i<=age; i++)
            {
                if (i % 2 == 0)
                {
                    even_counter++;
                    money = money+ 10*(even_counter);
                }
                else
                {
                    odd_counter=odd_counter + 1;

                }
            }
            toy_money = odd_counter * price_toy;
            total_save=money+(toy_money-odd_counter);
            if(total_save == price_machine)
            {
                Console.WriteLine("You can buy ");
            }
            else if(total_save > price_machine)
            {
                Console.WriteLine("You can buy  and save {0}", total_save - price_machine);
            }
            else
            {
                Console.WriteLine("You can buy  and save {0}", -total_save + price_machine);
            }
            Console.ReadKey();

        }
    }
}
