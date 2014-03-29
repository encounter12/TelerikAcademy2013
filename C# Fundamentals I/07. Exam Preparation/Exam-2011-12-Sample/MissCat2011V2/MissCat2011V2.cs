using System;

class MissCat2011V2
{
    static void Main()
    {
        int judgeNumberN = int.Parse(Console.ReadLine());

        //define and initialize an array with 10 elements equal to 0, the cats numbers are the indeces
        int[] catsVotes = new int[10];
        
        //increase the values of the cats that have been voted for
        for (int i = 0; i < judgeNumberN; i++)
        {
            int currentVoteCatNumber = int.Parse(Console.ReadLine());
            catsVotes[currentVoteCatNumber - 1] = catsVotes[currentVoteCatNumber - 1] + 1;
        }
        
        int highestNumberOfVotes = -1;
        int catWinnnerIndex = 0;

        //find the 1st occurrence of the highest number (highestNumberOfVotes) in the array and its respetive index (catWinnnerIndex)
        for (int i = 0; i < 10; i++)
        {
            if (catsVotes[i] > highestNumberOfVotes)
            {
                highestNumberOfVotes = catsVotes[i];
                catWinnnerIndex = i + 1;
            }
        }

        Console.WriteLine(catWinnnerIndex);
    }
}