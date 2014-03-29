using System;

class Base { }

class Derived: Base { }

class Program
{
    static void Main()
    {
        Derived derivedObj = new Derived();
        Base baseObj = derivedObj as Base;

        Console.WriteLine("obj current type: {0}", baseObj);
        Console.WriteLine("obj type from which the current type directly inherits: {0}", baseObj.GetType().BaseType);
    }
}