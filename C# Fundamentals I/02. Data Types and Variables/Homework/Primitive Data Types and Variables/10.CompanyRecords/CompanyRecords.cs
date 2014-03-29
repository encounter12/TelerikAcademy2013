using System;
using System.Text;
using System.Collections.Generic;

      
class Program
{
    static void Main()
    {            
        bool enterNewEmployee = true;

        Dictionary<int, Person> employeeObjectsContainer = new Dictionary<int, Person>();

        while (enterNewEmployee && Person.Counter < 9999)
        {
            Console.WriteLine("PLEASE, ENTER THE NEW EMPLOYEE DETAILS\n");
            Console.WriteLine("Enter employee first name:");
            string newFirstName = Console.ReadLine();
            Console.WriteLine("Enter employee last name:");
            string newLastName = Console.ReadLine();

            Person newEmployee = new Person(newFirstName, newLastName);

            Console.WriteLine("Enter employee age:");
            newEmployee.Age = Byte.Parse(Console.ReadLine());

            Console.WriteLine("Enter employee gender: 1 - Male, 2 - Female, 3 - Unknown:");
            newEmployee.Sex = (Person.Gender)Byte.Parse(Console.ReadLine());

            employeeObjectsContainer.Add(newEmployee.UniqueNumber, newEmployee);

            Console.WriteLine("-----------------");

            Console.WriteLine("First Name: {0}", newEmployee.FirstName);
            Console.WriteLine("Last Name: {0}", newEmployee.LastName);
            Console.WriteLine("Age: {0}", newEmployee.Age);
            Console.WriteLine("Gender: {0}", newEmployee.Sex);
            Console.WriteLine("Employee ID: {0}", newEmployee.ID);
            Console.WriteLine("Employee Number: {0}\n", newEmployee.UniqueNumber);
            Console.WriteLine("-----------------");

            Console.WriteLine("Employees Unique Numbers: ");
            foreach (KeyValuePair<int, Person> employeeObj in employeeObjectsContainer)
            {
                Console.WriteLine(employeeObj.Key);
            }
            if (Person.Counter < 9999)
            {
                Console.WriteLine("Do you want to enter another new employee details [Y,N]?");
                string continueCycle = Console.ReadLine().ToLower();

                if (continueCycle == "y")
                {
                    enterNewEmployee = true;

                }
                else if (continueCycle == "n")
                {
                    enterNewEmployee = false;
                }                    
            }                
            Console.Clear();
        }  

    }
}


