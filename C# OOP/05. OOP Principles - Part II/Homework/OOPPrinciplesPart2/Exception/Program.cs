using System;
using System.Globalization;
using System.Threading;

namespace Exception
{
    public class Program
    {
        static void Main()
        {

            // example with integer number
            int minValue = 1;
            int maxValue = 100;

            Console.WriteLine("Please, enter a number between {0} and {1}:", minValue, maxValue);
            int value = int.Parse(Console.ReadLine());

            ExceptionTest<int>.IsValueWithinRange(value, minValue, maxValue);

            // example with date
            DateTime minDate = DateTime.ParseExact("01.01.1980", "d.M.yyyy", CultureInfo.InvariantCulture);
            DateTime maxDate = DateTime.ParseExact("31.12.2013", "d.M.yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("Please, enter a date between {0} and {1}:", minDate.ToString("d.M.yyyy"), maxDate.ToString("d.M.yyyy"));
            
            string dateStr = Console.ReadLine();
            
            DateTime date = DateTime.ParseExact(dateStr, "d.M.yyyy", CultureInfo.InvariantCulture);

            ExceptionTest<DateTime>.IsValueWithinRange(date, minDate, maxDate);
            
        }

    }
}


