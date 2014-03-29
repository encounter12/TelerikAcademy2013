using System;

class IsBitThreeOneOrZero
{
    static void Main()
    {
        Console.WindowWidth = 100;
        Console.WriteLine("This program displays if the 3rd bit (counting from 0) of a given integer is 1 or 0");
        Console.WriteLine("Please enter integer: ");
        int myInt = Int32.Parse(Console.ReadLine());
        string binaryString = Convert.ToString(myInt, 2).PadLeft(32, '0');
        Console.WriteLine(String.Format("{0, -30}: {1, -34}", "32-bit binary representation", binaryString));
        
        // Finds the bit at position p in the binary representation of myInt
        int p = 3;        
        int mask = 1 << p;        
        int nAndMask = myInt & mask;  
        int bitThree = nAndMask >> p;
        Console.WriteLine("{0, -30}: {1, -3}", "Bit three (counting from 0)", bitThree);     
    }
}
