namespace Divisors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Divisors
    {
        static List<Number> permutations = new List<Number>();

        static void Main()
        {
            int elementsCount = int.Parse(Console.ReadLine());

            string[] arr = new string[elementsCount]; 

            for (int i = 0; i < elementsCount; i++)
            {
                arr[i] = Console.ReadLine();
            }

            GeneratePermutations(arr, 0);
            int smallestNumber = FindSmallestNumberWithLeastDivisors(permutations);
            Console.WriteLine(smallestNumber);
        }

        class Number
        {
            public Number(int value)
            {
                this.Value = value;
                this.DivisorsCount = FindDivisorsNumber(value);
            }

            public int Value { get; set; }
            public int DivisorsCount { get; set; }

            private int FindDivisorsNumber(int number)
            {
                int count = 0;
                for (int i = 1; i <= number; ++i)
                {
                    if (number % i == 0)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        static void GeneratePermutations<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                int value = int.Parse(string.Join("", arr));
                Number number = new Number(value);
                permutations.Add(number);
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        static int FindSmallestNumberWithLeastDivisors(List<Number> permutations)
        {
            permutations = permutations.OrderBy(number => number.Value).ToList();
            int smallestNumber = permutations[permutations.Count - 1].Value;
            int leastDivisorsCount = permutations[permutations.Count - 1].DivisorsCount;

            for (int i = permutations.Count - 1; i >= 0; i--)
            {
                if (permutations[i].DivisorsCount <= leastDivisorsCount)
                {
                    smallestNumber = permutations[i].Value;
                    leastDivisorsCount = permutations[i].DivisorsCount;
                }
            }

            return smallestNumber;
        }
    }
}