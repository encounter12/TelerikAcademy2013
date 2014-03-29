using System;

class NumberSequence
{
    static void Main()
    {
        int intNumber = 2;
        int intNumberAbsolute = Math.Abs(intNumber);
        int currentNumber = 0;
        int TermsNumber = 10;
        for (int i = intNumberAbsolute; i < intNumberAbsolute + TermsNumber; i++)
        {
            if (intNumber < 0) //this check is performed to keep the sequence in its closest form when the 1st term is changed to negative integer;
            {
                currentNumber = (int)Math.Pow(-1, i + 1) * i;
            }
            else
            {
                currentNumber = (int)Math.Pow(-1, i) * i;  
            }            
            Console.Write("{0} ", currentNumber);             
        }
    }
}

