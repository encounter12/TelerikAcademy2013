using System;

class FirstElementBiggerThanNeighborsIndex
{
    static int IndexOfFirstElementBiggerThanNeighbors(int[] numbers)
    {   
        if (numbers.Length == 1 || numbers[0] > numbers[1])
        {
            return 0;
          
        }
        for (int i = 1; i < numbers.Length - 1; i++)
        {
            if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
            {
                return i;
            }                      
        }

        if (numbers[numbers.Length - 1] > numbers[numbers.Length - 2])                                        
        {
            return numbers.Length - 1;
        }

        return -1;
    }
    static void Main()
    {
        /*Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.*/

        Console.WriteLine("Enter array length (positive integer):");
        int arrayLength = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the array elements:");

        int[] numbers = new int[arrayLength];
        int myIndex = 0;
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("numbers[{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        myIndex = IndexOfFirstElementBiggerThanNeighbors(numbers);     
        Console.WriteLine("The index of the first element bigger than it's neighbors is: {0}", myIndex);
    }
}

