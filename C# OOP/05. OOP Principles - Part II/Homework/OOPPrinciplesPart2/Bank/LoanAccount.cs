using System;

namespace Bank
{
    /// <summary>
    /// LoanAccount class derive from Account can only deposit money.
    /// </summary>
    public class LoanAccount: Account
    {
        /// Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
        private static int individualDiscountMonths = 3;
        private static int companyDiscountMonths = 2;        
        
        public LoanAccount(decimal initialMoney): base(initialMoney)
        {
            this.InterestRate = 1.2m;
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

        /// <summary>
        /// calculates the interest amount for a given period (months)
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public override decimal CalculateInterest(int months)
        {
            decimal interestAmount = 0;

            if (this.Customer is Individual)
            {
                if (months <= individualDiscountMonths)
                {
                    interestAmount = 0;
                }
                else
                {
                    interestAmount = (this.Balance * this.InterestRate * (months - individualDiscountMonths)) / 100m;   
                }
            }
            else if (this.Customer is Company)
            {
                if (months <= companyDiscountMonths)
                {
                    interestAmount = 0;
                }
                else
                {
                    interestAmount = (this.Balance * this.InterestRate * (months - companyDiscountMonths)) / 100m; 
                }
                
            }
            
            return interestAmount;
           
        }
       
    }
}
