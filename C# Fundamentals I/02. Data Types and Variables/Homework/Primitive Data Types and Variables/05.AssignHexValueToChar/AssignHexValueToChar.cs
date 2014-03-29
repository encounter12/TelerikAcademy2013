using System;

class AssignHexValueToChar
{
    static void Main()
    {
        char myChar = (char)0x48;      
        Console.WriteLine(@"The character with unicode number 72 is: {0}", myChar);
    }
}
