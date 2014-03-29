using System;

class SevenlandNumbers
{
     
    static void Main()
    {
        int num01 = int.Parse(Console.ReadLine());
        int num02 = 1;
        int numeralBase = 7;
              

        int arrayLength = Math.Max(num01.ToString().Length, num02.ToString().Length) + 1;
        int[] a;
        int[] b;

        FillDigitsArray(num01, arrayLength, out a);
        FillDigitsArray(num02, arrayLength, out b);

        Console.WriteLine(Sum(a, b, numeralBase));
    }

    public static void FillDigitsArray(int number, int arrayLength, out int[] digitsArray)
    {
        digitsArray = new int[arrayLength]; 
        for (int i = 0; i < arrayLength; i++)
        {
            digitsArray[i] = (number / (int)Math.Pow(10, i)) % 10;
        }
    }

    public static string Sum(int[] num01, int[] num02, int numeralBase)
    {
        string sum = "";
        int[] sumArray = new int[num01.Length];
        int carry = 0;
        for (int i = 0; i < num01.Length - 1; i++)
        {
            sumArray[i] = (num01[i] + num02[i] + carry) % numeralBase;
            carry = (num01[i] + num02[i] + carry) / numeralBase;
        }
        sumArray[sumArray.Length - 1] = carry;

        int firstCharPosition = sumArray.Length - 1;

        if (sumArray[sumArray.Length - 1] == 0)
        {
            firstCharPosition = sumArray.Length - 2;
        }

        for (int i = firstCharPosition; i >= 0; i--)
        {
            sum += sumArray[i].ToString();
        }
        
        return sum;
    }       
}

