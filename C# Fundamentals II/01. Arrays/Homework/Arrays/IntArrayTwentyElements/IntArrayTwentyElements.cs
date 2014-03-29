using System;

class IntArrayTwentyElements
{
    static void Main()
    {
        int[] intArray = new int[20];

        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = i * 5;
            Console.WriteLine(intArray[i]);
        }
    }
}
