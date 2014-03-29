using System;

class JoroTheRabbit
{
    static void SplitString(string str, string[] separator, out string[] splitStringArray)
    {
        splitStringArray = str.Split(separator, StringSplitOptions.None);        

    }

    static void Main()
    {
        string[] separatorString = new string[]{", "};

        string[] terrainStringArray; 
        string terrainInputString = Console.ReadLine();

        SplitString(terrainInputString, separatorString, out terrainStringArray);

        int[] terrainIntArray = Array.ConvertAll<string, int>(terrainStringArray, int.Parse);


        int jumpsMaxNumber = 0;
        
        //loop for increasing the step
        for (int step = 1; step <= terrainIntArray.Length; step++)
        {

            int currentStepJumpsMaxNumber = 0;

            //iterate through the start positions
            for (int startPosition = 0; startPosition < terrainIntArray.Length; startPosition++)
            {
                int currentRow = startPosition;                
                int previousPositonValue = terrainIntArray[startPosition];
                int currentStartPositionJumpsMaxNumber = 1;

                //loop for jumping with the specific step until reaching value lower then the current one
                while (true)
                {
                    
                    if (currentRow + step > terrainIntArray.Length - 1)
                    {
                        currentRow = (currentRow + step) - terrainIntArray.Length;
                    }
                    else
                    {
                        currentRow += step;
                    }
                   
                    if (terrainIntArray[currentRow] > previousPositonValue)
                    {
                        previousPositonValue = terrainIntArray[currentRow];
                        currentStartPositionJumpsMaxNumber++;
                    }
                    else
                    {
                        break;
                    }

                }

                if (currentStartPositionJumpsMaxNumber > currentStepJumpsMaxNumber)
                {
                    currentStepJumpsMaxNumber = currentStartPositionJumpsMaxNumber;
                }

            }

            if (currentStepJumpsMaxNumber > jumpsMaxNumber)
            {
                jumpsMaxNumber = currentStepJumpsMaxNumber;
            }

        }

        Console.WriteLine(jumpsMaxNumber);

    }
}