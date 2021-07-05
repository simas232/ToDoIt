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
            // It is assumed that only one person with personId exists. If there are multiple, then only first hit is returned
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
        public void RemovePerson(Person personEntryToRemove)
        {
            //This function firstly identifies the index of person to be deleted and the reformats the array by skipping that index
            int indexToRemove = 0;

            foreach (Person item in arrPerson)
            {
                if (item == personEntryToRemove)
                {
                    break;
                }
                indexToRemove++;
            }
            if ((indexToRemove == arrPerson.Length) || (arrPerson.Length == 0))
            {
                return;
            }

            for (int index = 0; index < arrPerson.Length - 1; index++)
            {
                arrPerson[index] = index < indexToRemove ? arrPerson[index] : arrPerson[index + 1];
            }
            Array.Resize(ref arrPerson, arrPerson.Length - 1);
        }
    }
}