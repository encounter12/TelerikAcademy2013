using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteCompanyDetails
{
    public class Manager
    {
        private string firstName = null;
        private string lastName = null;
        private uint age = 0;
        private string phone = null;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public uint Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Manager(string firstName, string lastName, uint age, string phone)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.phone = phone;
        }
    }
}
