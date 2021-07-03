using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Models;

namespace ToDoIt.Data
{
    public class People
    {
        private static Person[] arrPerson = new Person[0];
        public static Person[] ArrPerson
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

        public static int Size()
        {
            return ArrPerson.Length;
        }
        public static Person[] FindAll()
        {
            return ArrPerson;
        }
        public static Person FindById(int personId)
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
        public static Person AddPerson(string firstName, string lastName)
        {   //Creating the new person as object        
            Person addNewPerson = new Person(firstName, lastName, PersonSequencer.NextPersonId());

            //creating a new blank array which is longer then
            Person[] tempArray = new Person[Size() + 1];

            //Copy all ArrPerson data to tempArray
            Array.Copy(FindAll(), tempArray, Size());

            //tempArry here gain the data from new created personal object
            tempArray[Size() - 1] = addNewPerson;

            ArrPerson = tempArray;
            return addNewPerson;
        }
        public static void Clear()
        {
            Person[] ArrPerson = new Person[0];
            // Array.Clear(ArrPerson, 0, ArrPerson.Length);
        }
    }
}