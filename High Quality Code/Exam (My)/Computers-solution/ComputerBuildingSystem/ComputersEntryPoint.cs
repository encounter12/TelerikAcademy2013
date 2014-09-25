
namespace ComputerBuildingSystem
{
    using ComputerBuildingSystem.Factories;

    internal class ComputersEntryPoint
    {
        private static void Main()
        {
            string manufacturer = "";

            if (manufacturer == "Dell")
            {
                DellComputerFactory dellComputers = new DellComputerFactory();
            }
        }
    }
}