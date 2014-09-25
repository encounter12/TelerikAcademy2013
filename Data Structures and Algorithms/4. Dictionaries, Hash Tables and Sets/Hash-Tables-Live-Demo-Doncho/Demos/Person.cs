using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos
{
    public class Person : IComparable<Person>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        //public bool Equals(Person value)
        //{
        //    if (ReferenceEquals(null, value))
        //    {
        //        return false;
        //    }
        //    if (ReferenceEquals(this, value))
        //    {
        //        return true;
        //    }
        //    return Equals(this.Firstname, value.Firstname) &&
        //           Equals(this.Lastname, value.Lastname);
        //}

        //public override int GetHashCode()
        //{
        //    return this.Firstname.GetHashCode() << 17 ^
        //                this.Lastname.GetHashCode() >> 17 &
        //                this.Firstname.GetHashCode() << 11;
        //}

        public Person(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }

        //public override bool Equals(object obj)
        //{
        //    var otherPerson = obj as Person;
        //    if (otherPerson == null)
        //    {
        //        return false;
        //    }
        //    return this.Firstname == otherPerson.Firstname &&
        //        this.Lastname == otherPerson.Lastname;
        //}
        public override int GetHashCode()
        {
            return this.Firstname.GetHashCode() << 17 ^
                    this.Lastname.GetHashCode() >> 17;
        }

        public bool Equals(Person value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }
            if (ReferenceEquals(this, value))
            {
                return true;
            }
            return Equals(this.Firstname, value.Firstname) &&
                   Equals(this.Lastname, value.Lastname);
        }

        public override bool Equals(object obj)
        {
            Person temp = obj as Person;
            if (temp == null)
                return false;
            return this.Equals(temp);
        }

        public int CompareTo(Person other)
        {
            //if this.First == other.First
            //this.Last compares other.Last
            //else Comparer this.First compares other.First
            return this.Firstname.CompareTo(other.Firstname);
        }
    }
}
