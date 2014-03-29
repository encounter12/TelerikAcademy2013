using System;

class NumberSequence
{
    static void Main()
    {
        int number = 2;
        int currentNumber = 0;
        int positiveNumber = Math.Abs(number);

        for (int i = 0; i < 10; i++)
        {                       
            if (number>=0)
            {
                currentNumber = (int)Math.Pow(-1, i) * positiveNumber;               
                positiveNumber++;               
            }
            else
            {
                currentNumber = (int)Math.Pow(-1, i + 1) * positiveNumber;
                positiveNumber++;
            }
            Console.Write("{0} ", currentNumber);                         
        }
    }
}

