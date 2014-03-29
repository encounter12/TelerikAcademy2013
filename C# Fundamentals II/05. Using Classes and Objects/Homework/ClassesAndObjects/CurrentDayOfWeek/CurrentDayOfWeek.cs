using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDayOfWeek
{
    class CurrentDayOfWeek
    {
        /**
         * Write a program that prints to the console which day of the week is today. Use System.DateTime.
         */
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.DayOfWeek);
        }
    }
}
