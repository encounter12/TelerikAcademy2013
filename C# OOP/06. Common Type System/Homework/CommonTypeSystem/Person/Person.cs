using System;

namespace Person
{
    class Person
    {
        private string name;
        private int? age;

        public Person(string name): this(name, null)
        {
        }

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
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

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Person's Name: {0}\nAge: {1}", 
                this.Name, this.Age == null ? "not specified" : this.Age.ToString());
        }
    }
}
