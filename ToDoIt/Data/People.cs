using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Models;

namespace ToDoIt.Data
{
    public class People
    {
        private static Person[] arrPerson = new Person[0];
        public Person[] ArrPerson
        {
            get
            {
                return arrPerson;
            }
            set
            {
                arrPerson = value;
            }
        }

        public int Size()
        {
            return arrPerson.Length;
        }
        public Person[] FindAll()
        {
            return arrPerson;
        }
        public Person FindById(int personId)
        {
            foreach (Person item in arrPerson)
            {
                if (item.PersonId == personId)
                {
                    return item;
                }
            }
            return null;
        }
        public Person AddPerson(string firstName, string lastName)
        {   //Creating the new person as object        
            Person addNewPerson = new Person(firstName, lastName, PersonSequencer.NextPersonId());

            Array.Resize(ref arrPerson, arrPerson.Length + 1);

            arrPerson[arrPerson.Length - 1] = addNewPerson;

            return addNewPerson;
        }
        public void Clear()
        {
            arrPerson = new Person[0];
        }
    }
}