using System;

namespace Bank
{
    public class Company: Customer
    {
        private string name;
        private string bulstat;

        public Company(string name, string bulstat): base()
        {
            this.Name = name;
            this.Bulstat = bulstat;
        }

        public Company(string name, string bulstat, Account account)
            : base(account)
        {
            this.Name = name;
            this.Bulstat = bulstat;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Bulstat
        {
            get
            {
                return this.bulstat;
            }
            set
            {
                this.bulstat = value;
            }
        }
    }
}
