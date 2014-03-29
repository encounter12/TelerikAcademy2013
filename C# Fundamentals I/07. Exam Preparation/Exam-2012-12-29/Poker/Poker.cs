using System;
using System.Collections.Generic;

class Poker
{
    static void Main()
    {

        SortedDictionary<int, int> cardsHandDictionary = new SortedDictionary<int, int>();
        int cardsHandNumber;

        for (int i = 0; i < 5; i++)
        {
            string cardsHand = Console.ReadLine().ToLower().Trim();
            switch (cardsHand)
            {
                case "j":
                    cardsHandNumber = 11;
                    break;
                case "q":
                    cardsHandNumber = 12;
                    break;
                case "k":
                    cardsHandNumber = 13;
                    break;
                case "a":
                    cardsHandNumber = 14;
                    break;
                default:
                    cardsHandNumber = int.Parse(cardsHand);
                    break;
            }

            if (cardsHandDictionary.ContainsKey(cardsHandNumber))
            {
                cardsHandDictionary[cardsHandNumber] = cardsHandDictionary[cardsHandNumber] + 1;
            }
            else
            {
                cardsHandDictionary.Add(cardsHandNumber, 1);
            }
        }

        int consecutiveCardsNumber = 1;

        List<int> keyList = new List<int>(cardsHandDictionary.Keys);

        if (keyList.Count == 5)
        {
            for (int i = 0; i < 4; i++)
            {
                if (keyList[i] + 1 == keyList[i + 1])
                {
                    consecutiveCardsNumber++;
                }

            }
            if (keyList[0] == 2 && keyList[1] == 3 && keyList[2] == 4 && keyList[3] == 5 && keyList[4] == 14)
            {
                consecutiveCardsNumber = 5;
            }
            
        }               

        if (consecutiveCardsNumber == 5)
        {
            Console.WriteLine("Straight");
        }
        else if (cardsHandDictionary.ContainsValue(5))
        {
            Console.WriteLine("Impossible");
        }
       
        else if (cardsHandDictionary.ContainsValue(4))
        {
            Console.WriteLine("Four of a Kind");
        }
        else if (cardsHandDictionary.ContainsValue(3) && cardsHandDictionary.ContainsValue(2))
        {
            Console.WriteLine("Full House");
        }
        else if (cardsHandDictionary.ContainsValue(3))
        {
            Console.WriteLine("Three of a Kind");
        }
        else if (cardsHandDictionary.ContainsValue(2))
        {
            int pairsNumber = 0;
            foreach (var item in cardsHandDictionary)
            {
                if (item.Value == 2)
                {
                    pairsNumber++;
                }    
            }
            if (pairsNumber == 2)
            {
                Console.WriteLine("Two Pairs");
            }
            else
            {
                Console.WriteLine("One Pair");
            }
		 
        }                   
        else
        {
            Console.WriteLine("Nothing");
        }

    }
}

