using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Write the first array elements number:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Write the second array elements number:");
        int s = int.Parse(Console.ReadLine());

        int[] array1 = new int[n];
        int[] array2 = new int[s];
                       
        bool arraysIdentical = true;

        if (n != s)
        {
            arraysIdentical = false;
        }
        else
        {
            Console.WriteLine("Write the first array elements:");

            for (int i = 0; i < n; i++)
            {
                Console.Write("array1[{0}] = ", i);
                array1[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Write the secound array elements:");

            for (int i = 0; i < s; i++)
            {
                Console.Write("array2[{0}] = ", i);
                array2[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                if (array1[i] != array2[i])
                {
                    arraysIdentical = false;
                    break;
                }             
            }
        }
                    
        Console.WriteLine("The arrays are identical: {0}", arraysIdentical);
    }
}

