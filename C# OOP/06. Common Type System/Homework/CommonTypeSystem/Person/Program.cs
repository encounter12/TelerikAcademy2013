using System;
using System.Collections.Generic;

namespace Person
{
    class Program
    {
        static void Main()
        {
            List<Person> persons = new List<Person>()
            {
                new Person("Michio Kaku"), 
                new Person("Albert Einstein", 245)
            };

            foreach (Person person in persons)
            {
                Console.WriteLine(person);
                Console.WriteLine();
            }
            
        }
    }
}
