namespace TeamKyanite.SchoolObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    
    /// <summary>
    /// Describes the features of a school discipline (e.g. Biology, Physics, Math, Geography, History)
    /// Has name, number of lectures and number of exercises
    /// ICommentable interface is implemented for optional comments 
    /// IEquatable is implemented so that subjects could be compared (needed in the SchoolTest.CreateSubjectsSet() method)  
    /// </summary>
    /// 
    public class Subject : ICommentable, IEquatable<Subject>
    {
        // Fields
        private string name;

        private int? lecturesNumber;

        private int? exercisesNumber;

        private Teacher teacher;

        private string comment;
        private ICollection<Convocation> convocations;

        // Constructors
        public Subject(string name, int? lecturesNumber, int? exercisesNumber, Teacher teacher, string comment)
        {
            this.Name = name;
            this.LecturesNumber = lecturesNumber;
            this.ExercisesNumber = exercisesNumber;           
            this.Teacher = teacher;
            this.Comment = comment;
            this.Convocations = new List<Convocation>();
        }

        public Subject(string name, int? lecturesNumber, int? exercisesNumber, Teacher teacher) 
            : this(name, lecturesNumber, exercisesNumber, teacher, null)
        {
        }

        public Subject() : this(null, null, null, null, null)
        {
        }
        
        // Properties
        public int SubjectId { get; set; }

        public virtual ICollection<Convocation> Convocations
        {
            get
            {
                return this.convocations;
            }
            set
            {
                this.convocations = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int? LecturesNumber
        {
            get { return this.lecturesNumber; }
            set { this.lecturesNumber = value; }
        }

        public int? ExercisesNumber
        {
            get { return this.exercisesNumber; }
            set { this.exercisesNumber = value; }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
        
        [Required]
        public Teacher Teacher
        {
            get { return this.teacher; }
            set { this.teacher = value; }
        }

        // Methods
        public bool Equals(Subject subject)
        {
            if (subject.Name == this.Name)
            {
                return true;
            }

            return false;
        }
    }
}