using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntDoubleOrStringVariables
{
    class IntDoubleOrStringVariables
    {
        static void Main()
        {
            Console.WriteLine("Choose type of variable to enter"); 
            Console.WriteLine("For int - press 1, for double - press 2, for string - press 3");

            byte variableTypeChoice = byte.Parse(Console.ReadLine());


            switch (variableTypeChoice)
            {
                case 1:
                    Console.WriteLine("Enter the integer type variable:");
                    int myInt = int.Parse(Console.ReadLine());
                    myInt += 1;
                    Console.WriteLine("{0} + 1 = {1}", myInt - 1, myInt);
                    break;
                case 2:
                    Console.WriteLine("Enter the double type variable:");
                    double myDouble = double.Parse(Console.ReadLine());
                    myDouble += 1;
                    Console.WriteLine("{0} + 1 = {1}", myDouble - 1, myDouble);
                    break;
                case 3:
                    Console.WriteLine("Enter the string type variable:");
                    string myString = Console.ReadLine();
                    myString = myString + "*";
                    Console.WriteLine(myString);
                    break;

                default:
                    Console.WriteLine("You have entered incorrect variable");
                    break;
            }
        }
    }
}
