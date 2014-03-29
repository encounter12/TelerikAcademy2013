using System;
using System.Numerics;

class NineGagNumbers
{
    static string ConvertNineGagInputStringToNineGagNumberString(string[] nineGagBase, string nineGagInputString)
    {
        string nineGagNumberString = "";

        string currentString = "";
        
        int currentDigit = 0;

        for (int currentSymbolPosition = 0; currentSymbolPosition < nineGagInputString.Length; currentSymbolPosition++)
        {            
            currentString += nineGagInputString[currentSymbolPosition];

            for (int i = 0; i < nineGagBase.Length; i++)
            {
                if (currentString == nineGagBase[i])
                {
                    currentDigit = i;
                    nineGagNumberString += currentDigit.ToString();
                    currentString = "";
                    break;
                }                
            }

        }
     
        return nineGagNumberString;
    }

    static BigInteger ConvertNumberStringToDecimal(string nineGagNumberString, int numeralSystemBase)
    {
        BigInteger decimalNumber = 0;
        
        for (int i = nineGagNumberString.Length - 1; i >= 0 ; i--)
        {
            int currentPosition = nineGagNumberString.Length - i - 1;
            decimalNumber += int.Parse(nineGagNumberString[i].ToString()) * PowerOfN(numeralSystemBase, currentPosition);
        }

        return decimalNumber;

    }

    static BigInteger PowerOfN(int inputNumber, int power)
    {
        BigInteger powerOfN = 1;
        for (int i = 0; i < power; i++)
        {
            powerOfN *= inputNumber;   
        }
        return powerOfN;
    }
 

    static void Main()
    {
        string[] nineGagBase = new string[]
        {
            "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-"
        };

        string nineGagInputString = Console.ReadLine();
        string nineGagNumber = ConvertNineGagInputStringToNineGagNumberString(nineGagBase, nineGagInputString);

        BigInteger decimalNumber = ConvertNumberStringToDecimal(nineGagNumber, nineGagBase.Length);

        Console.WriteLine(decimalNumber);

    }
}