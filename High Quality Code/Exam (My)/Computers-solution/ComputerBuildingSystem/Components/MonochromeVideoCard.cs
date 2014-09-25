using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildingSystem.Components
{
    class MonochromeVideoCard: IVideoCard
    {
        public void PrintOnConsole(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
