using System;
using System.Collections.Generic;

public class Program
{
    public static IEnumerable<int[]> Combinations(int m, int n)
    {
        int[] result = new int[m];
        Stack<int> stack = new Stack<int>();
        stack.Push(1);

        while (stack.Count > 0)
        {
            int index = stack.Count - 1;
            int value = stack.Pop();

            while (value < n + 1)
            {
                result[index++] = value++;
                stack.Push(value);
                if (index == m)
                {
                    yield return result;
                    break;
                }
            }
        }
    }

    static void Main()
    {
        /*Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
         * N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}*/

        Console.WriteLine("Specify the set length N:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Specify the variations number K:");
        int m = int.Parse(Console.ReadLine());

        foreach (int[] c in Combinations(m, n))
        {
            for (int i = 0; i < c.Length; i++)
            {
                Console.Write(c[i] + " ");
            }
            Console.WriteLine();
        }
    }
}




