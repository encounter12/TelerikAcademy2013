using System;

class IsBitAtPositionPOne
{
    static void Main()
    {
        Console.WriteLine("This program checks if a bit at position p in a given integer is 1");
        Console.WriteLine("Please type down the integer:");
        int v = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Integer binary value = {0}", Convert.ToString(v, 2).PadLeft(32, '0'));
        Console.WriteLine("Please specify the bit position number starting from 0:");
        int p = Int32.Parse(Console.ReadLine());                             
        int mask = 1 << p;         
        int nAndMask = v & mask;  
        int bit = nAndMask >> p;  
        Console.WriteLine(bit==1);   
    }
}
