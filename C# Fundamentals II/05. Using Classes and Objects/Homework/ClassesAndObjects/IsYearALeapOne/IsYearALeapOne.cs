using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class IsYearALeapOne
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter year:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("{0}: {1}", year, DateTime.IsLeapYear(year) ? "leap" : "not leap");            
        }
    }
}
