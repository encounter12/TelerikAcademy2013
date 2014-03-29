using System;

class TripleRotationOfDigits
{
    static void Main()
    {
        string initialNumberString = Console.ReadLine();

        string resultNumberString = initialNumberString;

        for (int i = 0; i < 3; i++)
        {
            char lastDigitChar = resultNumberString[resultNumberString.Length - 1];
            resultNumberString = resultNumberString.Remove(resultNumberString.Length - 1, 1);

            if (lastDigitChar != '0') // (int)Char.GetNumericValue(lastDigitChar) != 0; !lastDigitChar.Equals('0'); Convert.ToInt32(lastDigitChar) - '0') != 0 
            {

                resultNumberString = lastDigitChar + resultNumberString;
            }
            
        }

        Console.WriteLine(resultNumberString);
    }
}