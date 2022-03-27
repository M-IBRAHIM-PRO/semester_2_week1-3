using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_store_system
{
    internal class Program
    {
        // CONST VARIABLES
        const int N_CUSTOMER = 5;
        const int N_STOCKS = 10;
        const int N_BILLS = 4;
        const int N_ORDERS = 10;

        static int bill_count = 0;
        static int order_place_count = 0;
        //_________________FOR ORDER PLACE_________
        static string[] orders = new string[N_ORDERS];
        static string[] customer_1 = new string[N_ORDERS];
        static string[] customer_2 = new string[N_ORDERS];
        static string[] customer_3 = new string[N_ORDERS];
        static string[] customer_4 = new string[N_ORDERS];
        static string[] customer_5 = new string[N_ORDERS];

        //________________FOR STORE OF CUSTOMERS BILLS___
        static int[] customers_bills = new int[N_CUSTOMER];


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
            string[] bills_shop_names = new string[N_BILLS];
            int[] bills_shop = new int[N_BILLS];


            //---------------------------------------------------------
            entry_counter = loadcustomer(customer_n_a, customer_p_a);
            stock_counter = load_stocks_file(stock_adding,stock_prices);
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
                            view_customers_bills(customer_n_a);
                            Console.Clear();
                        }
                        //___view orders
                        else if (admin_option == 4)
                        {
                            view_orders(customer_n_a);
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
                                    save_stock_in_file(stock_counter, stock_adding, stock_prices);g
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
                                    add_bills_shop(bills_shop_names, bills_shop);
                                    Console.Clear();
                                }
                                else if (shop_option == 2)
                                {
                                    view_bills_shop(bills_shop_names, bills_shop);
                                    Console.Clear();
                                }
                                else if (shop_option == 3)
                                {
                                    update_bill(bills_shop_names, bills_shop);
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
                        //___delete customer
                        else if (admin_option == 7)
                        {
                            string name,pin;
                            Console.WriteLine("Enter name of customer : ");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter pin of customer : ");
                            pin = Console.ReadLine();
                            bool is_found = false;
                            int pos = 0;

                            for(int i=0; i<entry_counter; i++)
                            {
                                if (customer_n_a[i] == name && customer_p_a[i] == pin)
                                {
                                    pos = i;
                                    is_found = true;
                                }
                            }
                            if (is_found)
                            {
                                for(int i=pos; i < entry_counter; i++)
                                {
                                    customer_n_a[i] = customer_n_a[i + 1];
                                    customer_p_a[i] = customer_p_a[i + 1];
                                    entry_counter--;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Customer not found");
                                Console.ReadKey();
                            }
                            Console.Clear();
                        }
                        //___back to main menu
                        else if (admin_option == 8)
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
                            view_items(stock_adding, stock_prices);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (customer_option == 2)
                        {
                            bill_generator(customer_n_a, customer_p_a, stock_adding, stock_prices);
                            Console.Clear();
                        }
                        else if (customer_option == 3)
                        {
                            pin_change(customer_n_a, customer_p_a);
                            Console.Clear();
                        }
                        else if (customer_option == 4)
                        {
                            order_placing(customer_n_a, customer_p_a);
                            Console.Clear();
                        }
                        else if (customer_option == 5)
                        {
                            save_updated_data_in_file(customer_n_a, customer_p_a, entry_counter);
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

        static void save_updated_data_in_file(string[] name_a, string[] pin_a, int counter)
        {
            string path = "C:\\C# PROJECTS\\book_store_system\\names_pins.txt";
            StreamWriter file = new StreamWriter(path, false);
            for (int i = 0; i < counter; i++)
            {
                file.WriteLine(name_a[i] + "," + pin_a[i]);
            }
            file.Close();

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
            Console.WriteLine("7-Delete Customers");
            Console.WriteLine("8-Back to main menu.");
            Console.WriteLine("Your option---                                                   ");
            int stock_option;
            stock_option = int.Parse(Console.ReadLine());
            return stock_option;
        }
        //-------------------OP 1
        static int loadcustomer(string[] name_a, string[] pin_a)
        {
            int counter = 0;
            string path = "C:\\C# PROJECTS\\book_store_system\\names_pins.txt";
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
            string path = "C:\\C# PROJECTS\\book_store_system\\names_pins.txt";
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

        //__________________OP 4
        static void display_order(string[] array) // used in another function for displaying array.
        {
            int index = 0;
            while (array[index] != null)
            {
                Console.Write(array[index] + " ");
                index++;
            }
        }
        static void view_orders(string[] customer_n_a)
        {
            if (orders[0] != null)
            {
                Console.WriteLine("Following are the orders.");
                if (customer_1[0] != " ")
                {
                    Console.Write(customer_n_a[0] + "\t");
                    display_order(customer_1);
                    Console.WriteLine(" ");
                }
                if (customer_2[0] != " ")
                {
                    Console.Write(customer_n_a[1] + "\t");
                    display_order(customer_2);
                    Console.WriteLine(" ");
                }
                if (customer_3[0] != " ")
                {
                    Console.Write(customer_n_a[2] + "\t");
                    display_order(customer_3);
                    Console.WriteLine(" ");
                }
                if (customer_4[0] != " ")
                {
                    Console.Write(customer_n_a[3] + "\t");
                    display_order(customer_4);
                    Console.WriteLine(" ");
                }
                if (customer_5[0] != " ")
                {
                    Console.Write(customer_n_a[4] + "\t");
                    display_order(customer_5);
                    Console.WriteLine(" ");
                }
            }
            else
            {
                Console.WriteLine("No order have been placed yet.");

            }
            Console.ReadKey();
        }

        //___________________OP 3
        static void view_customers_bills(string[] customer_n_a)
        {
            if (customers_bills[0] != 0)
            {
                Console.WriteLine("Following(s) are the customers and their bills : ");
                Console.WriteLine("Name\t\t\tBill");
                if (bill_count < N_CUSTOMER)
                {
                    for (int i = 0; i <= bill_count; i++)
                    {
                        if (customer_n_a[i] != " " && customers_bills[i] != 0)
                            Console.WriteLine(customer_n_a[i] + "\t\t\t" + customers_bills[i]);
                    }
                }
                else
                {
                    for (int i = 0; i <= (N_CUSTOMER - 1); i++)
                    {
                        Console.WriteLine(customer_n_a[i] + "\t\t\t" + customers_bills[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("No Customer has done shoping yet.");

            }
            Console.ReadKey();
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
        static int load_stocks_file(string[] names_a,int[] prices_a)
        {
            int counter = 0;
            string path = "C:\\C# PROJECTS\\book_store_system\\stocks_prices.txt";
            
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                string name;
                int price;

                while ((line = file.ReadLine()) != null)
                {
                    name = parse_data(line, 1);
                    price =int.Parse( parse_data(line, 2));
                    add_stock_in_array(name, price, names_a, prices_a, counter);
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
        
        static void save_stock_in_file(int counter, string[] stock_names_a, int[] stock_prices_a)
        {
            string path = "C:\\C# PROJECTS\\book_store_system\\stocks_prices.txt";
            StreamWriter file = new StreamWriter(path, false);
            for (int i = 0; i < counter; i++)
            {
                file.WriteLine(stock_names_a[i] + "," + stock_prices_a[i]);
            }
            file.Close();
        }
        static int adding_stock_with_price(int stock_count, string[] name_a, int[] price_a)
        {
            int n_stock = 0;
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
            stock_name = Console.ReadLine();
            int index = 0;
            bool is_found = false;
            while (stock_adding[index] != null)
            {
                if (stock_adding[index] == stock_name)
                {
                    is_found = true;
                }
            }
            if (!is_found)
            {
                Console.WriteLine("Enter a valid stock name.");
            }
            Console.WriteLine("Enter name of new stock : ");
            stock_name_final = Console.ReadLine();
            Console.WriteLine("Enter price of stock : ");
            final_stock_price = int.Parse(Console.ReadLine());
            index = 0;
            
            while (stock_adding[index] != null)
            {
                if (stock_adding[index] == stock_name)
                {
                    stock_adding[index] = stock_name_final;
                    price_a[index] = final_stock_price;
                }
                index++;
            }
            if (is_found)
            {
                Console.WriteLine("Your stock is updated---");
            }
            Console.ReadKey();
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
        static void add_shopbills_array(string name, int amount_a, string[] bills_shop_names, int[] bills_shop, int shop_bill_count)
        {
            bills_shop_names[shop_bill_count] = name;
            bills_shop[shop_bill_count] = amount_a;
            //shop_bill_count++;
        }
        static void add_bills_shop(string[] name_a, int[] amount_a)
        {
            string bill_name;
            int bill_amount;
            int shop_bill_count = 0;
            for (int i = 0; i < N_BILLS; i++)
            {
                Console.WriteLine("Enter bill " + (i + 1) + " name  : ");
                bill_name = Console.ReadLine();
                Console.WriteLine("Enter " + bill_name + " bill amount : ");
                bill_amount = int.Parse(Console.ReadLine());
                add_shopbills_array(bill_name, bill_amount, name_a, amount_a, shop_bill_count);
                shop_bill_count++;
                //saveshopbillsInFile(bill_name, bill_amount_a);
            }
            Console.WriteLine("Your bills added");

        }
        //___________________OP 2
        static void view_bills_shop(string[] bills_shop_names, int[] bills_shop)
        {
            if (bills_shop[0] != 0)
            {
                Console.WriteLine("Your bills in asseding order are as show below : ");
                Console.WriteLine("Name\t\tamount_a(Rs)");
                sorting(bills_shop, bills_shop_names, N_BILLS);
                int total = 0;

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine(bills_shop_names[i] + ":\t\t" + bills_shop[i]);

                    total = total + bills_shop[i];
                }
                Console.WriteLine("Total expenditure" + ":\t\t" + (total));
            }
            else
            {
                Console.WriteLine("No bill has been added yet.");
            }
        }
        static void sorting(int[] amount_a, string[] name_a, int length)
        {
            int index;
            int smallestIndex;
            int location;
            int temp;
            string temp_name;

            for (index = 0; index < (length - 1); index++)
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
                temp_name = name_a[smallestIndex];

                amount_a[smallestIndex] = amount_a[index];
                name_a[smallestIndex] = name_a[index];

                amount_a[index] = temp;
                name_a[index] = temp_name;
            }
            //
        }
        //___________________OP 3
        static void update_bill(string[] bills_shop_names, int[] bills_shop)
        {
            bool is_found = false;
            string bill_name;
            int bill_amount_final;
            Console.WriteLine("Enter name of bill which you want to update : ");
            bill_name = Console.ReadLine();
            Console.WriteLine("Enter amount of bill : ");
            bill_amount_final = int.Parse(Console.ReadLine());
            for (int index = 0; index < N_BILLS; index++)
            {
                if (bills_shop_names[index] == bill_name)
                {
                    is_found = true;
                    bills_shop[index] = bill_amount_final;
                }
            }
            if (is_found)
            {
                Console.WriteLine("Your amount is updated---");
            }
            else
            {
                Console.WriteLine("Enter a valid bill name.");
            }
            Console.ReadKey();
        }
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
        static int calculateBill(string item, string[] stock_adding, int[] stock_prices)
        {
            int price = 0;
            int index = 0;
            bool is_found = false;
            while (stock_adding[index] != null)
            {
                if (item == stock_adding[index])
                {
                    is_found = true;
                    price = stock_prices[index];
                }
                index++;
            }
            if (!is_found)
            {
                Console.WriteLine("Enter a valid product name");
                Console.ReadKey();
            }
            return price;
        }
        static void bill_generator(string[] customer_n_a, string[] customer_p_a, string[] stock_adding, int[] stock_prices)
        {
            bool is_found = false;
            string customer_n, customer_p;
            Console.WriteLine("Enter name : ");
            customer_n = Console.ReadLine();
            Console.WriteLine("Enter pin : ");
            customer_p = Console.ReadLine();
            for (int i = 0; i < N_CUSTOMER; i++)
            {
                if (customer_n_a[i] == customer_n && customer_p_a[i] == customer_p)
                {
                    int n;
                    int bill;
                    int t_bill = 0;
                    string item;
                    Console.WriteLine("Enter  number  of items you want to buy : ");
                    n = int.Parse(Console.ReadLine());
                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine("Enter item name:");
                        item = Console.ReadLine();
                        bill = calculateBill(item, stock_adding, stock_prices);
                        t_bill = t_bill + bill;
                    }

                    Console.WriteLine("Total Bill :\t" + t_bill);
                    Console.ReadKey();
                    store_bill(t_bill, bill_count);

                    bill_count++;
                    is_found = true;
                }
            }
            if (!is_found)
            {
                Console.WriteLine("User_name or pin is wrong.");
            }
        }
        static void store_bill(int bill, int count)
        {
            customers_bills[count] = bill;
        }
        //__________________OP 3
        static void pin_change(string[] customer_n_a, string[] customer_p_a)
        {
            bool is_found = false;
            string name;
            string pin_customer;
            string new_pin;
            Console.WriteLine("Enter name : ");
            name = Console.ReadLine();
            Console.WriteLine("Enter pin : ");
            pin_customer = Console.ReadLine();
            for (int i = 0; i < N_CUSTOMER; i++)
            {
                if (customer_n_a[i] == name && customer_p_a[i] == pin_customer)
                {
                    is_found = true;
                    Console.WriteLine("Enter new pin : ");
                    new_pin = Console.ReadLine();
                    customer_p_a[i] = new_pin;
                    Console.WriteLine("Your pin is updated successfully____");
                    break;
                }
            }
            if (!is_found)
            {
                Console.WriteLine("User_name or Pin is wrong ");
                Console.ReadKey();
            }
        }
        //__________________OP 4
        static void order_placing(string[] customer_n_a, string[] customer_p_a)
        {
            bool is_found = false;
            string customer_n, customer_p;
            Console.WriteLine("Enter name : ");
            customer_n = Console.ReadLine();
            Console.WriteLine("Enter pin : ");
            customer_p = Console.ReadLine();
            for (int j = 0; j < N_CUSTOMER; j++)
            {
                if (customer_n_a[j] == customer_n && customer_p_a[j] == customer_p)
                {
                    is_found = true;
                    int n;
                    Console.WriteLine("Enter number of orders you want to place (max = 5) : ");
                    n = int.Parse(Console.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine("Enter order " + (i + 1) + " : ");
                        orders[i] = Console.ReadLine();
                    }
                    // Console.WriteLine("Nmae " + customer_n + endl;
                    // Console.WriteLine("Name in array " + customer_n_a[0] + endl;
                    // Console.WriteLine("Checking array:" + endl;
                    // for (int i = 0; i < n; i++)
                    // {
                    //     Console.WriteLine(orders[i] + " ";
                    // }
                    // Console.WriteLine(endl;
                    if (customer_n == customer_n_a[0])
                    {
                        for (int i = 0; i < n; i++)
                        {
                            customer_1[i] = orders[i];
                        }
                    }
                    else if (customer_n == customer_n_a[1])
                    {
                        for (int i = 0; i < n; i++)
                        {
                            customer_2[i] = orders[i];
                        }
                    }
                    else if (customer_n == customer_n_a[2])
                    {
                        for (int i = 0; i < n; i++)
                        {
                            customer_3[i] = orders[i];
                        }
                    }
                    else if (customer_n == customer_n_a[3])
                    {
                        for (int i = 0; i < n; i++)
                        {
                            customer_4[i] = orders[i];
                        }
                    }
                    else if (customer_n == customer_n_a[4])
                    {
                        for (int i = 0; i < n; i++)
                        {
                            customer_5[i] = orders[i];
                        }
                    }
                    order_place_count++;
                }
            }
            if (!is_found)
            {
                Console.WriteLine("User_name or pin is wrong ");
                Console.ReadKey();
            }
        }
    }
}
