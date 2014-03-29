using System;

class MathExpression
{
    static void Main()
    {
        decimal n = decimal.Parse(Console.ReadLine());
        decimal m = decimal.Parse(Console.ReadLine());
        decimal p = decimal.Parse(Console.ReadLine());
                         
        decimal result;

        result = (((n * n) + (1m / (m * p)) + 1337) / (n - 128.523123123m * p)) + (decimal)Math.Sin((double)Math.Truncate(m % 180));

        Console.WriteLine(Math.Round(result, 6));

    }
}