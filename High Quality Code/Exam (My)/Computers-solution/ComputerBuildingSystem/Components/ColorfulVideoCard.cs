using System;
using System.Linq;

namespace ComputerBuildingSystem.Components
{
    class ColorfulVideoCard: IVideoCard
    {
        public ColorfulVideoCard()
        {
        }

        public void PrintOnConsole(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
