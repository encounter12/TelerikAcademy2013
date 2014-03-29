using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountVariableTypes
{
    public class Holder
    {

        private string firstName = null;
        private string middleName = null;
        private string lastName = null;


        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }

        }
        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public Holder(string holderFirstName, string holderMiddleName, string holderLastName)
        {
            firstName = holderFirstName;
            middleName = holderMiddleName;
            lastName = holderLastName;
        }
    }
}
