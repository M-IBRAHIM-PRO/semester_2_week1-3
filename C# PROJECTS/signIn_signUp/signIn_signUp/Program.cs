using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signIn_signUp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string p = "C:\\C# PROJECTS\\signIn_signUp\\data.txt";
            char option;
            while (true)
            {
                Console.Clear();
                option = menu();
                Console.Clear();
                if(option == '1')
                {
                    string name;
                    string pin;
                    Console.WriteLine("Enter user name :");
                    name=Console.ReadLine();
                    Console.WriteLine("Enter pin :");
                    pin=Console.ReadLine();

                    read_from_file(name,pin,p);
                    Console.ReadKey();

                }
                else if (option == '2')
                {
                    string name;
                    string pin;
                    Console.WriteLine("Enter user name :");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter pin :");
                    pin = Console.ReadLine();
                    write_in_file(name, pin, p);
                    Console.WriteLine("new user");
                }
                else if (option == '3') 
                {
                    break;
                }
                else {
                    Console.WriteLine("Enter valid input");
                }
            }
        }
        static void write_in_file(string name, string pin, string path)
        {
            StreamWriter var = new StreamWriter(path,true);
            var.WriteLine(name + ","+pin);
            var.Close();
            
        }
        static char menu()
        {
            Console.WriteLine("1-Sign In");
            Console.WriteLine("2-Sign Up");
            Console.WriteLine("3-Exit");
            char op;
            Console.WriteLine("Your Option---------");
            op = Console.ReadLine()[0];

            return op;

        }
       
        static void read_from_file(string name, string pin, string path)
        {
            string n;
            string p;
            if (File.Exists(path))
            {
                StreamReader var=new StreamReader(path);
                string line;
                while ((line = var.ReadLine()) != null)
                {
                    n = parse_data(line, 1);
                    p = parse_data(line, 2);
                    if (n == name && p==pin)
                    {
                        Console.Clear();
                        Console.WriteLine("valid user");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid user");
                    }
                }
            }
            else
            {
                Console.WriteLine("File donot exits");
            }
        }
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
    }
}
