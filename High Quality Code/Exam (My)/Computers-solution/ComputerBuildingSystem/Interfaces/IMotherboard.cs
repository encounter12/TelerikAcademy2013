using System;
using System.Linq;

namespace ComputerBuildingSystem.Interfaces
{
    interface IMotherboard 
    { 
        int LoadRamValue();
        void SaveRamValue(int value); 
        void DrawOnVideoCard(string data);
    }
}
