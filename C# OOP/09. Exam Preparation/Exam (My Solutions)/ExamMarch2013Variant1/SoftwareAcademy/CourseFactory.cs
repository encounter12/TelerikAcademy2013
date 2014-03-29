using System;

namespace SoftwareAcademy
{
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
}