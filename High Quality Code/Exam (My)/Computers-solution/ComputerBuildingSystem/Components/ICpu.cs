using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuildingSystem.Components
{
    interface ICpu
    {
        int GenerateRandomNumber(int min, int max);

        void SaveRandomNumberToRam(int number, Ram ram);

        double CalculateSquareNumber(Ram ram);
    }
}
