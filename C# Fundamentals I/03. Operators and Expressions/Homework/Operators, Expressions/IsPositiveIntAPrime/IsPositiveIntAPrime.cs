using System;

class IsPositiveIntAPrime
{
    static void Main()
    {
        //Primality test using trial division

        Console.WriteLine("THIS PROGRAM CHECKS IF A POSITIVE INTEGER IS A PRIME NUMBER");
        
        bool continueWithNumbers = false;
        bool userInputTypeCorrect = false;
        uint myPositiveInt = 0;
        do
        {
            do
            {
                Console.WriteLine("Please enter positive integer:");
                userInputTypeCorrect = UInt32.TryParse(Console.ReadLine(), out myPositiveInt);
                
            } while (!userInputTypeCorrect);
            
            uint squareRootInt = (UInt32)Math.Sqrt(myPositiveInt);
            bool isComposite = false;

            for (int i = 2; i <= squareRootInt; i++)
            {
                if (myPositiveInt % i == 0)
                {
                    isComposite = true;
                    break;
                }
            }

            if (isComposite)
            {
                Console.WriteLine("The number is COMPOSITE");
            }
            else
            {
                Console.WriteLine("The number is PRIME");
            }

            Console.WriteLine("Do you want to enter another number? [Y,N]");
            string enterNewNumber = Console.ReadLine().ToLower();
            switch (enterNewNumber)
            {
                case "y":
                    continueWithNumbers = true;
                    break;
                case "n":
                    continueWithNumbers = false;
                    break;
                default:
                    continueWithNumbers = true;
                    break;
            }
            Console.Clear();
            
        } while (continueWithNumbers);
        
    }
}
