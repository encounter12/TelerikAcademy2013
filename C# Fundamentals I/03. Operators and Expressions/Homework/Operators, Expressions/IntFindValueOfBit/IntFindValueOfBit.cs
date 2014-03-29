using System;

class IntFindValueOfBit
{
    static void Main()
    {
        Console.WindowWidth = 100;
        Console.WriteLine("This program extracts the bit on position p (left-to-right) value in a given integer");
        Console.WriteLine("Please write the integer:");
        int i = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Integer binary value = {0}", Convert.ToString(i, 2).PadLeft(32, '0'));
        Console.WriteLine("Please specify the bit position number starting from 0:");
        int b = Int32.Parse(Console.ReadLine());
        
        int mask = 1 << b;
        int nAndMask = i & mask;
        int bit = nAndMask >> b;
        Console.WriteLine("bit number {0} value = {1}", b, bit);
        Console.WriteLine();
    }
}
