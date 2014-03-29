using System;
using System.Collections.Generic;

namespace Bank
{
    /// <summary>
    /// Customers could be individuals or companies (classes Individual and Company derive from Customer)
    /// </summary>
    public class Customer
    {
        //Each customer has a list of accounts
        private List<Account> accounts = new List<Account>();

        public Customer(Account account)
        {
            this.Accounts.Add(account);
            account.Customer = this;
        }

        public Customer()
        {
            
        }

        //each customer can deposit money and can withdraw money only if the account is Deposit one
        //for this purpose Account.WithdrawMoney is called and it throws Exception if customer tries to 
        //withdraw money from Loan or Mortgage account
        public void DepositMoney(int number, decimal amount)
        {
            this.Accounts[number].DepositMoney(amount);
        }

        public void WithdrawMoney(int number, decimal amount)
        {
            this.Accounts[number].WithdrawMoney(amount); 
        }

        public List<Account> Accounts
        {
            get
            {
                return this.accounts;
            }
            set
            {
                this.accounts = value;
            }
        }

        public void AddAccount(Account account)
        {
            this.Accounts.Add(account);
            account.Customer = this;
        }
        
    }
}
