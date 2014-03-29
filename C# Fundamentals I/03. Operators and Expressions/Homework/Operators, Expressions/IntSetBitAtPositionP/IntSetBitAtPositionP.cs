using System;

class IntSetBitAtPositionP
{
    static void Main()
    {

        Console.WriteLine("This program sets bit at position p in integer");

        Console.WriteLine("Please enter the integer:");
        int n = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Number {0} Binary value = {1}", n, Convert.ToString(n, 2).PadLeft(32, '0'));
        Console.WriteLine("Please enter the position p for which the bit should be set (starting from 0):");
        int p = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Please enter the bit value [1,0] :");
        int v = Int32.Parse(Console.ReadLine());

        Console.WriteLine();

        int mask;
        int result;

        if (v==1)
        {
            mask = 1 << p;
            result = n | mask;
            Console.WriteLine("Result integer value = {0}", result);
            Console.WriteLine("Result integer binary value = {0}", Convert.ToString(result, 2).PadLeft(32, '0'));                          
        }
        else if (v==0)
        {
            mask = ~(1 << p);
            result = n & mask;
            Console.WriteLine("Result integer = {0}", result);
            Console.WriteLine("Result integer binary value = {0}", Convert.ToString(result, 2).PadLeft(32, '0'));
            
        }
        else
        {
            Console.WriteLine("You have entered incorrect bit value");
        }

        
    }
}
