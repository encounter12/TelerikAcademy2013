using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExtensionMethods
{
    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("Petko", "Penchev", 17),
                new Student("Dimitar", "Ivanov", 21), 
                new Student("Georgi", "Petkov", 23),
                new Student("Milena", "Slavova", 26),
                new Student("Petur", "Atanasov", 35),
                new Student("Slava", "Mincheva", 43),
            };
            
            Print(StudentsFirstNameBeforeLast(students));

            Console.WriteLine("\nStudents with age between {0} and {1}:", 18, 24);
            Print(StudentsWithAgeRange(students, 18, 24));

            Console.WriteLine("\nStudents sorted by first name and last name in descending order using Lambda expressions:");
            Print(SortStudentsDescending(students));

            Console.WriteLine("\nStudents sorted by first name and last name in descending order using LINQ query:");
            Print(SortStudentsDescendingLinq(students));

            List<int> numbers = new List<int> { 1, 4, -3, 15, 21, 45, 72, 42, 13, 63, 2 };

            Console.WriteLine("\nPrint all numbers from list that are divisble by 3 and 7 using Linq ext methods and Lambda expressions:");
            Print(NumbersDivisibleBy3And7LambdaExpressions(numbers));

            Console.WriteLine("\nPrint all numbers from list that are divisble by 3 and 7 using Linq query:");
            Print(NumbersDivisibleBy3And7LinqQuery(numbers));

        }

        //finds all students whose first name is before its last name alphabetically
        public static List<Student> StudentsFirstNameBeforeLast(List<Student> students)
        {
            var studentsList =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            return studentsList.ToList();
        }

        //Finds the first name and last name of all students with age between 18 and 24 using LINQ query
        public static IEnumerable<object> StudentsWithAgeRange(List<Student> students, int startAge, int endAge)
        {
            var studentsList =
                from student in students
                where student.Age >= startAge && student.Age <= endAge
                select new { FirstName = student.FirstName, LastName = student.LastName};

            return studentsList.ToList();
        }

        //Sorts the students by first name and last name in descending order using the extension methods OrderBy() and ThenBy() with lambda expressions 
        public static List<Student> SortStudentsDescending(List<Student> students)
        {
            List<Student> sortedStudents = students.OrderByDescending(student => student.FirstName).
                ThenByDescending(student => student.LastName).ToList();

            return sortedStudents;
        }

        //Sorts the students by first name and last name in descending order using LINQ Query
        public static IEnumerable<Student> SortStudentsDescendingLinq(List<Student> students)
        {
            var sortedStudents =
                from student in students
                orderby student.FirstName descending, student.LastName descending 
                select student;

            return sortedStudents;
        }

        public static List<int> NumbersDivisibleBy3And7LambdaExpressions(List<int> numbers)
        {
            List<int> numbersDivisibleBy3And7 = numbers.Where(number => (number % 21) == 0).ToList();
            return numbersDivisibleBy3And7;
        }

        //extracts from given array of integers all numbers that are divisible by 7 and 3
        public static List<int> NumbersDivisibleBy3And7LinqQuery(List<int> numbers)
        {
            var numbersDivisibleBy3And7 =
                from number in numbers
                where number % 21 == 0
                select number;
            return numbersDivisibleBy3And7.ToList();
        }

        //prints collection of objects on the console
        public static void Print(IEnumerable<object> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        //prints list of integer numbers on the cons
        public static void Print(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

    }
}
