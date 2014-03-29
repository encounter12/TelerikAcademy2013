using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    class Program
    {
        static void Main()
        {
            string sentence = "What a wonderful day";

            //prints the initial string to the console
            Console.WriteLine("String: {0}", sentence);

            //creates new StringBuilder object
            StringBuilder sb = new StringBuilder();

            //appends the initial string to the StringBuilder object
            sb.Append(sentence);
            
            //creates a sub-StringBuilder starting from 7th character (zero-based) and having length 9, 
            //then converts it to string and prints it on the console.
            Console.WriteLine("Substring: {0}", sb.Substring(7, 9).ToString());

            //creates a sub-StringBuilder starting from 7th character (zero-based) and ending at the end of the StringBuilder, 
            //converts it to string and prints it on the console.
            Console.WriteLine("Substring: {0}", sb.Substring(7).ToString());


            IEnumerable<int> numbers = new List<int> { 2, 1, 4, -1, 3, 7};

            Console.WriteLine(numbers.Sum());

            Console.WriteLine(numbers.Product());

            Console.WriteLine(numbers.Min());

            Console.WriteLine(numbers.Max());

            Console.WriteLine(numbers.Average());

        }
    }
}
