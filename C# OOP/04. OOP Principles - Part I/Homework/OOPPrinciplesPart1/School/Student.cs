using System;

namespace School
{
    /// <summary>
    /// Class used for describing the features of a single school student
    /// Implements the ICommentable interface so that optional comments could be added for every student
    /// </summary>
    public class Student: Human, ICommentable
    {
        private int? classNumber;        

        public Student(string name, int? classNumber, string comment): base(name, comment)
        {
            this.ClassNumber = classNumber;
        }

        public Student(string name, int? classNumber): this(name, classNumber, null)
        {            
        }
        
        public Student(): this(null, null, null)
        {
        }

        public int? ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            set
            {
                this.classNumber = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Class ID: {0, -2:00}, Student Name: {1}, Comment: {2}", this.ClassNumber, this.Name, this.Comment);
        }
    }
}
