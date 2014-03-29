using System;

class ObjectConcatenateStrings
{
    static void Main()
    {
        string myFirstString = "Hello";
        string mySecondString = "World";
        object concatenatedStringsObject = myFirstString + " " + mySecondString;
        Console.WriteLine("concatenatedStringsObject = {0}", concatenatedStringsObject);
        string myConcatenatedStrings = (string)concatenatedStringsObject;
        Console.WriteLine("myConcatenatedStrings = {0}", myConcatenatedStrings);

    }
}
