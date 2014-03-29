using System;

namespace GenericListClass
{
    public class Application
    {
        static void Main()
        {
            GenericList<int> myList = new GenericList<int>();

            for (int i = 0; i < 20; i++)
            {
                myList.Add(i);
            }

            Console.WriteLine("List item with index 4: {0}", myList[4]);

            Console.WriteLine("Assign value 150 for item at position 4");

            myList[4] = 150;
 
            Console.WriteLine("List item with index 4: {0}", myList[4]);

            Console.WriteLine("Remove item at index 4");

            myList.RemoveAt(4);

            Console.WriteLine("Item with index 4: {0}", myList[4]);

            myList.Insert(12, 4160);

            Console.WriteLine("Item with index 12: {0}", myList[12]);

            Console.WriteLine("Index of number 2 first occurrence: {0}", myList.FindIndex(2));
            Console.WriteLine("Index of number 4 first occurrence: {0}", myList.FindIndex(4));

            Console.WriteLine("List of items:\n {0}", myList);

            Console.WriteLine("Min value: {0}", myList.Min());
            Console.WriteLine("Max value: {0}", myList.Max());

            myList.Clear();

            Console.WriteLine(myList);

        }
    }
}
