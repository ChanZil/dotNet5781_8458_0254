using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_00_8458_0254
{
   partial class Program
    {
        static void Main(string[] args)
        {
            Welcome0254();
            Welcome8458();
            Console.ReadKey();
        }
        static partial void Welcome8458();
        private static void Welcome0254()

        {
            Console.WriteLine("Enter your name: ");
            string name = System.Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
    }
}
