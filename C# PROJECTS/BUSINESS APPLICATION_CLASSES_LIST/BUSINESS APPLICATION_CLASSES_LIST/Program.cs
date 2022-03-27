using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSINESS_APPLICATION_CLASSES_LIST.BL;

namespace BUSINESS_APPLICATION_CLASSES_LIST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //________________LIST_____________________________________

            List < customer_name_pin > customer_credentials= new List<customer_name_pin>();
            List<customer_name_bill> customer_shoping_history = new List<customer_name_bill>();
            List<customer_name_order> customer_orders = new List<customer_name_order>();

            List<stock_name_price> stocks_details = new List<stock_name_price>();
            List<shop_bill_amount> shop_bills = new List<shop_bill_amount>();

            //---------------LOCAL_AVARIABLES--------------------------
            int main_option;

            int admin_option;
            int stock_option;
            int shop_option;

            int customer_option;

            //---------------------------------------------------------
            loadcustomer(customer_credentials);
            load_stocks_file(stocks_details);
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
                            customer_credentials.Add(add_customer());   
                            Console.Clear();
                        }
                        //___view_customers
                        else if (admin_option == 2)
                        {
                            display_customer(customer_credentials);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        //___view bills
                        else if (admin_option == 3)
                        {
                            view_customers_bills(customer_shoping_history);
                            Console.Clear();
                        }
                        //___view orders
                        else if (admin_option == 4)
                        {
                            view_orders(customer_orders);
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
                                    adding_stock_with_price(stocks_details);
                                    Console.Clear();
                                }
                                else if (stock_option == 2)
                                {
                                    view_stock(stocks_details);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else if (stock_option == 3)
                                {
                                    update_stock(stocks_details);
                                    Console.Clear();
                                }
                                else if (stock_option == 4)
                                {
                                    save_stock_in_file(stocks_details);
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
                                    add_bills_shop(shop_bills);
                                    Console.Clear();
                                }
                                else if (shop_option == 2)
                                {
                                    view_bills_shop(shop_bills);
                                    Console.Clear();
                                }
                                else if (shop_option == 3)
                                {
                                    update_bill(shop_bills);
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
                            string name, pin;
                            Console.WriteLine("Enter name of customer : ");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter pin of customer : ");
                            pin = Console.ReadLine();
                            bool is_found = false;
                            
                            for (int i = 0; i < customer_credentials.Count; i++)
                            {
                                if (customer_credentials[i].name == name && customer_credentials[i].pin == pin)
                                {
                                    is_found = true;
                                    customer_credentials.RemoveAt(i);
                                }
                            }
                            
                            if(!is_found)
                            {
                                Console.WriteLine("Customer not found");
                                Console.ReadKey();
                            }
                            save_updated_data_in_file(customer_credentials);
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
                            view_items(stocks_details);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (customer_option == 2)
                        {
                            bill_generator(stocks_details,customer_credentials,customer_shoping_history);
                            Console.Clear();
                        }
                        else if (customer_option == 3)
                        {
                            pin_change(customer_credentials);
                            Console.Clear();
                        }
                        else if (customer_option == 4)
                        {
                            order_placing(customer_credentials, customer_orders);
                            Console.Clear();
                        }
                        else if (customer_option == 5)
                        {
                            save_updated_data_in_file(customer_credentials);
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

        static void save_updated_data_in_file(List<customer_name_pin> data)
        {
            string path = "names_pins.txt";
            StreamWriter file = new StreamWriter(path, false);
            for (int i = 0; i < data.Count; i++)
            {
                file.WriteLine(data[i].name + "," + data[i].pin);
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
        static void loadcustomer(List<customer_name_pin>data)
        {
            string path = "names_pins.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    customer_name_pin record = new customer_name_pin();
                    record.name= parse_data(line, 1);
                    record.pin= parse_data(line, 2);
                    data.Add(record);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File not Found ");
            }
        }
        static void savecustomerInFile(string name, string pin)
        {
            string path = "names_pins.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + "," + pin);
            file.Flush();
            file.Close();
        }
        static customer_name_pin add_customer()
        {

            customer_name_pin data = new customer_name_pin();
            Console.WriteLine("Enter customer  name");
            data.name = Console.ReadLine();
            Console.WriteLine("Enter customer  pin");
            data.pin= Console.ReadLine();
            
            savecustomerInFile(data.name, data.pin);

            return data;
        }

        //-------------------OP 2
        static void display_customer(List<customer_name_pin>customer_credentials)
        {
            Console.WriteLine("Name\t\tPin");
           
                for (int i = 0; i < customer_credentials.Count; i++)
                {
                    Console.WriteLine(customer_credentials[i].name + "\t\t" + customer_credentials[i].pin);
                }
        }

        //__________________OP 4
        static void view_orders(List<customer_name_order>customer_data)
        {
            if (customer_data.Count !=0)
            {
                Console.WriteLine(customer_data.Count);
                Console.WriteLine("Following are Orders of Customer(s)");
                Console.WriteLine("Name\t\t\tOrder");
                for (int i = 0; i < customer_data.Count; i++)
                {
                    Console.WriteLine(customer_data[i].name + "\t\t\t" + customer_data[i].order);
                }
            }
            else
            {
                Console.WriteLine("No order have been placed yet.");
            }
            Console.ReadKey();
        }

        //___________________OP 3
        static void view_customers_bills(List<customer_name_bill>customer_data)
        {
            if (customer_data.Count != 0)
            {
                Console.WriteLine("Following(s) are the customers and their bills : ");
                Console.WriteLine("Name\t\t\tBill");
                for (int i = 0; i < customer_data.Count; i++)
                {
                    Console.WriteLine(customer_data[i].name + "\t\t\t" + customer_data[i].bill);
                }
            }
            else
            {
                Console.WriteLine("No One has done shoping Yet...");
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
        static void load_stocks_file(List<stock_name_price> stock_details)
        {
            string path = "stocks_prices.txt";

            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    stock_name_price record = new stock_name_price();
                    record.name = parse_data(line, 1);
                    record.price = int.Parse(parse_data(line, 2));
                    stock_details.Add(record);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File not Found ");
            }
        }
        static void save_stock_in_file(List<stock_name_price> stock_details)
        {
            string path = "stocks_prices.txt";
            StreamWriter file = new StreamWriter(path, false);
            for (int i = 0; i <stock_details.Count; i++)
            {
                file.WriteLine(stock_details[i].name + "," + stock_details[i].price);
            }
            file.Close();
        }
        static void adding_stock_with_price(List<stock_name_price>stock_details)
        {
            
            int n_stock;
            Console.WriteLine("How many stocks you want to add : ");
            n_stock = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n_stock; i++)
            {
                stock_name_price record = new stock_name_price();
                Console.WriteLine("Enter stock " + (i + 1) + " : ");
                record.name= Console.ReadLine();
                Console.WriteLine("Enter " + record.name + " price : ");
                record.price = int.Parse(Console.ReadLine());
                stock_details.Add(record);
            }
            Console.WriteLine("You stocks are being added.");
        }
        //-------------------OP 2
        static void view_stock(List<stock_name_price> stock_details)
        {
            stock_details.Sort();
            Console.WriteLine("Following are the stocks added by ADMIN.");
            Console.WriteLine("Item\t\tPrice(Rs)");
            for (int i = 0; i < stock_details.Count; i++)
            {
                Console.WriteLine(stock_details[i].name + "\t\t" + stock_details[i].price);
            }
        }
        //___________________OP 3
        static void update_stock(List<stock_name_price> stock_details)
        {
            string stock_name;
            Console.WriteLine("Enter name of stock which you want to update : ");
            stock_name = Console.ReadLine();

            bool is_found = false;
            stock_name_price record = new stock_name_price();
            for (int i=0; i<stock_details.Count; i++) 
            { 
                if (stock_details[i].name == stock_name)
                {
                    is_found = true;
                }
            }
            if (is_found)
            {
                Console.WriteLine("Enter name of new stock : ");
                record.name = Console.ReadLine();
                Console.WriteLine("Enter price of stock : ");
                record.price = int.Parse(Console.ReadLine());
                for (int i = 0; i < stock_details.Count; i++)
                {
                    if (stock_details[i].name == stock_name)
                    { 
                        stock_details[i] = record;
                    }
                }
            }
            else if (!is_found)
            {
                bool is_true= false;
                Console.Clear();
                Console.WriteLine("Enter a valid stock name.");
                Console.WriteLine();
                Console.WriteLine("Press any key to add stock----");
                Console.ReadKey();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Enter name of stock : ");
                    record.name = Console.ReadLine();
                    Console.WriteLine("Enter price of stock : ");
                    record.price= int.Parse(Console.ReadLine());
                    for (int i = 0; i < stock_details.Count; i++)
                    {
                        if (stock_details[i].name == stock_name)
                        {
                            is_true = true;
                            stock_details[i] = record;     
                        }
                    }
                    if (is_true)
                    {
                        break;
                    }
                }
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
        static void add_bills_shop(List<shop_bill_amount>list_bill)
        {
            int number_bills;
            Console.WriteLine("How many bills you want to enter :");
            number_bills = int.Parse(Console.ReadLine());
            for (int i = 0; i < number_bills; i++)
            {
                shop_bill_amount record = new shop_bill_amount();
                Console.WriteLine("Enter bill " + (i + 1) + " name  : ");
                record.bill_name = Console.ReadLine();
                Console.WriteLine("Enter " + record.bill_name + " bill amount : ");
                record.bill_amount= int.Parse(Console.ReadLine());
                list_bill.Add(record);
            }
            Console.WriteLine("Your bills added");
        }
        //___________________OP 2
        static void view_bills_shop(List<shop_bill_amount> list_bill)
        {
            if (list_bill[0].bill_name != "")
            {
                int total = 0;
                list_bill.Sort();
                Console.WriteLine("Your bills in asseding order are as show below : ");
                Console.WriteLine("Name\t\t\tamount_a(Rs)");
                //list_bill.Sort();
                for (int i = 0; i < list_bill.Count; i++)
                {
                    Console.WriteLine(list_bill[i].bill_name + ":\t\t\t" + list_bill[i].bill_amount);

                    total = total + list_bill[i].bill_amount;
                }
                Console.WriteLine("Total expenditure" + ":\t" + (total));

            }
            else
            {
                Console.WriteLine("No bill has been added yet.");
            }
            Console.ReadKey();
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
        static void update_bill(List<shop_bill_amount> list_bill)
        {
            bool is_found = false;
            string bill_name;
            Console.WriteLine("Enter name of bill which you want to update : ");
            bill_name = Console.ReadLine();
            for (int i = 0; i < list_bill.Count; i++)
            {
                if (list_bill[i].bill_name == bill_name)
                {
                    is_found = true;
                    shop_bill_amount record = new shop_bill_amount();
                    Console.WriteLine("Enter Name of Bill : ");
                    record.bill_name = Console.ReadLine();
                    Console.WriteLine("Enter Amount of Bill : ");
                    record.bill_amount = int.Parse(Console.ReadLine());
                    list_bill[i] = record;
                }
            }
            if (!is_found)
            {
                Console.WriteLine("Enter Valid Name--");
                Console.WriteLine();
                Console.WriteLine("Press any key to enter bill------");
                Console.ReadKey();
                Console.Clear();
                int index = 0;
                bool is_true = false;
                while (true)
                {
                    Console.WriteLine("Enter name of bill which you want to update : ");
                    bill_name = Console.ReadLine();
                    if (list_bill[index].bill_name == bill_name)
                    {
                        is_true = true;
                        shop_bill_amount record = new shop_bill_amount();
                        Console.WriteLine("Enter Name of Bill : ");
                        record.bill_name = Console.ReadLine();
                        Console.WriteLine("Enter Amount of Bill : ");
                        record.bill_amount = int.Parse(Console.ReadLine());
                        list_bill[index] = record;
                    }
                    if (is_true)
                    {
                        break;
                    }
                    index++;
                }
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
        static void view_items(List<stock_name_price>data)
        {
            if (data[0].name != null)
            {
                Console.WriteLine("Following(s) items are available in shop:");
                Console.WriteLine("Item\t\tPrice(Rs)");
                for(int i=0; i<data.Count; i++)
                {
                    Console.WriteLine(data[i].name + "\t\t" + data[i].price);
                }
            }
            else
            {
                Console.WriteLine("No Stock to show yet.");
            }
        }
        //__________________OP 2
        static int calculateBill(string item, List<stock_name_price> stock_data)
        {
            int price = 0;
            bool is_found = false;
            for(int i=0; i<stock_data.Count; i++)
            {
                if (item == stock_data[i].name)
                {
                    is_found = true;
                    price = stock_data[i].price;
                }
            }
            if (!is_found)
            {
                Console.WriteLine("Enter a valid product name");
                Console.ReadKey();
            }
            return price;
        }
        static void bill_generator(List<stock_name_price> stock_data, List<customer_name_pin> customer_data,List<customer_name_bill>c_bill_data)
        {
            bool is_found = false;
            string customer_n, customer_p;
            Console.WriteLine("Enter name : ");
            customer_n = Console.ReadLine();
            Console.WriteLine("Enter pin : ");
            customer_p = Console.ReadLine();
            int customer_index = 0;
            for (int i = 0; i < customer_data.Count; i++)
            {
                if (customer_data[i].name == customer_n && customer_data[i].pin == customer_p)
                {
                    customer_name_bill record = new customer_name_bill();
                    customer_index = i;
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
                        bill = calculateBill(item,stock_data);
                        t_bill = t_bill + bill;
                    }
                    record.name = customer_n;
                    record.bill = t_bill;
                    c_bill_data.Add(record);

                    Console.WriteLine("Total Bill :\t" + t_bill);
                    Console.ReadKey();
                    is_found = true;
                }
            }
            if (!is_found)
            {
                Console.WriteLine("User_name or pin is wrong.");
            }
        }
        
        //__________________OP 3
        static void pin_change(List<customer_name_pin> customer_data)
        {
            bool is_found = false;
            string name, new_pin;
            string pin_customer;
            
            Console.WriteLine("Enter name : ");
            name = Console.ReadLine();
            Console.WriteLine("Enter pin : ");
            pin_customer = Console.ReadLine();
            for (int i = 0; i <customer_data.Count; i++)
            {
                if (customer_data[i].name == name && customer_data[i].pin == pin_customer)
                {
                    customer_name_pin record = new customer_name_pin();
                    is_found = true;
                    Console.WriteLine("Enter new pin : ");
                    new_pin = Console.ReadLine();

                    record.name = name;
                    record.pin = new_pin;

                    customer_data[i] = record;
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
        static void order_placing(List<customer_name_pin>customer_data,List<customer_name_order> customer_orders)
        {
            bool is_found = false;
            string customer_n, customer_p;
            Console.WriteLine("Enter name : ");
            customer_n = Console.ReadLine();
            Console.WriteLine("Enter pin : ");
            customer_p = Console.ReadLine();
            for (int j = 0; j < customer_data.Count; j++)
            {
                if (customer_data[j].name == customer_n && customer_data[j].pin == customer_p)
                {
                    is_found = true;
                    customer_name_order record = new customer_name_order();
                    Console.WriteLine("Enter order  : ");
                    record.order = Console.ReadLine();
                    record.name = customer_n;
                    customer_orders.Add(record);
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