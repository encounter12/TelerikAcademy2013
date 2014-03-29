using System;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town) : base()
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
}