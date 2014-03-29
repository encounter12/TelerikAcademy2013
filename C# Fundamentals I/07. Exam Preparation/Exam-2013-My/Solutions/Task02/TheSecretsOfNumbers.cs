using System;
using System.IO;
using System.Numerics;

class Program
{
    static void Main()
    {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
        string numberN = Console.ReadLine();
        BigInteger position = 1;
        BigInteger specialSum = 0;

        for (int i = numberN.Length - 1; i >= 0; i--)
        {

            if (position % 2 != 0)
            {
                specialSum += (BigInteger)(numberN[i] - '0') * (position * position);
            }
            else
            {
                specialSum += (BigInteger)(numberN[i] - '0') * (BigInteger)(numberN[i] - '0') * position;
            }

            position++;
        }

        //BigInteger alphaSequenceLength = GetDigitOnPosition(specialSum, 0);

        string specialSumString = specialSum.ToString();
        BigInteger alphaSequenceLength = specialSumString[specialSumString.Length - 1] - '0';

        BigInteger numberR = BigInteger.Remainder(specialSum, 26);
        BigInteger firstLetter = numberR + 1;

        if (firstLetter > 26)
        {
            firstLetter = (numberR + 1) % 26;
        }
    
        BigInteger currentLetter = firstLetter;
       
        Console.WriteLine(specialSum);

        if (alphaSequenceLength == 0)
        {
            Console.Write("{0} has no secret alpha-sequence", numberN);
        }        
        else
        {
           
            for (int i = 0; i < alphaSequenceLength; i++)
            {
                Console.Write((char)(currentLetter + 64));

                if (currentLetter == 26)
                {
                    currentLetter = 0;
                }
                
                currentLetter++;
            } 
        }        
    }

    //public static BigInteger GetDigitOnPosition(BigInteger specialSum, int position)
    //{
    //    BigInteger digit = (specialSum / (BigInteger)Math.Pow(10, position)) % 10;
    //    return digit;
    //}
}