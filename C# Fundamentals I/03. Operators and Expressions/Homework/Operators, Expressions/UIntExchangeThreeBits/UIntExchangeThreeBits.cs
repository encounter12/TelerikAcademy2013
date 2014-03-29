using System;
using System.Collections.Generic;


namespace ExchangeThreeBits
{
    class UIntExchangeThreeBits
    {
        static void Main()
        {
            Console.WindowWidth = 100;
            uint uintNumber;
            bool userInputCorrect = false;
            byte k = 3;
            do
            {
                Console.Clear();
                Console.WriteLine("This program replaces 3rd, 4th and 5th bit with 24th, 25th and 26th bit of 32-bit unsigned integer");
                Console.Write("Please enter the unsigned integer: ");
                userInputCorrect = uint.TryParse(Console.ReadLine().Trim(), out uintNumber);
                if (!userInputCorrect)
                {
                    Console.WriteLine("You have entered incorrect number. Please re-enter.");
                    Console.ReadLine();
                }
                
            } while (!userInputCorrect);
            
            Console.WriteLine(String.Format("{0,-34} {1,-34}", "Unsigned integer binary value =", Convert.ToString(uintNumber, 2).PadLeft(32, '0')));

            uint[] bitsP = new uint[k];
            uint[] bitsQ = new uint[k];

            for (byte m = 3; m <= 5; m++)
            {
                uint mask = 1u << m;
                uint result = uintNumber & mask;

                bitsP[m - 3] = result >> m;
            }

            for (byte n = 24; n <= 26; n++)
            {
                uint mask = 1u << n;
                uint result = uintNumber & mask;

                bitsQ[n - 24] = result >> n;
            }
            uint resultReplace = uintNumber;
            uint maskReplace;
            for (byte s = 24; s <=26; s++)
            {

                if (bitsP[s-24] == 1)
                {
                    maskReplace = 1u << s;
                    resultReplace = resultReplace | maskReplace;

                }
                else
                {
                    maskReplace = ~(1u << s);
                    resultReplace = resultReplace & maskReplace;
                }
            }
            for (byte s = 3; s <= 5; s++)
            {

                if (bitsQ[s-3] == 1)
                {
                    maskReplace = 1u << s;
                    resultReplace = resultReplace | maskReplace;

                }
                else
                {
                    maskReplace = ~(1u << s);
                    resultReplace = resultReplace & maskReplace;
                }
            }
            Console.WriteLine("{0,-34} {1,-34}", "Result integer =", resultReplace);
            Console.WriteLine(String.Format("{0,-34} {1,-34}", "Result integer binary value =", Convert.ToString(resultReplace, 2).PadLeft(32, '0')));
            Console.ReadLine();
        }
    }
}
