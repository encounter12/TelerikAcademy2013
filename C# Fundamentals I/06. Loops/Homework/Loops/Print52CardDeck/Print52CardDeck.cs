using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print52CardDeck
{
    class Print52CardDeck
    {
        static void Main()
        {
            string[] suit = new string[] {"Spades", "Hearts", "Diamonds", "Clubs"};            
            object[] rank = new object[] {"Ace", 2, 3, 4, 5, 6, 7, 8, 9, 10, "Jack", "Queen", "King"};

            Console.WriteLine("The standard 52 Cards Deck consists of:");

            for (int i = 0; i < suit.Length; i++)
            {
                for (int m = 0; m < rank.Length; m++)
                {
                    Console.WriteLine(rank[m] + " of " + suit[i]);
                }
            }
        }
    }
}
