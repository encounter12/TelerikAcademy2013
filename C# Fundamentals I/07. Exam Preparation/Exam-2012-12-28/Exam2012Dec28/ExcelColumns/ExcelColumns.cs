using System;

class ExcelColumns
{
    static void Main()
    {
        int linesNumberN = int.Parse(Console.ReadLine());
        long result = 0;

        for (int i = linesNumberN - 1; i >= 0; i--)
        {
            long charNumber = Convert.ToChar(Console.ReadLine()) - 64;
            result += charNumber * (long)Math.Pow(26, i);
        }
        Console.WriteLine(result);
    }
}