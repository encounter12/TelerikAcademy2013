using System;
using System.Text;


namespace StringsAndTextProcessing
{
    /**
     * Write a program that reads a string, reverses it and prints the result at the console.
     * Example: "sample"  "elpmas".
     */
    class ReverseString
    {
        public static string ReverseStringMethod(string inputString)
        {           
            StringBuilder sb = new StringBuilder();
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                sb.Append(inputString[i]);
            }

            string reversedString = sb.ToString();
            return reversedString;
        }
        static void Main()
        {
            Console.WriteLine("Enter a string to be converted:");
            string inputString = Console.ReadLine();
            Console.WriteLine("Reversed String: {0}", ReverseStringMethod(inputString));
        }
    }
}
