namespace ComputerBuildingSystem.Components
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class HardDrive
    {
        private int capacity;
        private Dictionary<int, string> data;
        
        public HardDrive(int capacity)
        {
            this.Capacity = capacity;
            this.Data = new Dictionary<int, string>();
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                this.capacity = value;
            }
        }

        public Dictionary<int, string> Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public void SaveTextData(int address, string text)
        {
            this.Data.Add(address, text);

        }

        public string LoadTextData(int address, string text)
        {
            string extractedText;
            if (this.Data.ContainsKey(address))
            {
                extractedText = this.Data[address];
                return extractedText;
            }
            else
            {
                throw new ArgumentException("The address does not exist");
            }
        }
    }
}