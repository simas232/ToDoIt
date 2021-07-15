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
            string firstName3 = "Erik";
            string lastName3 = "Sweden";
            string firstName4 = "Linda";
            string lastName4 = "Larsoon";
            string firstName5 = "Woody";
            string lastName5 = "Allen";

            // Act
            People testPeople = new People();
            testPeople.AddPerson(firstName, lastName);
            testPeople.AddPerson(firstName2, lastName2);
            testPeople.AddPerson(firstName3, lastName3);
            testPeople.AddPerson(firstName4, lastName4);
            testPeople.AddPerson(firstName5, lastName5);
            Person[] testPersons = testPeople.FindAll();

            // Assert
            Assert.Equal(testPeople.ArrPerson, testPersons);
        }

        [Fact]
        public void CheckFindAll_Blank()
        {
            // Arrange
            Person[] expPeople = new Person[0];
            PersonSequencer.Reset();
            People testPeople = new People();
            testPeople.Clear();

            // Act
            Person[] testPersons = testPeople.FindAll();

            // Assert
            Assert.Equal(expPeople, testPersons);
        }

        [Fact]
        public void CheckClear()
        {
            // Arrange
            string firstName = "Simons";
            string lastName = "Gothenburg";
            int expSize = 0;
            int actualSize;

            // Act
            People testPeople = new People();
            testPeople.AddPerson(firstName, lastName);
            testPeople.Clear();
            actualSize = testPeople.Size();

            // Assert
            Assert.Equal(expSize, actualSize);
        }

        [Fact]
        public void CheckFindById()
        {
            // Arrange
            string firstName = "Simons";
            string lastName = "Gothenburg";
            string firstName2 = "Anna";
            string lastName2 = "Blomberg";
            string firstName3 = "Erik";
            string lastName3 = "Sweden";
            string firstName4 = "Linda";
            string lastName4 = "Larsoon";
            string firstName5 = "Woody";
            string lastName5 = "Allen";

            // Act
            PersonSequencer.Reset();
            People testPeople = new People();
            testPeople.Clear();
            Person trustedPerson1 = testPeople.AddPerson(firstName, lastName);
            Person trustedPerson2 = testPeople.AddPerson(firstName2, lastName2);
            Person trustedPerson3 = testPeople.AddPerson(firstName3, lastName3);
            Person trustedPerson4 = testPeople.AddPerson(firstName4, lastName4);
            Person trustedPerson5 = testPeople.AddPerson(firstName5, lastName5);

            Person actualPerson1 = testPeople.FindById(1);
            Person actualPerson2 = testPeople.FindById(2);
            Person actualPerson3 = testPeople.FindById(3);
            Person actualPerson4 = testPeople.FindById(4);
            Person actualPerson5 = testPeople.FindById(5);

            // Assert
            Assert.Equal(trustedPerson1, actualPerson1);
            Assert.Equal(trustedPerson2, actualPerson2);
            Assert.Equal(trustedPerson3, actualPerson3);
            Assert.Equal(trustedPerson4, actualPerson4);
            Assert.Equal(trustedPerson5, actualPerson5);
        }

        [Fact]
        public void CheckFindById_NoHits()
        {
            // Arrange
            string firstName = "Simons";
            string lastName = "Gothenburg";
            string firstName2 = "Anna";
            string lastName2 = "Blomberg";
            string firstName3 = "Erik";
            string lastName3 = "Sweden";
            string firstName4 = "Linda";
            string lastName4 = "Larsoon";
            string firstName5 = "Woody";
            string lastName5 = "Allen";
            Person expPerson = null;
            int expPersonId = 9;

            // Act
            PersonSequencer.Reset();
            People testPeople = new People();
            testPeople.Clear();
            testPeople.AddPerson(firstName, lastName);
            testPeople.AddPerson(firstName2, lastName2);
            testPeople.AddPerson(firstName3, lastName3);
            testPeople.AddPerson(firstName4, lastName4);
            testPeople.AddPerson(firstName5, lastName5);

            Person actualPerson = testPeople.FindById(expPersonId);

            // Assert
            Assert.Equal(expPerson, actualPerson);
        }

        [Fact]
        public void CheckRemovePerson_OneHit()
        {
            // Arrange
            string firstName = "Simons";
            string lastName = "Gothenburg";
            string firstName2 = "Anna";
            string lastName2 = "Blomberg";
            string firstName3 = "Erik";
            string lastName3 = "Sweden";
            string firstName4 = "Linda";
            string lastName4 = "Larsoon";
            string firstName5 = "Woody";
            string lastName5 = "Allen";
            int expArrPersonSize = 4;

            // Act
            PersonSequencer.Reset();
            People testPeople = new People();
            testPeople.Clear();
            Person trustedPerson = testPeople.AddPerson(firstName, lastName);
            Person trustedPerson2 = testPeople.AddPerson(firstName2, lastName2);
            Person trustedPerson3 = testPeople.AddPerson(firstName3, lastName3);
            Person trustedPerson4 = testPeople.AddPerson(firstName4, lastName4);
            Person trustedPerson5 = testPeople.AddPerson(firstName5, lastName5);

            testPeople.RemovePerson(trustedPerson);

            // Assert
            Assert.Equal(expArrPersonSize, testPeople.Size());
            Assert.Equal(trustedPerson2, testPeople.ArrPerson[0]);
            Assert.Equal(trustedPerson3, testPeople.ArrPerson[1]);
            Assert.Equal(trustedPerson4, testPeople.ArrPerson[2]);
            Assert.Equal(trustedPerson5, testPeople.ArrPerson[3]);
        }

        [Fact]
        public void CheckRemovePerson_ThreeHits()
        {
            // Arrange
            string firstName = "Simons";
            string lastName = "Gothenburg";
            string firstName2 = "Anna";
            string lastName2 = "Blomberg";
            string firstName3 = "Erik";
            string lastName3 = "Sweden";
            string firstName4 = "Linda";
            string lastName4 = "Larsoon";
            string firstName5 = "Woody";
            string lastName5 = "Allen";
            int expArrPersonSize = 2;

            // Act
            PersonSequencer.Reset();
            People testPeople = new People();
            testPeople.Clear();
            Person trustedPerson = testPeople.AddPerson(firstName, lastName);
            Person trustedPerson2 = testPeople.AddPerson(firstName2, lastName2);
            Person trustedPerson3 = testPeople.AddPerson(firstName3, lastName3);
            Person trustedPerson4 = testPeople.AddPerson(firstName4, lastName4);
            Person trustedPerson5 = testPeople.AddPerson(firstName5, lastName5);

            testPeople.RemovePerson(trustedPerson);
            testPeople.RemovePerson(trustedPerson3);
            testPeople.RemovePerson(trustedPerson5);

            // Assert
            Assert.Equal(expArrPersonSize, testPeople.Size());
            Assert.Equal(trustedPerson2, testPeople.ArrPerson[0]);
            Assert.Equal(trustedPerson4, testPeople.ArrPerson[1]);
        }

        [Fact]
        public void CheckRemovePerson_AllHits()
        {
            // Arrange
            string firstName = "Simons";
            string lastName = "Gothenburg";
            string firstName2 = "Anna";
            string lastName2 = "Blomberg";
            string firstName3 = "Erik";
            string lastName3 = "Sweden";
            string firstName4 = "Linda";
            string lastName4 = "Larsoon";
            string firstName5 = "Woody";
            string lastName5 = "Allen";
            int expArrPersonSize = 0;

            // Act
            PersonSequencer.Reset();
            People testPeople = new People();
            testPeople.Clear();
            Person trustedPerson = testPeople.AddPerson(firstName, lastName);
            Person trustedPerson2 = testPeople.AddPerson(firstName2, lastName2);
            Person trustedPerson3 = testPeople.AddPerson(firstName3, lastName3);
            Person trustedPerson4 = testPeople.AddPerson(firstName4, lastName4);
            Person trustedPerson5 = testPeople.AddPerson(firstName5, lastName5);

            testPeople.RemovePerson(trustedPerson);
            testPeople.RemovePerson(trustedPerson2);
            testPeople.RemovePerson(trustedPerson3);
            testPeople.RemovePerson(trustedPerson4);
            testPeople.RemovePerson(trustedPerson5);

            // Assert
            Assert.Equal(expArrPersonSize, testPeople.Size());
        }

        [Fact]
        public void CheckRemovePerson_NoHits()
        {
            // Arrange
            string firstName = "Simons";
            string lastName = "Gothenburg";

            string firstName2 = "Anna";
            string lastName2 = "Blomberg";

            string firstName3 = "Erik";
            string lastName3 = "Sweden";

            string firstName4 = "Linda";
            string lastName4 = "Larsoon";

            string firstName5 = "Woody";
            string lastName5 = "Allen";

            string firstName323 = "Donald";
            string lastName323 = "Duck";

            int expArrPersonSize = 5;

            // Act
            PersonSequencer.Reset();
            People testPeople = new People();
            testPeople.Clear();
            Person trustedPerson = testPeople.AddPerson(firstName, lastName);
            Person trustedPerson2 = testPeople.AddPerson(firstName2, lastName2);
            Person trustedPerson3 = testPeople.AddPerson(firstName3, lastName3);
            Person trustedPerson4 = testPeople.AddPerson(firstName4, lastName4);
            Person trustedPerson5 = testPeople.AddPerson(firstName5, lastName5);
            Person donaldDuck = new Person(firstName323, lastName323, 323);

            testPeople.RemovePerson(donaldDuck);

            // Assert
            Assert.Equal(expArrPersonSize, testPeople.Size());
            Assert.Equal(trustedPerson, testPeople.ArrPerson[0]);
            Assert.Equal(trustedPerson2, testPeople.ArrPerson[1]);
            Assert.Equal(trustedPerson3, testPeople.ArrPerson[2]);
            Assert.Equal(trustedPerson4, testPeople.ArrPerson[3]);
            Assert.Equal(trustedPerson5, testPeople.ArrPerson[4]);
        }
    }
}
