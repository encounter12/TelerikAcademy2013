using System;
using System.Collections.Generic;
using System.Linq;
using ComputerBuildingSystem.Computers;

namespace ComputerBuildingSystem.Factories
{
    interface IComputerFactory
    {
        List<Computer> CreateComputers();
    }
}
