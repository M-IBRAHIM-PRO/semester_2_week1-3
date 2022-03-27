using System.IO;
using System;

namespace pratice_2_week_1_lec_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\C# PROJECTS\\pratice_2_week_1_lec_2\\textfile.txt";
            /* ----------------------FOR READ---------------
             if (File.Exists(path))
            {
              StreamReader filevar= new StreamReader(path);

               string line;
               while ((line = filevar.ReadLine()) != null)
               {
                   Console.WriteLine(line);
               }
               filevar.Close();
           }
           else
           {
               Console.WriteLine("File not found");
           }
           Console.ReadKey();     

           }
            */

            /*--------------FOR WRTE AND APPEND 
             
             * USE TRUE FOR APPEND
             * USE FALSE FOR OVER-WRITE
             
            StreamWriter filevar= new StreamWriter(path,false);
            filevar.WriteLine("write use c#");
            filevar.Flush();
            filevar.Close();
            */

            //StreamWriter name=new StreamWriter(path,true);
            //name.WriteLine("use c# for pro");
            //name.Close();
            StreamReader name=new StreamReader(path);
            if (File.Exists(path))
            {
                string line;
                while((line = name.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("file dont exits");
            }
            Console.ReadKey();
           
        }
    }
}