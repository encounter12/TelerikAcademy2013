using System;

class AllVariationsOfKElementsIn1ToN
{
    static void Variations(int[] currentArray, int index, int n)
    {
        if (index == currentArray.Length) //Bottom of recursion
        {
            for (int i = 0; i < currentArray.Length; i++) //Print the resulting variation
            {
                Console.Write("{0} ", currentArray[i]);
            }
            Console.WriteLine();
        }
        else
        {
            for (int j = 1; j <= n; j++)//If we are still in the recursion. Take k elements and give their variation
            {
                currentArray[index] = j;
                Variations(currentArray, index + 1, n);
            }
        }
    }

    static void Main()
    {
        //Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. Example:
        //N = 3, K = 2 ->{1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
        
        Console.WriteLine("Specify the set length N:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Specify the variations number K:");
        int k = int.Parse(Console.ReadLine());

        int[] numbersArray = new int[k]; //Create the array with the K variations dimention

        Variations(numbersArray, 0, n); //Use the recursive algorithm for all the numbers N
    }    
}