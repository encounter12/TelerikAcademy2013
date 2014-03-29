using System;

class MyAgeInTenYears
{
    static void Main()
    {
        Console.Write("Plese, enter your age: ");
        int currentAge = int.Parse(Console.ReadLine());
        int yearsPeriod = 10;
        DateTime currentDate = DateTime.Today;
        DateTime birthYearTodayDate = currentDate.AddYears(-currentAge);
        DateTime futureDate = currentDate.AddYears(yearsPeriod);
        int futureAge = futureDate.Year - birthYearTodayDate.Year;
        Console.WriteLine("Your age in {0} years will be: {1} years", yearsPeriod, futureAge);
    }
}

