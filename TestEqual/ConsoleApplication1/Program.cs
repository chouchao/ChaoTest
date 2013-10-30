using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "1";
            int i1 = 1;

            if (i1 > 0 && (s1 = "2") == "1")
            {
                Console.Write("y,");
            }
            else
            {
                Console.Write("n,");
            }

            Console.WriteLine(String.Format("s1={0}", s1));
        }
    }
}
