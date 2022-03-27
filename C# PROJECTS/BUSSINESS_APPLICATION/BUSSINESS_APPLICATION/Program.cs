using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_store_management_system
{

    internal class Program
    {
        // CONST VARIABLES
        const int N_CUSTOMER = 5;
        const int N_STOCKS = 10;
        const int N_BILLS = 4;
        const int N_ORDERS = 10;


        static void Main(string[] args)
        {
            //---------------LOCAL_AVARIABLES--------------------------
            int main_option;

            int admin_option;
            int stock_option;
            int shop_option;

            int customer_option;

            //----counter variables
            int entry_counter = 0;
            int stock_counter = 0;
            int bill_shop_counter=0;

            //----arrays
            //-----------------name and pin-----------------
            string[] customer_n_a = new string[N_CUSTOMER];
            string[] customer_p_a = new string[N_CUSTOMER];
            //----------------------------------------------
            //_________________stocks and prices_____________
            string[] stock_adding = new string[N_STOCKS];
            int[] stock_prices = new int[N_STOCKS];
            //_______________________________________________
            //________________bills of shop_________________
            string[] bills_shop_names=new string[N_BILLS];
            int [] bills_shop=new int[N_BILLS];
            //---------------------------------------------------------
            entry_counter = loadcustomer(customer_n_a, customer_p_a);
            while (true)
            {
                main_option = main_menu();
                Console.Clear();
                //________________________ADMIN-SECTION__________________
                if (main_option == 1)
                {
                    while (true)
                    {
                        admin_option = admin_menu();
                        Console.Clear();
                        //---add_customers
                        if (admin_option == 1)
                        {
                            Console.WriteLine("Enter counter : " + entry_counter);
                            add_customer(entry_counter, customer_n_a, customer_p_a);
                            entry_counter++;
                            Console.Clear();
                        }
                        //___view_customers
                        else if (admin_option == 2)
                        {
                            display_customer(entry_counter, customer_n_a, customer_p_a);
                            Console.ReadKey();
                            Console.Clear();
                        }

                        //___view bills
                        else if (admin_option == 3)
                        {

                            Console.Clear();
                        }
                        //___view orders
                        else if (admin_option == 4)
                        {

                            Console.Clear();
                        }
                        //___stock management menu
                        else if (admin_option == 5)
                        {
                            while (true)
                            {
                                stock_option = stock_management_menu();
                                Console.Clear();
                                if (stock_option == 1)
                                {
                                    int new_stock_counter;
                                    Console.WriteLine("Enter counter : " + stock_counter);
                                    new_stock_counter = adding_stock_with_price(stock_counter, stock_adding, stock_prices);
                                    stock_counter = stock_counter + new_stock_counter;
                                    Console.Clear();
                                }
                                else if (stock_option == 2)
                                {
                                    view_stock(stock_counter, stock_adding, stock_prices);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else if (stock_option == 3)
                                {
                                    update_stock(stock_adding, stock_prices);
                                    Console.Clear();
                                }
                                else if (stock_option == 4)
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
                        //___shop management menu
                        else if (admin_option == 6)
                        {
                            while (true)
                            {
                                
                                shop_option = shop_management_menu();
                                Console.Clear();
                                if (shop_option == 1)
                                {
                                    add_bills_shop(bills_shop_names,bills_shop);
                                    Console.Clear();
                                }
                                else if (shop_option == 2)
                                {
                                    //view_bills_shop(bills_shop_names,bills_shop);
                                    for(int i=0; i<4; i++)
                                    {
                                      Console.WriteLine(bills_shop_names[i]+"      "+bills_shop[i]);
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else if (shop_option == 3)
                                {
                                    Console.Clear();
                                }
                                else if (shop_option == 4)
                                {
                                    break;

                                }
                                else
                                {
                                    Console.WriteLine("Enter a valid input");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        }
                        //___back to main menu
                        else if (admin_option == 7)
                        {
                            break;
                        }
                        //___in case of wromg input
                        else
                        {
                            Console.WriteLine("Enter a valid input");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }//________________END OF ADMIN SECTION________________

                //________________________CUSTOMER-SECTION__________________
                else if (main_option == 2)
                {
                    while (true)
                    {
                        customer_option = customer_menu();
                        Console.Clear();
                        if (customer_option == 1)
                        {
                            view_items(stock_adding,stock_prices);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (customer_option == 2)
                        {

                            Console.Clear();
                        }
                        else if (customer_option == 3)
                        {

                            Console.Clear();
                        }
                        else if (customer_option == 4)
                        {

                            Console.Clear();
                        }
                        else if (customer_option == 5)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid input");
                            Console.Clear();
                        }
                    }
                }
                //________________________EXIT-SECTION__________________
                else if (main_option == 3)
                {
                    header();
                    Console.WriteLine("Thanks for using");
                    Console.ReadKey();
                    break;
                }
                //________________________ELSE CONDITON__________________
                else
                {
                    Console.WriteLine("Enter a valid input ");
                    Console.Clear();
                }
            }

        }
        //__________END OF MAIN________________
        static void header()
        {
            Console.WriteLine("***************************************************************** ");
            Console.WriteLine("              *Book Store Management System* ");
            Console.WriteLine("***************************************************************** ");
        }
        static int main_menu()
        {
            header();
            Console.WriteLine("                                                                 ");
            Console.WriteLine("                 Welcome To Book Store                       ");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("You want to login as an ADMIN OR CUSTOMER.                       ");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("For ADMIN press 1.                                               ");
            Console.WriteLine("For CUSTOMER press 2.                                            ");
            Console.WriteLine("To EXIT program, press 3.                                            ");
            Console.WriteLine("                                                                 ");
            //  OPTION FROM USER.
            Console.WriteLine("Your option---                                                   ");
            int stock_option;
            stock_option = int.Parse(Console.ReadLine());
            return stock_option;
        }

        //_______________________FOR GENERAL USE_____________________________
        static string parse_data(string line, int feild)
        {
            string data = "";
            int comma = 1;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    comma++;
                }
                else if (comma == feild)
                {
                    data = data + line[i];
                }
            }
            return data;
        }


        //------------------------FOR ADMIN SECTION---------------------------
        static int admin_menu()
        {
            header();
            Console.WriteLine("                                                                 ");
            Console.WriteLine("                 Welcome To Book Store                       ");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("Main Menu--------------------------------------------------------");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("1-Add Customers");
            Console.WriteLine("2-View Customers");
            Console.WriteLine("3-View Bills  (history)");
            Console.WriteLine("4-View odders placed by the customers.");
            Console.WriteLine("5-Add / Update stock of the shop.");
            Console.WriteLine("6-Manage the expenditures of the shop.");
            Console.WriteLine("7-Back to main menu.");
            Console.WriteLine("Your option---                                                   ");
            int stock_option;
            stock_option = int.Parse(Console.ReadLine());
            return stock_option;
        }
        //-------------------OP 1
        static int loadcustomer(string[] name_a, string[] pin_a)
        {
            int counter = 0;
            string path = "C:\\C# PROJECTS\\book_store_management_system\\names_pins.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                string name;
                string pin;

                while ((line = file.ReadLine()) != null)
                {
                    name = parse_data(line, 1);
                    pin = parse_data(line, 2);
                    add_customer_array(name, pin, counter, name_a, pin_a);
                    counter++;
                }
                file.Close();

            }
            else
            {
                Console.WriteLine("File not Found ");
            }
            return counter;
        }
        static void add_customer_array(string name, string pin, int entry_counter, string[] name_a, string[] pin_a)
        {
            name_a[entry_counter] = name;
            pin_a[entry_counter] = pin;
        }
        static void savecustomerInFile(string name, string pin)
        {
            string path = "C:\\C# PROJECTS\\book_store_management_system\\names_pins.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + "," + pin);
            file.Close();
        }
        static void add_customer(int counter, string[] name_a, string[] pin_a)
        {
            if (counter < 5)
            {
                string name, pin;
                Console.WriteLine("Enter customer  name");
                name = Console.ReadLine();
                Console.WriteLine("Enter customer  pin");
                pin = Console.ReadLine();
                add_customer_array(name, pin, counter, name_a, pin_a);
                savecustomerInFile(name, pin);
            }

            else
            {
                Console.WriteLine("Only " + N_CUSTOMER + " can be added ");
                Console.ReadKey();
            }
        }

        //-------------------OP 2
        static void display_customer(int counter, string[] name_a, string[] pin_a)
        {
            Console.WriteLine("Name\t\tPin");
            if (counter < N_CUSTOMER)
            {
                for (int i = 0; i < counter; i++)
                {
                    Console.WriteLine(name_a[i] + "\t\t" + pin_a[i]);
                }
            }
            else
            {
                for (int i = 0; i < N_CUSTOMER; i++)
                {
                    Console.WriteLine(name_a[i] + "\t\t" + pin_a[i]);
                }
            }
        }

        //-----------------------FOR STOCK MANAGEMENT ------------
        static int stock_management_menu()
        {
            header();
            Console.WriteLine("                                                                 ");
            Console.WriteLine("Stock Management  Menu--------------------------------------------------------");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("1-Add Stock of shop");
            Console.WriteLine("2-View added stock ");
            Console.WriteLine("3-Update added stock");
            Console.WriteLine("4-Back to admin menu");
            Console.WriteLine("Your option---                                                   ");
            int stock_option;
            stock_option = int.Parse(Console.ReadLine());
            return stock_option;
        }
        //__________________OP 1
        static int adding_stock_with_price(int stock_count, string[] name_a, int[] price_a)
        {
            int n_stock=0;
            if (stock_count < 10)
            {
                Console.WriteLine("Maximum number of stocks you can enter : " + N_STOCKS);
                Console.WriteLine("How many stocks you want to add : ");
                n_stock = int.Parse(Console.ReadLine());
                string name;
                int prices;
                for (int i = 0; i < n_stock; i++)
                {
                    Console.WriteLine("Enter stock " + (i + 1) + " : ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter stock " + (i + 1) + " price : ");
                    prices = int.Parse(Console.ReadLine());
                    add_stock_in_array(name, prices, name_a, price_a, stock_count);
                    stock_count++;
                }
                Console.WriteLine("You stocks are being added.");
            }
            else
            {
                Console.WriteLine("You can only add " + N_STOCKS + " stocks");
            }
            return n_stock;
        }
        static void add_stock_in_array(string name, int price, string[] name_a, int[] price_a, int counter)
        {
            name_a[counter] = name;
            price_a[counter] = price;
            counter++;
        }
        //-------------------OP 2
        static void view_stock(int stock_count, string[] stock_adding, int[] stock_prices)
        {

            Console.WriteLine("Following are the stocks added by ADMIN.");
            Console.WriteLine("Item\t\tPrice(Rs)");
            for (int i = 0; i < stock_count; i++)
            {
                Console.WriteLine(stock_adding[i] + "\t\t" + stock_prices[i]);
            }
        }
        //___________________OP 3
        static void update_stock(string[] stock_adding, int[] price_a)
        {
            string stock_name, stock_name_final;
            int final_stock_price;
            Console.WriteLine("Enter name of stock which you want to update : ");
            stock_name=Console.ReadLine();
            Console.WriteLine("Enter name of new stock : ");
            stock_name_final = Console.ReadLine();
            Console.WriteLine("Enter price of stock : ");
            final_stock_price = int.Parse(Console.ReadLine());
            int index = 0;
            while (stock_adding[index] != null)
            {
                if (stock_adding[index] == stock_name)
                {
                    stock_adding[index] = stock_name_final;
                    price_a[index] = final_stock_price;
                }
                index++;
            }
            Console.WriteLine("Your stock is updated---");
        }
        //-----------------------FOR SHOP MANAGEMENT---------------------------
        static int shop_management_menu()
        {
            header();
            Console.WriteLine("                                                                 ");
            Console.WriteLine("Shop Management  Menu--------------------------------------------");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("1-Add Bills of shop");
            Console.WriteLine("2-View added bills ");
            Console.WriteLine("3-Update added bills");
            Console.WriteLine("4-Back to admin menu");
            Console.WriteLine("Your option---                                                   ");
            int stock_option;
            stock_option = int.Parse(Console.ReadLine());
            return stock_option;
        }
        //___________________OP 1
        static void add_shopbills_array(string name, int amount_a,string[] bills_shop_names,int[] bills_shop,int shop_bill_count)
        {
            bills_shop_names[shop_bill_count] = name;
            bills_shop[shop_bill_count] = amount_a;
            //shop_bill_count++;
        }
        static void add_bills_shop(string[] name_a,int[] amount_a)
        {
            string bill_name;
                int bill_amount;
                int shop_bill_count=0;
                for (int i = 0; i < N_BILLS; i++)
                {
                    Console.WriteLine("Enter bill " + (i + 1) + " name  : ");
                    bill_name=Console.ReadLine();
                    Console.WriteLine("Enter " + bill_name + " bill amount : ");
                    bill_amount=int.Parse(Console.ReadLine());
                    add_shopbills_array(bill_name, bill_amount,name_a,amount_a,shop_bill_count);
                    shop_bill_count++;
                    //saveshopbillsInFile(bill_name, bill_amount_a);
                }
                Console.WriteLine("Your bills added");
            
        }
        //___________________OP 2
        static void view_bills_shop(string[] bills_shop_names,int[] bills_shop)
        {
            Console.WriteLine("Your bills in asseding order are as show below : ");
            Console.WriteLine("Name\t\tamount_a(Rs)");
            sorting(bills_shop, bills_shop_names, N_BILLS);
            int total=0;
            int bill_count=0;
            for (int i = 0; i < (bill_count); i++)
            {
                Console.WriteLine(bills_shop_names[i] + ":\t\t" + bills_shop[i]);
                bill_count++;
                total = total + bills_shop[i];
            }
            Console.WriteLine("Total expenditure" + ":\t\t" + (total));
        }
        static void sorting(int[] amount_a,string[] name_a, int length)
        {
            int index;
            int smallestIndex;
            int location;
            int temp;
            string temp_name;
    
            for (index = 0; index < length - 1; index++)
            {
                // Step a
                smallestIndex = index;
                for (location = index + 1; location < length; location++)
                {
                    if (amount_a[location] < amount_a[smallestIndex])
                    {
                        smallestIndex = location;
                    }
                }
                // Step b
                temp = amount_a[smallestIndex];
                temp_name=name_a[smallestIndex];

                amount_a[smallestIndex] = amount_a[index];
                name_a[smallestIndex]=name_a[index];

                amount_a[index] = temp;
                name_a[index]=temp_name;
            }
            //
        }
        //___________________OP 3

        //______________________________________________________________________

        //-----------------------FOR CUSTOMER SECTION---------------------------
        static int customer_menu()
        {
            header();
            Console.WriteLine("                                                                 ");
            Console.WriteLine("                 Welcome To Book Store                       ");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("Main Menu--------------------------------------------------------");
            Console.WriteLine("                                                                 ");
            Console.WriteLine("1-View Items");
            Console.WriteLine("2-Buy the required items");
            Console.WriteLine("3-Change pin");
            Console.WriteLine("4-Place odders.");
            Console.WriteLine("5-Back to main menu.");
            Console.WriteLine("Your option---                                                   ");
            int stock_option;
            stock_option = int.Parse(Console.ReadLine());
            return stock_option;
        }
        //___________________OP 1
        static void view_items(string[] stock_adding, int[] stock_prices)
        {
            if (stock_adding[0] != null)
            {
                Console.WriteLine("Following(s) items are available in shop:");
                int index = 0;
                Console.WriteLine("Item\t\tPrice(Rs)");
                while (stock_adding[index] != null)
                {
                    Console.WriteLine(stock_adding[index] + "\t\t" + stock_prices[index]);
                    index++;
                }
            }
            else
            {
                Console.WriteLine("No Stock to show yet.");
            }
        }
        //__________________OP 2

        //__________________OP 3

        //__________________OP 4

        //_____________________________________END______________________________
    }
}