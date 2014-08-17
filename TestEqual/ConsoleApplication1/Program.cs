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
            int i1 = 12;

            if (i1 > 0 && (s1 = "2") == "1")
            {
                Console.Write("y,");
            }
            else
            {
                Console.Write("n,");
            }

            Console.WriteLine(String.Format("i1={0:X000}", i1));
        }
    }


    //public abstract class A
    //{
    //    public A()
    //    {
    //        Console.Write("A,");
    //    }
    //    public virtual void Fun()
    //    {
    //        Console.WriteLine("A.Fun()");
    //    }
    //}

    //public class B : A
    //{
    //    public B()
    //    {
    //        Console.Write("B,");
    //    }

    //    public new void Fun()
    //    {
    //        Console.WriteLine("B.Fun()");
    //    }

    //    public static void Main()
    //    {
    //        A a = new B();
    //        a.Fun();
    //    }
    //}   
}
