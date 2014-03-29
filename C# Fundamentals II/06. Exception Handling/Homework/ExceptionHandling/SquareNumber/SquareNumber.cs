using System;

namespace SquareNumber
{
    class SquareNumber
    {
        /**
         * Write a program that reads an integer number and calculates and prints its square root. 
         * If the number is invalid or negative, print "Invalid number". 
         * In all cases finally print "Good bye". Use try-catch-finally.
         */

        static void Main()
        {
            Console.WriteLine("Please, enter a positive integer number:");

            try
            {
                uint number = uint.Parse(Console.ReadLine());
                Console.WriteLine("The square root of {0} is {1}", number, Math.Sqrt(number));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}
