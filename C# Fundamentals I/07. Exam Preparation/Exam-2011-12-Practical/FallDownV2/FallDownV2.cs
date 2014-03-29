using System;

class FallDownV2
{
    static void Main()
    {
        int numbersCount = 8;
        byte[] inputNumbers = new byte[numbersCount];            

        for (int i = 0; i < numbersCount; i++)
        {
            inputNumbers[i] = byte.Parse(Console.ReadLine());
        }

        byte mask = 0;

        for (int i = 0; i < numbersCount; i++)
        {
            for (int j = numbersCount - 1; j > 0; j--)
            {
                mask = inputNumbers[j];
                inputNumbers[j] |= inputNumbers[j - 1];
                inputNumbers[j - 1] &= mask;                    
            }
                Console.WriteLine(inputNumbers[i]);
        }            
    }
}

