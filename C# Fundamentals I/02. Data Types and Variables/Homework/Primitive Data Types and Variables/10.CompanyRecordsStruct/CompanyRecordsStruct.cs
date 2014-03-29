using System;
using System.Text;

namespace CompanyRecordsStruct
{
    enum gender : byte
    {
        male = 0,
        female = 1
    }
    struct person
    {
        public string firstName;
        public string lastName;
        public byte age;
        public gender maleOrFemale;
        public uint id;
        public uint uniqueNumber;

    }

    class Program
    {
        static void Main()
        {
            person newEmployee;
            newEmployee.firstName = "Michael";
            newEmployee.lastName = "Jordan";
            newEmployee.age = 27;
            newEmployee.maleOrFemale = (gender)0;
            newEmployee.id = 5234;
            newEmployee.uniqueNumber = 27560000;
            Console.WriteLine("First Name: {0}", newEmployee.firstName);
            Console.WriteLine("Last Name: {0}", newEmployee.lastName);
            Console.WriteLine("Age: {0}", newEmployee.age);
            Console.WriteLine("Gender: {0}", newEmployee.maleOrFemale);
            Console.WriteLine("Employee ID: {0}", newEmployee.id);
            Console.WriteLine("Employee Number: {0}\n", newEmployee.uniqueNumber);
            
        }
    }
}
