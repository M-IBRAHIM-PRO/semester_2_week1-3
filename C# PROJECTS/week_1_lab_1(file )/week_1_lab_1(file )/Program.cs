using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_1_lab_1_file__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string p = "C:\\C# PROJECTS\\week_1_lab_1(file )\\textdoc.txt";
            if (File.Exists(p))
            {
                StreamReader sr = new StreamReader(p);

                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("file donot exit");
            }
            Console.ReadLine();
        }
    }
}
