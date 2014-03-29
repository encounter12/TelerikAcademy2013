using System;

class Anacci
{
    static void Main()
    {
        int term01 = Convert.ToChar(Console.ReadLine()) - 64;
        int term02 = Convert.ToChar(Console.ReadLine()) - 64;
        int term03 = term01 + term02;

        int linesNumberL = int.Parse(Console.ReadLine());

        if (linesNumberL == 1)
        {
            Console.WriteLine((char)(term01 + 64));
        }
        else
        {
            Console.WriteLine((char)(term01 + 64));
            Console.Write(((char)(term02 + 64)).ToString());

            for (int element = 0; element < 2 * linesNumberL - 3; element++)
            {
                
                if (term02 + term01 == 52)
                {
                    term03 = 26;
                }
                else if (term02 + term01 > 26)
                {
                    term03 = (term02 + term01) % 26;
                }
                else
                {
                    term03 = term02 + term01;
                }
                term01 = term02;
                term02 = term03;

                Console.Write(((char)(term03 + 64)).ToString());

                if (element % 2 != 0)
                {
                    for (int space = 0; space < (element + 1) / 2; space++)
                    {
                        Console.Write(" ");
                    }
                }
                if (element % 2 == 0)
                {
                    Console.WriteLine();
                }
            }
        }        
    }
}

