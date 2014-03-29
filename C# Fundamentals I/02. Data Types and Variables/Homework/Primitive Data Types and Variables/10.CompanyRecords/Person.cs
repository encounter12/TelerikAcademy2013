using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Person
{
    private string firstname = null;
    private string lastname = null;
    private Gender gender = (Gender)3;
    private byte age = 0;
    private int id = 1;
    private int uniqueNumber = 27560000;
    private static int counter = 0;

    public string FirstName
    {
        get { return firstname; }
        set { firstname = value; }

    }
        
    public string LastName
    {
        get { return lastname; }
        set { lastname = value; }

    }
    public byte Age
    {
        get { return age; }
        set { age = value; }
    }

    public enum Gender: byte
    {
        Male = 1,
        Female = 2, 
        Unknown = 3

    }
    public Gender Sex
    {
        get { return gender; }
        set { gender = value; }
    }
       
    public int ID
    {
        get{ return id; }
        set { id = value; }
    }
    public int UniqueNumber
    {
        get { return uniqueNumber; }
        set { uniqueNumber = value; }
    }

    public static int Counter
    {
        get { return counter; }
        set { counter = value; }
    }
    public Person(string employeeFirstName, string employeeLastName)
    {
        firstname = employeeFirstName;
        lastname = employeeLastName;
        uniqueNumber = uniqueNumber + counter;
        id = id + counter;
        counter++;
    }    
}

