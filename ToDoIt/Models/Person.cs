using System;

namespace ToDoIt.Models
{
    public class Person
    {
        // Fields
        private string firstName;
        private string lastName;
        private readonly int personId; // readonly cuz PersonId


        // Properties to link to files (object)
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value)) // Set the blank name // invert the result with (!)
                {
                    throw new ArgumentException("Null or Empty First name is not allowed.");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value)) // Set the blank name // invert the result with (!)
                {
                    throw new ArgumentException("Null or Empty Last name is not allowed.");
                }
                lastName = value;
            }
        }
        public int PersonId { get { return personId; } } // Get, set to have ability to change

        // Constructor
        public Person(string firstName, string lastName, int personId)
        {
            FirstName = firstName;
            LastName = lastName;
            this.personId = personId;
        }
    }
}
