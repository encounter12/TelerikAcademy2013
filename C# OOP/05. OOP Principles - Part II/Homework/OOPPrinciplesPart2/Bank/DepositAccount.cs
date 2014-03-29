using System;

namespace Bank
{
    /// <summary>
    /// Deposit accounts are allowed to deposit and withdraw money
    /// </summary>
    public class DepositAccount: Account
    {
        private static int noInterestBalance = 1000;
        

        public DepositAccount(decimal initialMoney): base(initialMoney)
        {
            this.InterestRate = 0.6m;
        }
        
        public static int NoInterestBalance
        {
            get
            {
                return noInterestBalance;
            }
            set
            {
                noInterestBalance = value;
            }
        }

        public override void WithdrawMoney(decimal amount)
        {
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            decimal interestAmount;

            //Deposit accounts have no interest if their balance is positive and less than noInterestBalance = 1000.
            if (this.Balance > 0 && this.Balance < noInterestBalance)
            {
                interestAmount = 0;
            }
            else
            {
                interestAmount = (this.Balance * interestRate * months) / 100m;
            }
            return interestAmount;
        }
    }
}
