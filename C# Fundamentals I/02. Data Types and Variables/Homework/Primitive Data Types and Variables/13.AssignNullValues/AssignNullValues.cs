using System;

class AssignNullValues
{
    static void Main()
    {
        int? myNullInt = null;
        double? myNullDouble = null;
        Console.WriteLine("myNullInt = {0}\nmyNullDouble = {1}", myNullInt, myNullDouble);
        Console.WriteLine("myNullInt + 1 = {0}", myNullInt + 1);
        Console.WriteLine("myNullInt + null = {0}", myNullInt + null);        
        Console.WriteLine("myNullDouble + 1 = {0}", myNullDouble + 1);
        Console.WriteLine("myNullDouble + null = {0}", myNullDouble + null);


    }
}
