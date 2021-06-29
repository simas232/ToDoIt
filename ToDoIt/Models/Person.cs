using System;

namespace ToDoIt.Models
{
    public class Person
    {
        // Fields
        private string firstName; // Get, set to have ability to change
        private string lastName;
        public readonly int personId; // readonly cuz PersonId 


        // Properties to link to files (object)
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // Set the blank name // invert the result with (!)
                {
                    throw new ArgumentException("Empty or whitespace is not allowed.");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // Set the blank name // invert the result with (!)
                {
                    throw new ArgumentException("Empty or whitespace is not allowed.");
                }
                lastName = value;
            }
        }
        public int PersonId { get; set; }

        // Constructor
        public Person(string firstName, string lastName, int personId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PersonId = personId;
        }
    }
}
