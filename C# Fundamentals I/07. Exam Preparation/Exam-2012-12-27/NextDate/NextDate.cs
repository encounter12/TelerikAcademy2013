using System;

class Program
{
    static void Main()
    {
        int date = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());

        DateTime today = new DateTime(year, month, date);
        DateTime tomorrow = today.AddDays(1);
        Console.WriteLine(tomorrow.ToString("d.M.yyyy"));
    }
}