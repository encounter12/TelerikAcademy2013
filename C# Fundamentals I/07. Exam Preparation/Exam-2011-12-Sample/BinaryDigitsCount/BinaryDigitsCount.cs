using System;
using System.Collections.Generic;

class BinaryDigitsCount
{
    static void Main()
    {
        int digitB = int.Parse(Console.ReadLine());
        int numbersN = int.Parse(Console.ReadLine());

        int onesCount = 0;
        int zerosCount = 0;
        int zerosCountTemp = 0;
        int bitValue;
        uint number;
        List<int> digitsCount = new List<int>();

        for (int numbersCount = 0; numbersCount < numbersN; numbersCount++)
        {
            number = uint.Parse(Console.ReadLine());

            for (int positionCount = 0; positionCount < sizeof(uint) * 8; positionCount++)
            {

                bitValue = BitAtPosition(number, positionCount);
                if (bitValue == 1)
                {
                    onesCount++;
                    zerosCount += zerosCountTemp;
                    zerosCountTemp = 0;
                }
                else
                {
                    zerosCountTemp++;
                }

            }
            if (digitB == 1)
            {
                digitsCount.Add(onesCount);
            }
            else
            {
                digitsCount.Add(zerosCount);
            }

            onesCount = 0;
            zerosCount = 0;
            zerosCountTemp = 0;
        }

        foreach (var item in digitsCount)
        {
            Console.WriteLine(item);
        }
    }

    public static int BitAtPosition(uint number, int position)
    {
        int bitValue = (int)((number & 1 << position) >> position);
        return bitValue;
    }   

}