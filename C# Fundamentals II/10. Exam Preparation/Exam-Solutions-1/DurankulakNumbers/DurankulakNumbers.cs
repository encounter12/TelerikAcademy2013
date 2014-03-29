using System;
using System.Collections.Generic;
using System.Text;

class DurankulakNumbers
{
    static long ConvertDurankulakToDecimal(List<string> durankulakBaseList, string durankulakInputString)
    {
        string currentString = "";
        int numberBase = durankulakBaseList.Count;
        List<int> durankulakNumbers = new List<int>();
        long decimalNumber = 0;

        for (int currentSymbolPosition = 0; currentSymbolPosition < durankulakInputString.Length; currentSymbolPosition++)
        {
            currentString += durankulakInputString[currentSymbolPosition];

            for (int i = 0; i < durankulakBaseList.Count; i++)
            {
                if (currentString == durankulakBaseList[i])
                {                    
                    durankulakNumbers.Add(i);
                    currentString = "";
                    break;
                }
            }

        }

        for (int i = durankulakNumbers.Count - 1; i >= 0; i--)
        {
            decimalNumber += durankulakNumbers[i] * PowerOfN(numberBase, durankulakNumbers.Count - i - 1);
        }

        return decimalNumber;

    }
   
    static long PowerOfN(int inputNumber, int power)
    {
        long powerOfN = 1;
        for (int i = 0; i < power; i++)
        {
            powerOfN *= inputNumber;
        }
        return powerOfN;
    }
    static void Main()
    {
        List<string> durankulakBaseList = new List<string>();

        for (char number = 'A'; number <= 'Z'; number++)
        {
            durankulakBaseList.Add(number.ToString());
        }

        int numberCounter = 25;

        StringBuilder builder = new StringBuilder();

        for (char i = 'a'; i <= 'f'; i++)
        {

            for (char j = 'A'; j <= 'Z'; j++)
            {
                builder.Clear();
                builder.Append(i).Append(j);
                durankulakBaseList.Add(builder.ToString());
                numberCounter++;

                if (numberCounter == 167)
                {
                    break;
                }
            }
        }

        int numberBase = 256;
        string durankulakInputString = Console.ReadLine();
        long decimalNumber = ConvertDurankulakToDecimal(durankulakBaseList, durankulakInputString);
        Console.WriteLine(decimalNumber);
    }
}

