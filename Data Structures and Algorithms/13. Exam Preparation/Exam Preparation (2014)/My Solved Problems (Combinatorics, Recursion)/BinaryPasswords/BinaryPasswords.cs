namespace BinaryPasswords
{
    using System;
    using System.Linq;

    class BinaryPasswords
    {
        static void Main()
        {
            string pattern = Console.ReadLine();
            ulong binaryPasswordsCount = 1;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == '*')
                {
                    binaryPasswordsCount = binaryPasswordsCount << 1;
                }
            }
            Console.WriteLine(binaryPasswordsCount);
        }
    }
}