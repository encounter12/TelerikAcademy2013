using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortThreeValuesUsingNestedIfs
{
    class SortThreeValuesUsingNestedIfs
    {
        static void Main()
        {
            Console.WriteLine("Value 01:");
            double value01 = double.Parse(Console.ReadLine());
            Console.WriteLine("Value 02:");
            double value02 = double.Parse(Console.ReadLine());
            Console.WriteLine("Value 03:");
            double value03 = double.Parse(Console.ReadLine());

            double tempValue = 0;

            if (value01 < value02)
            {
                tempValue = value01;
                value01 = value02;
                value02 = tempValue;
                if (value02 < value03)
                {
                    tempValue = value02;
                    value02 = value03;
                    value03 = tempValue;
                }
                if (value01 < value02)
                {
                    tempValue = value01;
                    value01 = value02;
                    value02 = tempValue;
                }
            }
            else
            {
                if (value02 < value03)
                {
                    tempValue = value02;
                    value02 = value03;
                    value03 = tempValue;                    
                }
                if (value01 < value02)
                {
                    tempValue = value01;
                    value01 = value02;
                    value02 = tempValue;
                }
            }
            Console.WriteLine("The number in descending order are:{0}, {1}, {2}", value01, value02, value03);
        }
    }
}
