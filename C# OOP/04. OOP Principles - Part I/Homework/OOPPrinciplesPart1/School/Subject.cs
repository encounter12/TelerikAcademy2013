using System;

namespace School
{
    /// <summary>
    /// Describes the features of a school discipline (e.g. Biology, Physics, Math, Geography, History)
    /// Has name, number of lectures and number of exercises
    /// ICommentable interface is implemented for optional comments 
    /// IEquatable is implemented so that subjects could be compared (needed in the SchoolTest.CreateSubjectsSet() method)  
    /// </summary>
    public class Subject: ICommentable, IEquatable<Subject>
    {
        private string name;
        private int? lecturesNumber;
        private int? exercisesNumber;
        private string comment;

        public Subject(string name, int? lecturesNumber, int? exercisesNumber, string comment)
        {
            this.Name = name;
            this.LecturesNumber = lecturesNumber;
            this.ExercisesNumber = exercisesNumber;
            this.Comment = comment;
        }

        public Subject(string name, int? lecturesNumber, int? exercisesNumber): this(name, lecturesNumber, exercisesNumber, null)
        {
        }

        public Subject(): this(null, null, null, null)
        {
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

        public int? LecturesNumber
        {
            get
            {
                return this.lecturesNumber;
            }
            set
            {
                this.lecturesNumber = value;
            }
        }

        public int? ExercisesNumber
        {
            get
            {
                return this.exercisesNumber;
            }
            set
            {
                this.exercisesNumber = value;
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

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
