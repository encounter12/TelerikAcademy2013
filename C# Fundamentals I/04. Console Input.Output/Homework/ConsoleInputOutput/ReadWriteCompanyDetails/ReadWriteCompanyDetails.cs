using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteCompanyDetails
{
    class ReadWriteCompanyDetails
    {
        static void Main()
        {
            Console.WriteLine("Type the company name:");
            string companyName = Console.ReadLine();
            Console.WriteLine("Type the company address:");
            string companyAddress = Console.ReadLine();
            Console.WriteLine("Type the company phone number:");
            string companyPhone = Console.ReadLine();
            Console.WriteLine("Type the company fax number:");
            string companyFax = Console.ReadLine();
            Console.WriteLine("Type the company website:");
            string companyWebsite = Console.ReadLine();
            Console.WriteLine("Type the company manager first name:");
            string managerFirstName = Console.ReadLine();
            Console.WriteLine("Type the company manager last name:");
            string managerLastName = Console.ReadLine();
            Console.WriteLine("Type the company manager age:");
            byte managerAge = byte.Parse(Console.ReadLine());
            Console.WriteLine("Type the company manager phone No.:");
            string managerPhoneNo = Console.ReadLine();

            Manager manager = new Manager(managerFirstName, managerLastName, managerAge, managerPhoneNo);

            Company company = new Company(companyName, companyAddress, companyPhone, companyFax, companyWebsite, manager);
            

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Company Name: {0}",  company.Name);
            Console.WriteLine("Company Address: {0}", company.Address);
            Console.WriteLine("Company Phone No: {0}", company.Phone);
            Console.WriteLine("Company Fax No: {0}", company.Fax);
            Console.WriteLine("Company website: {0}", company.Website);
            Console.WriteLine();
            Console.WriteLine("Manager's First Name: {0}", company.Manager.FirstName);
            Console.WriteLine("Manager's Last Name: {0}", company.Manager.LastName);
            Console.WriteLine("Manager's Age: {0}", company.Manager.Age);
            Console.WriteLine("Manager's Phone No: {0}", company.Manager.Phone);
        }
    }
}
