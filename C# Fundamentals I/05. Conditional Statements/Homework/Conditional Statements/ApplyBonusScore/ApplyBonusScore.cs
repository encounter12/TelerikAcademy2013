using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyBonusScore
{
    class ApplyBonusScore
    {
        static void Main()
        {
            uint myScore = 0;
            bool bonus = true;

            do
            {
                Console.WriteLine("Please, enter score between 1 and 9: ");
            } while (uint.TryParse(Console.ReadLine(), out myScore) == false);

            switch (myScore)
            {
                case 1:
                case 2:
                case 3:
                    myScore *= 10;
                    break;
                case 4:
                case 5:
                case 6:
                    myScore *= 100;
                    break;
                case 7:
                case 8:
                case 9:
                    myScore *= 1000;
                    break;
                default:
                    Console.WriteLine("Invalid score!");
                    bonus = false;
                    break;
            }

            if (bonus)
            {
                Console.WriteLine("Your bonus score is " + myScore);
            }
        }
    }
}
