using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountClasses
{
    public class BankAccount
    {
        private Holder accountHolder = null;
        private decimal balance = 0m;
        private string iban = null;
        private List<Card> cardsList = null;

        public Holder AccountHolder
        {
            get { return accountHolder; }
            set { accountHolder = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public string IBAN
        {
            get { return iban; }
            set { iban = value; }
        }

        public List<Card> CardsList
        {
            get { return cardsList; }
            set { cardsList = value; }
        }

        public BankAccount(Holder accountHolder, decimal balance, string iban)
        {
            this.accountHolder = accountHolder;
            this.balance = balance;
            this.iban = iban;
        }

    }
}
