using System;

namespace Bank
{
    /// <summary>
    /// This class is abstract because the method WithdrawMoney has different implementation in the derived classes
    /// All accounts have customer, balance and interest rate (monthly based). 
    /// </summary>
    public abstract class Account
    {
        protected decimal balance;
        protected decimal interestRate;
        protected Customer customer;

        public Account(decimal initialMoney)
        {
            this.Balance = initialMoney;
        }
       
        public decimal InterestRate
        {
            get
            {
                return interestRate;
            }
            set
            {
                interestRate = value;
            }
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

                    
        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public abstract void WithdrawMoney(decimal amount);

        /// calculates interest amount for a given period (months)
        ///the interest rate is expressed in percents
        public virtual decimal CalculateInterest(int months)
        {
            decimal interestAmount = 0;

            interestAmount = this.Balance * months * this.InterestRate / 100m;

            return interestAmount;
        }
                
    }
}
