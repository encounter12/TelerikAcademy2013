namespace School
{
    using System;
    using System.Linq;
    using System.Data.Linq;
    using System.Data.Objects;
    using System.Globalization;
    using System.Data.EntityClient;
    using System.Data.SqlClient;
    using System.Data.Common;
    using System.Collections.Generic;
    using TeamKyanite.SchoolObjects;

    public class SchoolConsoleApp
    {
        public static void Main()
        {
            //using (SchoolDatabaseContext context = new SchoolDatabaseContext())
            //{
            //    context.Database.Delete();
            //    School school = SchoolTest.CreateSchool();
            //    context.Schools.Add(school);
            //    context.SaveChanges();
            //}

             using (SchoolDatabaseContext context = new SchoolDatabaseContext())
             {
                 //List<School> schools = context.Schools.ToList();

                 //foreach (var school in schools)
                 //{\
                 //    Console.WriteLine(school);

                 //}
                 //var students = from s in context.Students
                 //               select s;
                 //var student = students.First(p => p.Name == "Tosho");

                 //var teachers = from t in context.Teachers
                 //               select t;
                 //var teacher = teachers.First(p => p.Name == "penka");
                 //var accounts = from a in context.Accounts
                 //               select a;
                 //var account = accounts.First(p => p.Username == "ui6358");
                 Teacher penka = new Teacher("penka");
                 
                 //Console.WriteLine(student.Account.Username);
                 //Console.WriteLine(account.Holder.Name);

                 context.Teachers.Add(penka);
                 Student gosho = new Student("Tosho", "male", 20);
                 context.Students.Add(gosho);
                 context.SaveChanges();




             }   
          
        }
    }
}
