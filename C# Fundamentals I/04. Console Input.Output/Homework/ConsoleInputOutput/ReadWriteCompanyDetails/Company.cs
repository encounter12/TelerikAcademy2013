using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteCompanyDetails
{
    public class Company
    {
        private string name = null;
        private string address = null;
        private string phone = null;
        private string fax = null;
        private string website = null;
        private Manager manager = null;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address= value;}

        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        public Manager Manager
        {
            get { return manager; }
            set { manager = value; }
        }



        public Company(string name, string address, string phone, string fax, string website, Manager manager)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.fax = fax;
            this.website = website;
            this.manager = manager;
        }


    }
}
