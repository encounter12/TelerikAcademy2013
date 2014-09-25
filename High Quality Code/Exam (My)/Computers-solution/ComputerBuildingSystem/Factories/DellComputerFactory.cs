using System;
using System.Collections.Generic;
using System.Linq;
using ComputerBuildingSystem.Components;
using ComputerBuildingSystem.Computers;

namespace ComputerBuildingSystem.Factories
{
    internal class DellComputerFactory
    {

        public List<Computer> CreateComputers()
        {
            List<Computer> computers = new List<Computer>();
            
            Computer personalComputer = CreatePersonalComputer();
            computers.Add(personalComputer);
            
            Computer server = CreateServer();
            computers.Add(server);

            Computer laptop = CreateLaptop();
            computers.Add(laptop);

            return computers;
        }

        public PersonalComputer CreatePersonalComputer()
        {
            Cpu64Bit cpu = new Cpu64Bit(4);
            Ram ram = new Ram(8);
            List<HardDrive> hardDrives = new List<HardDrive>();
            hardDrives.Add(new HardDrive(1000));
            PersonalComputer pc = new PersonalComputer(cpu, ram, hardDrives, new MonochromeVideoCard());
            return pc;
        }

        public Server CreateServer()
        {
            Cpu64Bit cpu = new Cpu64Bit(8);
            Ram ram = new Ram(64);
            List<HardDrive> hardDrives = new List<HardDrive>();
            hardDrives.Add(new HardDrive(2000));
            hardDrives.Add(new HardDrive(2000));
            Server server = new Server(cpu, ram, hardDrives);
            return server;
        }

        public Laptop CreateLaptop()
        {
            Cpu32Bit cpu = new Cpu32Bit(4);
            Ram ram = new Ram(8);
            List<HardDrive> hardDrives = new List<HardDrive>();
            hardDrives.Add(new HardDrive(1000));
            Laptop laptop = new Laptop(cpu, ram, hardDrives, new ColorfulVideoCard());
            return laptop;
        }
    }
}
