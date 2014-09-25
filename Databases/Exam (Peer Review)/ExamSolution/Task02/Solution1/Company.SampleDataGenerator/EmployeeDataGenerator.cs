using System;
using System.Linq;
using Company.Data;

namespace Company.SampleDataGenerator
{
    internal class EmployeeDataGenerator : DataGenerator, IDataGenerator
    {
        public EmployeeDataGenerator(IRandomDataGenerator randomDataGenerator, Company20140908Entities company20140908Entities, int countOfGeneratedObjects)
            : base(randomDataGenerator, company20140908Entities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var managerIds = this.Database.Employees.Select(m => m.ManagerId).ToList();
            var departmentIds = this.Database.Departments.Select(d => d.Id).ToList();
            var reportIds = this.Database.Reports.Select(r => r.Id).ToList();

            Console.WriteLine("Adding employees");
            
            for (int i = 0; i < this.Count; i++)
            {
                // these are the 5% of the cases in which the employees are managers themselves and do not have managers above them
                if (i % 20 == 0)
                {
                    var employee = new Employee
                    {
                        FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                        LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                        AnnualSalary = this.Random.GetRandomNumber(50000, 200000),
                        DepartmentId = departmentIds[this.Random.GetRandomNumber(1, departmentIds.Count - 1)],
                        ReportId = reportIds[this.Random.GetRandomNumber(1, reportIds.Count - 1)]
                    };

                    this.Database.Employees.Add(employee);
                }
                // these are the 95% of the cases in which the employees have ususal managers
                else
                {
                    var employee = new Employee
                    {
                        FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                        LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                        AnnualSalary = this.Random.GetRandomNumber(50000, 200000),
                        ManagerId = managerIds[this.Random.GetRandomNumber(1, managerIds.Count - 1)],
                        DepartmentId = departmentIds[this.Random.GetRandomNumber(1, departmentIds.Count - 1)],
                        ReportId = reportIds[this.Random.GetRandomNumber(1, reportIds.Count - 1)]
                    };

                    this.Database.Employees.Add(employee);
                }

                //var employee = new Employee 
                //{
                //    FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                //    LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                //    AnnualSalary = this.Random.GetRandomNumber(50000, 200000),
                //    ManagerId = managerIds[this.Random.GetRandomNumber(1, managerIds.Count - 1)],
                //    DepartmentId = departmentIds[this.Random.GetRandomNumber(1, departmentIds.Count - 1)],
                //    ReportId = reportIds[this.Random.GetRandomNumber(1, reportIds.Count - 1)]
                //};

                //this.Database.Employees.Add(employee);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nEmployees added");
        }
    }
}
