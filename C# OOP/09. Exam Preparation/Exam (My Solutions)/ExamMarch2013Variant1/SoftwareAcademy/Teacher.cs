using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
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