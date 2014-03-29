using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftwareAcademy
{
    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = SoftwareAcademyCommandExecutor.ReadInputCSharpCode();
            SoftwareAcademyCommandExecutor.CompileAndRun(csharpCode);
        }

        internal static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        internal static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {" +
                csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }

    public interface ICourse
    {
        string Name { get; set; }

        ITeacher Teacher { get; set; }

        void AddTopic(string topic);

        string ToString();
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);

        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);

        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ITeacher
    {
        string Name { get; set; }

        void AddCourse(ICourse course);

        string ToString();
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            else if (name == String.Empty)
            {
                throw new ArgumentException();
            }
            else
            {
                return new Teacher(name);
            }
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            if (name == null || lab == null)
            {
                throw new ArgumentNullException();
            }
            else if (name == String.Empty || lab == String.Empty)
            {
                throw new ArgumentException();
            }
            else
            {
                return new LocalCourse(name, teacher, lab);
            }

        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            if (name == null || town == null)
            {
                throw new ArgumentNullException();
            }
            else if (name == String.Empty || town == String.Empty)
            {
                throw new ArgumentException();
            }
            else
            {
                return new OffsiteCourse(name, teacher, town);
            }
        }
    }

    class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        private List<string> topics = new List<string>();


        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                this.teacher = value;
            }
        }

        public List<string> Topics
        {
            get
            {
                return this.topics;
            }
            set
            {
                this.topics = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.Topics.Add(topic);
        }
    }

    class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base()
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Lab = lab;
        }
        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);

            if (this.Teacher != null)
            {
                sb.AppendFormat("; Teacher={0}", this.Teacher.Name);
            }
            if (this.Topics.Count > 0)
            {
                sb.Append("; Topics=[");
                foreach (string topic in this.Topics)
                {
                    sb.AppendFormat("{0}, ", topic);
                }
                sb.Length -= 2;
                sb.Append("]");
            }

            sb.AppendFormat("; Lab={0}", this.Lab);

            return sb.ToString();
        }
    }

    class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base()
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);

            if (this.Teacher != null)
            {
                sb.AppendFormat("; Teacher={0}", this.Teacher.Name);
            }
            if (this.Topics.Count > 0)
            {
                sb.Append("; Topics=[");
                foreach (string topic in this.Topics)
                {
                    sb.AppendFormat("{0}, ", topic);
                }
                sb.Length -= 2;
                sb.Append("]");
            }

            sb.AppendFormat("; Town={0}", this.Town);

            return sb.ToString();
        }
    }

    class Teacher : ITeacher
    {
        private string name;
        private List<ICourse> courses = new List<ICourse>();

        public Teacher(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public List<ICourse> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.Courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Teacher: Name={0}", this.Name);
            if (this.Courses.Count > 0)
            {
                sb.Append("; Courses=[");

                foreach (var course in this.Courses)
                {
                    sb.AppendFormat("{0}, ", course.Name);
                }
                sb.Length -= 2;
                sb.Append("]");
            }
            return sb.ToString();
        }
    }
}