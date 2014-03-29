using System;
using System.Text;

namespace Student
{
    enum Specialty
    {
        Physics,
        Math,
        Biology,
        Literature,
        Arts,
        History,
        Geography
    };
    
    enum University
    {
        MIT,
        Oxford,
        Cambridge,
        Stanford,
        Sofia,
        Berkeley
    };

    enum Faculty
    {
        Engineering,
        Arts,
        Aeronautics
    }; 

    class Student: ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string fullName;
        private int sSN;
        private string permanentAddress;
        private string mobileNumber;
        private string email;               
        private Specialty specialty;
        private Faculty faculty;
       
        public Student(string firstName, string middleName, string lastName) : this(firstName, middleName, lastName, null)
        {
        }

        public Student(string firstName, string middleName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Email = email;
        }

        public Student()
        {
        }
                                    
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public int SSN
        {
            get
            {
                return this.sSN;
            }
            set
            {
                this.sSN = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }
            set
            {
                this.permanentAddress = value;
            }
        }

        public string MobileNumber
        {
            get
            {
                return this.mobileNumber;
            }
            set
            {
                this.mobileNumber = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public Specialty Specialty
        {
            get
            {
                return this.specialty;
            }
            set
            {
                this.specialty = value;
            }
        }

        public Faculty Faculty
        {
            get
            {
                return this.faculty;
            }
            set
            {
                this.faculty = value;
            }
        }

        public string FullName
        {
            get
            {
                return this.fullName = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            }            
        }

        //checks if two students objects are equal by comparing the name and SSN
        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (student == null)
            {
                return false;
            }
            if (student.FirstName != this.FirstName || student.MiddleName != this.MiddleName || student.LastName != this.LastName)
            {
                return false;
            }

            if (student.SSN != this.SSN)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            string studentString = "";
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Student name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName).AppendLine();            
            sb.AppendFormat("SSN: {0}", this.SSN).AppendLine();
            sb.AppendFormat("Specialty: {0}", this.Specialty).AppendLine();
            sb.AppendFormat("Faculty: {0}", this.Faculty).AppendLine();
            sb.AppendFormat("email: {0}", this.Email).AppendLine();
            sb.AppendFormat("Permanent Address: {0}", this.PermanentAddress);
            
            studentString = sb.ToString();
            sb.Clear();
            return studentString;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() * this.MiddleName.GetHashCode() 
                * this.LastName.GetHashCode();
        }

        public static bool operator ==(Student student01, Student student02)
        {
            if (Student.Equals(student01, student02))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Student student01, Student student02)
        {
            if (Student.Equals(student01, student02))
            {
                return false;
            }
            return true;
        }

        public static bool operator <(Student student01, Student student02)
        {
            if (student01.CompareTo(student02) < 0)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(Student student01, Student student02)
        {
            if (student01.CompareTo(student02) > 0)
            {
                return true;
            }
            return false;
        }
       
        //performs deep copy
        public object Clone()
        {
            Student student = new Student
            {
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                SSN = this.SSN,
                Email = this.Email,
                PermanentAddress = this.PermanentAddress,
                Specialty = this.Specialty,
                Faculty = this.Faculty
            };
            
            return student;
        }

        public int CompareTo(Student other)
        {               
            if (other == null)
            {
                return 1;
            }

            if (this.FullName.CompareTo(other.FullName) < 0)
            {
                return -1;
            }
            else if (this.FullName.CompareTo(other.FullName) > 0)
            {
                return 1;
            }
            else
            {
                if (this.SSN < other.SSN)
                {
                    return -1;
                }
                else if (this.SSN == other.SSN)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }            
        }                       
    }
}
