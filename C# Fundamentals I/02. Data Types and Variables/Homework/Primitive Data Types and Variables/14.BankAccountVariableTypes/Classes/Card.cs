using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountVariableTypes
{
    public class Card
    {
        private string cardNumber;

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }

        }

        public Card(string cardNumber)
        {
            this.cardNumber = cardNumber;
        }

    }
}
