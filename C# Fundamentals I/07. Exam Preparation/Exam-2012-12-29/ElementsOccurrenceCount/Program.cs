using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsOccurrenceCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var cardsHandList = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                cardsHandList.Add(int.Parse(Console.ReadLine()));
            }

            var groupedHand = cardsHandList.GroupBy(i => i);

            foreach (var grp in groupedHand)
            {
                //Console.WriteLine("Element: {0} - counts: {1}", grp.Key, grp.Count());
                if (grp.Count() == 5)
                {
                    Console.WriteLine("Impossible");
                }
                
                
            }            
        }
    }
}
