using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using week_2_lab_2_challange_1.BL;

namespace week_2_lab_2_challange_1
{
    class Program
    {
        class Class1
        {
            public string ID;
            public string Name;
            public float price;
            public string Category;
            public string BrandName;
            public string Country;
        }
        static Class1 add_product()
        {
            Class1 p = new Class1();
            Console.WriteLine("Enter Product Name : ");
            p.Name=Console.ReadLine();

            Console.WriteLine("Enter ID : ");
            p.ID=Console.ReadLine();

            Console.WriteLine("Enter price : ");
            p.price=float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Category : ");
            p.Category=Console.ReadLine();

            Console.WriteLine("Enter Brand Name : ");
            p.BrandName=Console.ReadLine();

            Console.WriteLine("Enter Country : ");
            p.Country=Console.ReadLine();

            return p;
        }

        static void display_product(int counter,Class1[] s)
        {
            for(int i=0; i<counter; i++)
            {
                Console.WriteLine("Product ID : {0} Product Name : {1} Price : {2} Category : {3} Brand Name : {4} Country : {5}", s[i].ID,s[i].Name,s[i].price,s[i].Category,s[i].BrandName,s[i].Country);
                Console.ReadKey();
            }
        }
        static void total_value(int counter,Class1[] s)
        {
            float sum=0F;
            for(int i=0; i<counter; i++)
            {
                sum=sum+s[i].price;
            }
            Console.WriteLine("Total Value {0}",sum);
        }
        static void Main(string[] args)
        {
            Class1[] array=new Class1[10];
            int product_counter = 0;

            int option = 0;
            while (true)
            {
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Class1 s=new Class1();
                    s=add_product();
                    array[product_counter]=s;
                    product_counter++;
                    Console.Clear();

                }
                else if (option == 2)
                {
                    display_product(product_counter,array);
                    Console.Clear();

                }
                else if (option == 3)
                {
                    total_value(product_counter,array);
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (option == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid input");
                    Console.ReadKey();
                }
            }
        }
        static int menu()
        {
            Console.WriteLine("1.Add Product");
            Console.WriteLine("2.Show Product");
            Console.WriteLine("3.Total Store worth");
            Console.WriteLine("4.Exit");
            Console.WriteLine("Your Option______");
            int op = 0;
            op = int.Parse(Console.ReadLine());
            return op;
        }
    }
}
