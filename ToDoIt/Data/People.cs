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
            return ArrPerson.Length;
        }
        public Person[] FindAll()
        {
            return ArrPerson;
        }
        public Person FindById(int personId)
        {
            foreach (Person item in ArrPerson)
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

            Array.Resize(ref arrPerson, Size() + 1);

            arrPerson[Size() - 1] = addNewPerson;

            return addNewPerson;
        }
        public static void Clear()
        {
            Person[] ArrPerson = new Person[0];
            // Array.Clear(ArrPerson, 0, ArrPerson.Length);
        }
    }
}