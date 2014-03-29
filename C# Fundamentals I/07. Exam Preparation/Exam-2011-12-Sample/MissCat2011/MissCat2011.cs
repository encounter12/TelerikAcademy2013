using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class MissCat2011
{
    static void Main()
    {
        int judgeNumberN = int.Parse(Console.ReadLine());

        Dictionary<int, int> catsVotes = new Dictionary<int, int>();

        //adding the judges votes in a dictionary catsVotes
        for (int i = 0; i < judgeNumberN; i++)
        {
            int currentVoteCatNumber = int.Parse(Console.ReadLine());

            if (catsVotes.ContainsKey(currentVoteCatNumber))
            {
                catsVotes[currentVoteCatNumber] = catsVotes[currentVoteCatNumber] + 1;
            }
            else
            {
                catsVotes.Add(currentVoteCatNumber, 1);
            }
        }

        //sorts catsVotes dictionary according to values ascendingly   
        Dictionary<int, int> catsVotesSorted = (from entry in catsVotes orderby entry.Value ascending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
       
        List<int> highestVotesCats = new List<int>();

        //assigns the keys of highets value into a list     
        for (int i = catsVotesSorted.Count - 1; i >= 0; i--)
        {
            if (catsVotesSorted.ElementAt(i).Value < catsVotesSorted.ElementAt(catsVotesSorted.Count - 1).Value)
            {
		        break;
            }

            highestVotesCats.Add(catsVotesSorted.ElementAt(i).Key);           
        }

        //sorts the list ascendingly
        highestVotesCats.Sort();

        //displays the lowest value - the cat having highest number of votes and lowest number 
        Console.Write(highestVotesCats[0]);
    }
}