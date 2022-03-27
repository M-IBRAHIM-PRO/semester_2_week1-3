using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_2_lab_2_task_3_SELF_ASSESMENT_
{
    class Program
    {
        class student
        {
            public string name;
            public string roll_n;
            public float cgpa;
            public string dept;
            public string hos_day;
        }
        static student add_student()
        {
            student s = new student();
            Console.WriteLine("Enter name : ");
            s.name = Console.ReadLine();
            Console.WriteLine("Enter roll_n : ");
            s.roll_n = Console.ReadLine();
            Console.WriteLine("Enter cgpa : ");
            s.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter dept : ");
            s.dept = Console.ReadLine();
            Console.WriteLine("Enter hostalide or day : ");
            s.hos_day = Console.ReadLine();
            return s;
        }
        static void show_students(int counter,student[] array)
        {
            
            for(int i=0; i<counter; i++)
            {
                Console.WriteLine("Name : "+array[i].name+" Roll n : "+ array[i].roll_n+ " Cgpa" + array[i].cgpa+ " department : "+ array[i].dept + " status : " + array[i].hos_day);
            }
           
        }
        static void comparion(int counter, student[] array)
        {
            float temp = 0F;
            int lar_index = 0;
            for(int i=0; i<counter; i++)
            {
                if (array[i].cgpa < lar_index)
                {
                    lar_index = i;
                }
                temp = array[lar_index].cgpa;
                array[lar_index].cgpa = array[i].cgpa;
                array[i].cgpa = temp;
            }
        }
        static void Main(string[] args)
        {
            student[] array = new student[4];
            student s = new student();
            int counter = 0;
            int option = 0;
            while (true)
            {
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    s=add_student();
                    array[counter] = s;
                    counter++;
                    Console.Clear();

                }
                else if (option == 2)
                {
                    show_students(counter,array);
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (option == 3)
                {
                    comparion(counter, array);
                    show_students(counter, array);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (option == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid input ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        static int menu()
        {
            int op = 0;
            Console.WriteLine("1.Add Student");
            Console.WriteLine("2.Show Student");
            Console.WriteLine("3.Top Students");
            Console.WriteLine("4.Exit");

            Console.WriteLine("Your Options------");
            hop = int.Parse(Console.ReadLine());
            return op;
        }
    }
}