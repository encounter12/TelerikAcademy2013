namespace TeamKyanite.SchoolObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Containg methods for generating random classes, students, teachers and subjects
    /// </summary>
    public class SchoolTest
    {
        // Fields
        private static Random random = new Random();

        // Methods
        public static string CreateMaleName()
        {
            string name = null;
            List<string> firstNames = new List<string>()
            {
                "Andrew", "Toby", "Michelle", "Billie", "Carlo", "Bradley", "Stan", "Stefan", "Charles"
            };

            List<string> lastNames = new List<string>()
            {
                "Sinclair", "Manley", "Grimmer", "Antros", "Heinz", "Flemings", "Lakins", "Freestone", "Summers"
            };

            StringBuilder sb = new StringBuilder();

            string randomFirstName = firstNames[random.Next(0, 8)];
            string randomLastName = lastNames[random.Next(0, 8)];

            sb.Append(randomFirstName).Append(" ").Append(randomLastName);
            name = sb.ToString();
            sb.Clear();
            return name;
        }

        public static string CreateFemaleName()
        {
            string name = null;
            List<string> firstNames = new List<string>()
            {
                "Mellany", "Jaclean", "Angie", "Tiffany", "Christine", "Lu-vias", "Marry", "Milla", "Antonia"
            };

            List<string> lastNames = new List<string>()
            {
                "Sinclair", "Manley", "Grimmer", "Antros", "Heinz", "Flemings", "Lakins", "Freestone", "Summers"
            };

            StringBuilder sb = new StringBuilder();

            string randomFirstName = firstNames[random.Next(0, 8)];
            string randomLastName = lastNames[random.Next(0, 8)];

            sb.Append(randomFirstName).Append(" ").Append(randomLastName);
            name = sb.ToString();
            sb.Clear();
            return name;
        }

        public static School CreateSchool()
        {
            List<SchoolClass> classes = CreateClasses();
            School school = new School(classes);

            return school;
        }

        // Fill the arrays with random numbers
        private static int RandomYears()
        {
            int min = 10;
            int max = 16;
            int years = 0;
            years = random.Next(min, max);

            return years;
        }

        private static Student CreateMaleStudent(int classNumber)
        {
            Student maleStudent = new Student(CreateMaleName(), classNumber, "male", RandomYears());

            return maleStudent;
        }

        private static List<Student> CreateMaleStudents()
        {
            List<Student> maleStudents = new List<Student>();

            int studentsNumber = random.Next(10, 15);

            for (int i = 1; i < studentsNumber; i++)
            {
                Student student = CreateMaleStudent(i);
                maleStudents.Add(student);
                Thread.Sleep(3);
            }

            return maleStudents;
        }

        private static Student CreateFemaleStudent()
        {
            Student femaleStudent = new Student(CreateFemaleName(), "female", RandomYears());

            return femaleStudent;
        }

        private static List<Student> CreateFemaleStudents()
        {
            List<Student> femaleStudents = new List<Student>();

            int studentsNumber = random.Next(10, 15);

            for (int i = 1; i < studentsNumber; i++)
            {
                Student student = CreateFemaleStudent();
                femaleStudents.Add(student);
                Thread.Sleep(3);
            }

            return femaleStudents;
        }
        
        private static Teacher CreateTeacher()
        {
            string randomMaleName = CreateMaleName();
            Teacher teacher = new Teacher(randomMaleName);
            return teacher;
        }

        private static List<Subject> CreateSubjects()
        {
            List<string> subjectNames = new List<string>()
            {
                "Biology", "Physics", "Mathematics", "Chemistry", "Arts", "Literature", "Geography", "History"
            };

            List<Subject> subjects = new List<Subject>();

            int subjectsNumber = random.Next(6, subjectNames.Count + 1);

            for (int i = 0; i < subjectsNumber; i++)
            {
                int lecturesNumber = random.Next(12, 18);
                int excercisesNumber = random.Next(4, 7);
                Teacher teacher = CreateTeacher();
                Subject subject = new Subject(subjectNames[i], lecturesNumber, excercisesNumber, teacher);
                teacher.Subject = subject;
                Thread.Sleep(3);
            }

            return subjects;
        }
               
        private static SchoolClass CreateClass(string textId)
        {
            List<Subject> subjects = CreateSubjects();
            List<Student> allStudents = CreateMaleStudents().Concat(CreateFemaleStudents()).ToList();

            for (int i = 0; i < allStudents.Count; i++)
            {
                allStudents[i].ClassNumber = i + 1;
            }

            SchoolClass schoolClass = new SchoolClass(allStudents, textId, subjects);

            for (int i = 0; i < allStudents.Count; i++)
            {
                allStudents[i].SchoolClass = schoolClass;
            }

            return schoolClass;
        }

        private static List<SchoolClass> CreateClasses()
        {
            int classesNumber = random.Next(3, 5);
            List<SchoolClass> classes = new List<SchoolClass>();

            int randomGrade = random.Next(4, 8); 
            int lastLetter = Convert.ToChar(Convert.ToInt32('A') + classesNumber);

            string textId = string.Empty;
            for (char letter = 'A'; letter < lastLetter; letter++)
            {
                textId = randomGrade + letter.ToString();
                SchoolClass newClass = CreateClass(textId);
                classes.Add(newClass);
                Thread.Sleep(3);
            }

            return classes;
        }
    }
}
