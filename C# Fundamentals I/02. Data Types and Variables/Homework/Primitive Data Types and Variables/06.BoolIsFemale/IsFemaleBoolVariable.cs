using System;

class IsFemaleBoolVariable
{
    static void Main()
    {
        char myAnswer;
        bool correctUserInput = false;
        do
        {
            Console.WriteLine("Are you male or female [M,F]?");
            correctUserInput = Char.TryParse(Console.ReadLine().ToLower(), out myAnswer);
            switch (myAnswer)
            {
                case 'm':                    
                    break;
                case 'f':
                    break;
                default:
                    correctUserInput = false;
                    break;
            }

        } while (!correctUserInput);
        
        bool isFemale;
        isFemale = myAnswer == 'f';
        Console.WriteLine("isFemale = {0}", isFemale);
    }
}
