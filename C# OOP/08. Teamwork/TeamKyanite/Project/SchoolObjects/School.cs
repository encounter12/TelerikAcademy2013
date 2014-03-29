namespace TeamKyanite.SchoolObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class School
    {
        // Fields        
        private List<SchoolClass> classes;

        // Constructors
        public School(List<SchoolClass> classes)
        {
            this.Classes = classes;
        }

        public School() : this(null)
        {
        }

        // Properties
        public virtual List<SchoolClass> Classes
        {
            get { return this.classes; }
            set { this.classes = value; }
        }

        public int SchoolId { get; set; }

        // Methods
        public override string ToString()
        {
            string schoolString = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("School Details:");

            foreach (var schoolClass in this.Classes)
            {
                sb.AppendLine(schoolClass.ToString());
            }
           
            schoolString = sb.ToString();
            return schoolString;
        }
    }
}
