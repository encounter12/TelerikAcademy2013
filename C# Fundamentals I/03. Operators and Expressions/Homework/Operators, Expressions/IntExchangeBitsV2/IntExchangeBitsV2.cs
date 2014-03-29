using System;
using System.Collections.Generic;

namespace IntExchangeSpecificBits
{

    class IntExchangeBits
    {
        static void Main()
        {
            bool userInputTypeCorrect = false;
            bool userInputRangeCorrect = false;
            uint uintNumber;
            byte p, q, k;
            do
            {
                Console.Clear();
                Console.WriteLine(@"This program replaces bits {p, p+1,..., p+k-1} with {q, q+1,..., q+k-1} in integer number");

                Console.WriteLine("Please enter the integer:");
                string uintNumberString = Console.ReadLine().Trim();
                userInputTypeCorrect = UInt32.TryParse(uintNumberString, out uintNumber);

                Console.WriteLine("Please enter the starting bit position p:");
                string pString = Console.ReadLine().Trim();
                userInputTypeCorrect = Byte.TryParse(pString, out p);

                Console.WriteLine("Please enter the replacement starting bit position q:");
                string qString = Console.ReadLine().Trim();
                userInputTypeCorrect = Byte.TryParse(qString, out q);

                Console.WriteLine("Please enter the number of consequitive bits k to replace:");
                string kString = Console.ReadLine().Trim();
                userInputTypeCorrect = Byte.TryParse(kString, out k);

                if (!userInputTypeCorrect)
                {
                    Console.WriteLine("You have entered incorrect value type");
                }

                if ((p >= 0) && (p <= 31) && (q >= 0) && (q <= 31) && (k >= 1) && (k <= 32))
                {
                    userInputRangeCorrect = true;

                }
                else
                {
                    Console.WriteLine("The values you have entered are out of range");
                    userInputRangeCorrect = false;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();

            } while ((!userInputTypeCorrect) || (!userInputRangeCorrect));

            Console.WriteLine("Unsigned integer binary value = {0,40}", Convert.ToString(uintNumber, 2).PadLeft(32, '0'));

            uint[] bitsP = new uint[k];
            uint[] bitsQ = new uint[k];

            for (byte m = p; m <= p + k - 1; m++)
            {
                uint mask = 1u << m;
                uint result = uintNumber & mask;

                bitsP[m - p] = result >> m;
            }            
            for (byte n = q; n <= q + k - 1; n++)
            {
                uint mask = 1u << n;
                uint result = uintNumber & mask;

                bitsQ[n - q] = result >> n;
            }          
            uint resultReplace = uintNumber;
            uint maskReplace;

            for (byte s = 0; s < bitsP.Length; s++)
            {

                if (bitsP[s] == 1)
                {
                    maskReplace = 1u << q;
                    resultReplace = resultReplace | maskReplace;

                }
                else
                {
                    maskReplace = ~(1u << q);
                    resultReplace = resultReplace & maskReplace;
                }
                q++;
            }            
            for (byte s = 0; s < bitsQ.Length; s++)
            {

                if (bitsQ[s] == 1)
                {
                    maskReplace = 1u << p;
                    resultReplace = resultReplace | maskReplace;

                }
                else
                {
                    maskReplace = ~(1u << p);
                    resultReplace = resultReplace & maskReplace;
                }
                p++;
            }
            Console.WriteLine("Result integer = {0}", resultReplace);
            Console.WriteLine("Result integer binary value = {0,40}", Convert.ToString(resultReplace, 2).PadLeft(32, '0'));
            Console.ReadLine();
        }
    }
}
