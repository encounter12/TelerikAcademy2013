﻿namespace TeamKyanite.SchoolObjects
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using TeamKyanite;

    public class SchoolClass : ICommentable
    {
        // Fields
        private ICollection<Student> students;

        private ICollection<Subject> subjects;

        private string textId;

        private string comment;

        private bool queuedForDeletion = false;
        
        
        // Constructors
        public SchoolClass(ICollection<Student> students, string textId, ICollection<Subject> subjects, string comment)
        {
            this.Students = students;
            this.TextId = textId;
            this.Comment = comment;
            this.Subjects = subjects;
        }

        public SchoolClass(ICollection<Student> students, string textId, ICollection<Subject> subjects)
            : this(students, textId, subjects, null)
        {
        }

        public SchoolClass() //: this(null, null, null, null)
        {          
            this.Subjects = new List<Subject>();
            this.students = new List<Student>();
        }

        // Properties  
        public int SchoolClassId { get; set; }


        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
       
        public ICollection<Subject> Subjects
        {
            get { return this.subjects; }
            set { this.subjects = value; }
        }
        
        public string TextId
        {
            get { return this.textId; }
            set { this.textId = value; }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public bool QueuedForDeletion
        {
            get { return this.queuedForDeletion; }
            set { this.queuedForDeletion = value; }
        }

        // Methods        
        public override string ToString()
        {
            string classString = string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append("Class Text ID: ").Append(this.TextId).Append(", Comment(optional): ").AppendLine(this.Comment);
            sb.AppendLine("Students List:");

            foreach (var student in this.Students)
            {
                sb.AppendLine(student.ToString());
            }
            
            classString = sb.ToString();
            return classString;
        }
    }
}