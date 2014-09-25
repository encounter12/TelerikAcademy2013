using System;

class CombinationsGeneratorWithReps
{
    static int k;
    static string[] set;
	static int[] arr;
    static int n;

	static void Main()
	{
        string input = Console.ReadLine();
        set = input.Split(new Char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        k = int.Parse(Console.ReadLine());
        arr = new int[k];
        n = set.Length;
		GenerateCombinationsNoRepetitions(0, 0);
    }

	static void GenerateCombinationsNoRepetitions(int index, int start)
	{
		if (index >= k)
		{
			PrintVariations();
		}
		else
		{
            for (int i = start; i < n; i++)
			{
				arr[index] = i;
				GenerateCombinationsNoRepetitions(index + 1, i);
			}
		}
	}

	static void PrintVariations()
	{
        int len = arr.Length;
        for (int i = 0; i < len - 1; i++)
		{
            Console.Write(set[arr[i]] + ", ");
		}
        Console.Write(set[arr[len - 1]]);
		Console.WriteLine();
	}
}
