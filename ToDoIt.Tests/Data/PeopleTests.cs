using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt.Data;
using ToDoIt.Models;

namespace ToDoIt.Tests.Data
{
    public class PeopleTests
    {
        [Fact]
        public void CheckAddPerson()
        {
            // Arrange
            string firstName = "Simons";
            string lastName = "Gothenburg";
            string firstName2 = "Anna";
            string lastName2 = "Blomberg";

            int expFirstPersonId = 1;
            int expSecondPersonId = 2;
            int expSize = 2;

            // Act
            PersonSequencer.Reset();
            People testPeople = new People();
            testPeople.ArrPerson = new Person[0];// same like Clear function, which we do have tested yet
            Person person1 = testPeople.AddPerson(firstName, lastName);
            Person person2 = testPeople.AddPerson(firstName2, lastName2);
            Person[] testPersons = testPeople.ArrPerson;

            // Assert
            Assert.Equal(firstName, person1.FirstName);
            Assert.Equal(lastName, person1.LastName);
            Assert.Equal(expFirstPersonId, person1.PersonId);
            Assert.Equal(firstName2, person2.FirstName);
            Assert.Equal(lastName2, person2.LastName);
            Assert.Equal(expSecondPersonId, person2.PersonId);

            Assert.Equal(firstName, testPersons[0].FirstName);
            Assert.Equal(lastName, testPersons[0].LastName);
            Assert.Equal(expFirstPersonId, testPersons[0].PersonId);
            Assert.Equal(firstName2, testPersons[1].FirstName);
            Assert.Equal(lastName2, testPersons[1].LastName);
            Assert.Equal(expSecondPersonId, testPersons[1].PersonId);

            Assert.Equal(expSize, testPersons.Length);
        }

        [Fact]
        public void CheckSize()
        {
            // Arrange
            string firstName = "Simons";
            string lastName = "Gothenburg";
            int expSizeNoPersons = 0;
            int expSizeOnePerson = 1;
            int actualSizeNoPersons;
            int actualSizeOnePerson;

            // Act
            People testPeople = new People();
            actualSizeNoPersons = testPeople.Size();
            testPeople.AddPerson(firstName, lastName);
            actualSizeOnePerson = testPeople.Size();

            // Assert
            Assert.Equal(expSizeNoPersons, actualSizeNoPersons);
            Assert.Equal(expSizeOnePerson, actualSizeOnePerson);
        }

        [Fact]
        public void CheckFindAll()
        {
            // Arrange
            string firstName = "Simons";
            string lastName = "Gothenburg";
            string firstName2 = "Anna";
            string lastName2 = "Blomberg";

            // Act
            People testPeople = new People();
            testPeople.AddPerson(firstName, lastName);
            testPeople.AddPerson(firstName2, lastName2);
            Person[] testPersons = testPeople.FindAll();

            // Assert
            Assert.Equal(testPeople.ArrPerson, testPersons);
        }
    }
}
