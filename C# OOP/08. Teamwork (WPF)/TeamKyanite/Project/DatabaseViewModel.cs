using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamKyanite.SchoolObjects
{
    class DatabaseViewModel
    {
        public DatabaseViewModel()
        {

        }
        private SchoolDatabaseContext db = new SchoolDatabaseContext();
        private ICollection<Student> students;
        private ICollection<Teacher> teachers;
        private ICollection<Subject> subjects;
        private ICollection<SchoolClass> classes;
        private ICollection<Account> accounts;

        public ICollection<Account> Accounts
        {
            get
            {
                if (this.accounts == null)
                {
                   this.accounts = new List<Account>();
                   foreach (var account in db.Accounts)
                   {
                       this.accounts.Add(account);
                   }
                }
                return this.accounts;
            }
            set { accounts = value; }
        }

        public ICollection<SchoolClass> Classes
        {
            get
            {
                if (this.classes == null)
                {
                    this.classes = new List<SchoolClass>();
                    foreach (var c in db.SchoolClasses)
                    {
                        this.classes.Add(c);
                    }
                }
                return this.classes;
            }
            set { classes = value; }
        }

        public ICollection<Subject> Subjects
        {
            get
            {
                if (this.subjects == null)
                {
                    this.subjects = new List<Subject>();
                    foreach (var subject in db.Subjects)
                    {
                        this.subjects.Add(subject);
                    }
                }
                return this.subjects;
            }
            set { subjects = value; }
        }

        public ICollection<Teacher> Teachers
        {
            get
            {
                if (this.teachers == null)
                {
                    this.teachers = new List<Teacher>();
                    foreach (var teach in db.Teachers)
                    {
                        this.teachers.Add(teach);
                    }
                }
                return this.teachers;
            }
            set { teachers = value; }
        }

        public ICollection<Student> Students
        {
            get
            {
                if (this.students == null)
                {
                    this.students = new List<Student>();
                    foreach (var student in db.Students)
                    {
                        this.students.Add(student);
                    }
                }
                return this.students;
            }
            set { students = value; }
        }


    }
}
