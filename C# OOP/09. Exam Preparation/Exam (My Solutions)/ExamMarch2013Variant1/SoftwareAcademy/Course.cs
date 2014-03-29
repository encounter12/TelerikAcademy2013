using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareAcademy
{
    class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        private List<string> topics = new List<string>();
        
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

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                this.teacher = value;
            }
        }

        public List<string> Topics
        {
            get
            {
                return this.topics;
            }
            set
            {
                this.topics = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.Topics.Add(topic);
        }
    }
}