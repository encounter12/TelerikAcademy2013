using System;

class VariationsGeneratorNoReps
{
	static int n;
	static int k;
	static int[] arr;
	static bool[] used;
    static string[] objects;

	static void Main()
	{

        //string[] objects = new string[n] 
        //{
        //    "banana", "apple", "orange", "strawberry", "raspberry",
        //    "apricot", "cherry", "lemon", "grapes", "melon"
        //};

        // banana, apple, orange, strawberry, raspberry, apricot, cherry, lemon, grapes, melon
        objects = Console.ReadLine().Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
        n = objects.Length;
        used = new bool[n];
        k = int.Parse(Console.ReadLine());
        arr = new int[k];
		GenerateVariationsNoRepetitions(0);
	}

	static void GenerateVariationsNoRepetitions(int index)
	{
		if (index >= k)
		{
			PrintVariations();
		}
		else
		{
			for (int i = 0; i < n; i++)
			{
				if (!used[i])
				{
					used[i] = true;
					arr[index] = i;
					GenerateVariationsNoRepetitions(index + 1);
					used[i] = false;
				}
			}
		}
	}

	static void PrintVariations()
	{
		Console.Write("(" + String.Join(", ", arr) + ") --> ( ");
		for (int i = 0; i < arr.Length; i++)
		{
			Console.Write(objects[arr[i]] + " ");
		}
		Console.WriteLine(")");
	}
}
