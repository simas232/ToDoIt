using System;
using System.Text;
using System.Collections.Generic;

namespace ToDoIt.Models
{
    public class Person
    {
        //fiels
        private string firstName; //get ,set to have ability to change
        private string lastName;
        public readonly int personId; // readonly cuz PersonalId 


        //properties to link to files(object)
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) //set the blank name // invert the result with (!)
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
                if (string.IsNullOrWhiteSpace(value)) //set the blank name // invert the result with (!)
                {
                    throw new ArgumentException("Empty or whitespace is not allowed.");
                }
                lastName = value;
            }
        }
        public int PersonId { get; set; }
    
        public string FullName { get { return firstName + " "  + lastName; } }

        //constructor
        public Person(string firstName, string lastName, int personId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PersonId = personId;                                 
        }

    }

}
