using System;
using System.Linq;

namespace AcademyRPG
{
    public interface IControllable : IWorldObject
    {
        string Name { get; }
    }
}