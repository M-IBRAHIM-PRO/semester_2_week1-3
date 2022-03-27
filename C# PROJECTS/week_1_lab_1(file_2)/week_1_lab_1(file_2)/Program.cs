using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_1_lab_1_file_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string p = "C:\\C# PROJECTS\\week_1_lab_1(file_2)\\textdoc.txt";
            StreamWriter var=new StreamWriter(p,true);
            int i = 0;
            while (i < 10)
            {
                var.WriteLine("sdafasfasdfsaddfasdfasdav");
                int v = i++;
            }
            var.Close();
        }
    }
}
