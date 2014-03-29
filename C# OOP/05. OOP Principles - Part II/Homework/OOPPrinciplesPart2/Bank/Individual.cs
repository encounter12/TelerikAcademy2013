using System;

namespace Bank
{
    public class Individual: Customer
    {
        private string firstName;
        private string lastName;
        
        public Individual(string firstName, string lastName): base()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Individual(string firstName, string lastName, Account account)
            : base(account)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
       
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }        
    }
}
