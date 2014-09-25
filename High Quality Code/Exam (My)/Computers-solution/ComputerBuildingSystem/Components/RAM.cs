namespace ComputerBuildingSystem
{
    internal class Ram
    {
        private int amount;
        private int value;

        internal Ram(int amount)
        {
            this.Amount = amount;
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}