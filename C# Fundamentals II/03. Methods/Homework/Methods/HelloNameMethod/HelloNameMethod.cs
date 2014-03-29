using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloNameMethod
{
    class HelloNameMethod
    {
        static void Main(string[] args)
        {
            GetName();
        }
        public static void GetName()
        {
            Console.Write("Type in your name: ");
            Console.WriteLine("Hello, {0}!", Console.ReadLine());
        }
    }
}
