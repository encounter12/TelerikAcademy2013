using System;
using System.Collections.Generic;

class MultiverseCommunication
{
    static long ConvertMultiverseToDecimal(List<string> multiverseBaseList, string multilverseCodeString)
    {
        string currentString = "";
        int numberBase = multiverseBaseList.Count;
        List<int> multiverseNumbers = new List<int>();
        long decimalNumber = 0;

        for (int currentSymbolPosition = 0; currentSymbolPosition < multilverseCodeString.Length; currentSymbolPosition++)
        {
            currentString += multilverseCodeString[currentSymbolPosition];

            for (int i = 0; i < multiverseBaseList.Count; i++)
            {
                if (currentString == multiverseBaseList[i])
                {
                    multiverseNumbers.Add(i);
                    currentString = "";
                    break;
                }
            }

        }

        for (int i = multiverseNumbers.Count - 1; i >= 0; i--)
        {
            decimalNumber += multiverseNumbers[i] * PowerOfN(numberBase, multiverseNumbers.Count - i - 1);
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
        List<string> multiverseBaseList = new List<string>()
        {
            "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA"
        };

        string multilverseCodeString =  Console.ReadLine();

        long result = ConvertMultiverseToDecimal(multiverseBaseList, multilverseCodeString);

        Console.WriteLine(result);
    }
}