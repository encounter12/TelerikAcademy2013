using System;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab) : base()
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
}