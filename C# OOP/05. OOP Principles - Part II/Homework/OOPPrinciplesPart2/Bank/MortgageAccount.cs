using System;

namespace Bank
{
    /// <summary>
    /// The MortgageAccount class derive from Account and can only deposit money.
    /// </summary>
    public class MortgageAccount: Account
    {
        private static int individualDiscountMonths = 6;
        private static int companyDiscountMonths = 12;
        

        public MortgageAccount(decimal initialMoney): base(initialMoney)
        {
            this.InterestRate = 1.4m;
        }
               
        public static int CompanyDiscountMonths
        {
            get
            {
                return companyDiscountMonths;
            }
            set
            {
                companyDiscountMonths = value;
            }
        }

        public static int IndividualDiscountMonths
        {
            get
            {
                return individualDiscountMonths;
            }
            set
            {
                individualDiscountMonths = value;
            }
        }
        
        public override void WithdrawMoney(decimal amount)
        {
            throw new Exception("Money cannot be withdrawn from this type of account");
        }

        //Mortgage accounts have 1/2 interest for the first 12 months for companies and no interest for the first 6 months for individuals.

        public override decimal CalculateInterest(int months)
        {
            decimal interestAmount = 0m;

            if (this.Customer is Company)
            {
                if (months <= companyDiscountMonths)
                {
                    interestAmount = 0.5m * (this.Balance * interestRate * months) / 100m;
                }
                else
                {
                    interestAmount = (0.5m * (this.Balance * interestRate * companyDiscountMonths) +
                        (this.Balance * interestRate * (months - companyDiscountMonths))) / 100m;
                }
            }
            else if (this.Customer is Individual)
            {
                if (months <= individualDiscountMonths)
                {
                    interestAmount = 0;
                }
                else
                {
                    interestAmount = (this.Balance * interestRate * (months - individualDiscountMonths)) / 100m;
                }
            }
            return interestAmount;
        }
    }
}
