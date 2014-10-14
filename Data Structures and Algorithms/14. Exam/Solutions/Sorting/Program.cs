namespace Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        // 10 points - JUST Copied from Internet
        static void Main(string[] args)
        {
            var numbersCount = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(' ').Select(number => int.Parse(number)).ToArray();
            var allowedMoves = int.Parse(Console.ReadLine());

            var result = CountMoves(numbers, numbers.Length);

            if (result <= allowedMoves)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }

        private static int CountMoves(int[] a, int n)
        {
            int j = n - 1;
            while (j > 0 && a[j - 1] < a[j]) --j;
            if (j == 0) return 0;   
            // the array is already sorted
            // min_val holds the smallest element in the array after
            // the currently investigated position, v_1 holds the smallest
            // element after the current position that is larger than any later
            int min_val = a[j], v_1 = a[j - 1];
            j -= 2;
            while (j >= 0)
            {
                if (a[j] < min_val)
                {
                    min_val = a[j];
                }
                else if (a[j] < v_1)
                {
                    v_1 = a[j];
                }
                --j;
            }
            int count_smaller = 0;
            for (j = 0; j < n; ++j)
            {
                if (a[j] < v_1) ++count_smaller;
            }
            return n - count_smaller;
        }
    }
}
