using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list_in_cs
{
    class Program
    {
        class data
        {
            public string name;
            public string pin;
        }
        static void Main(string[] args)
        {
            List<data> user_data = new List<data>();
            data s = new data();
            s.name = "Ali";
            s.pin = "1212";
            user_data.Add(s);
            for (int i = 0; i < user_data.Count; i++)
            {
                Console.WriteLine(user_data[0]);
            }
            Console.ReadKey();

        }


    }
}
