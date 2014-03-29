using System;
using System.Collections.Generic;
using System.Text;

class KaspichanNumbers
{
    static string ConvertDecimalToKaspichan(ulong decimalNumber, ulong numeralBase, List<string> kaspichanBaseList)
    {
        string kaspichanNumber = "";
        ulong remainder;
        ulong quotient = 1;
        StringBuilder sb = new StringBuilder();

        while (quotient != 0)
        {
            quotient = decimalNumber / numeralBase;
            remainder = decimalNumber % numeralBase;
            sb.Insert(0, kaspichanBaseList[(int)remainder]);
            decimalNumber = quotient;
        }

        kaspichanNumber = sb.ToString();
        return kaspichanNumber;
    }

    static void Main()
    {
        List<string> kaspichanBaseList = new List<string>();

        for (char number = 'A'; number <= 'Z'; number++)
        {
            kaspichanBaseList.Add(number.ToString());
        }

        int numberCounter = 25;

        StringBuilder builder = new StringBuilder();

        for (char i = 'a'; i <= 'i'; i++)
        {

            for (char j = 'A'; j <= 'Z'; j++)
            {
                builder.Clear();
                builder.Append(i).Append(j);
                kaspichanBaseList.Add(builder.ToString());
                numberCounter++;

                if (numberCounter == 255)
                {
                    break;
                }
            }
        }

        ulong numberBase = 256;
        ulong decimalNumber = ulong.Parse(Console.ReadLine());

        string result = ConvertDecimalToKaspichan(decimalNumber, numberBase, kaspichanBaseList);
        Console.WriteLine(result);
    }
}