using System;
using System.Collections.Generic;

namespace Student
{
    class Program
    {
        static void Main()
        {
            Student student1 = new Student
            {
                FirstName = "Petur",
                MiddleName = "Denev",
                LastName = "Kralimarkov",
                SSN = 1215,
                Email = "petur.kralimarkov@umaguma.com",
                PermanentAddress = "Sofia, Mladost 4, building 415, apt. 12",
                Specialty = Specialty.Math,
                Faculty = Faculty.Engineering
            };
       
            Student student2 = new Student
            {
                FirstName = "Ivan",
                MiddleName = "Dimitrov",
                LastName = "Stoychev",
                SSN = 2184,
                Email = "ivan.stoychev@unimaimuni.com",
                PermanentAddress = "Sofia, Dragalevtsi, 105 Biala Reka st",
                Specialty = Specialty.Literature,
                Faculty = Faculty.Arts

            };

            List<Student> students = new List<Student>() { student1, student2};

            foreach (Student student in students)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }

            Console.WriteLine("Student1 and student2 are equal: {0}", student1.Equals(student2));
            Console.WriteLine("Student1 and student2 are different: {0}\n", student1 != student2);

            Console.WriteLine("Student1 Hash Code: {0}", student1.GetHashCode());
            Console.WriteLine("Student2 Hash Code: {0}", student2.GetHashCode());
            Console.WriteLine();
            
            //Deep Copying student1 to student3
            Student student3 = (Student)student1.Clone();
           
            Console.WriteLine(student3);
            Console.WriteLine();

            Console.WriteLine("student1 precedes student2: {0}", student1 < student2);
            Console.WriteLine("student1 equal to student3: {0}", student1 == student3);

        }
    }
}
