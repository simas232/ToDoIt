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

            PersonSequencer.PersonId = 0;
            People testPeople = new People();
            testPeople.ArrPerson = new Person[0];

            // Act
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

            People testPeople = new People();

            // Act
            testPeople.ArrPerson = new Person[0];
            actualSizeNoPersons = testPeople.Size();
            testPeople.ArrPerson = new Person[1];
            testPeople.ArrPerson[0] = new Person(firstName, lastName, 1);
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

            People testPeople = new People();
            testPeople.ArrPerson = new Person[5];
            testPeople.ArrPerson[0] = new Person(firstName, lastName, 1);
            testPeople.ArrPerson[1] = new Person(firstName2, lastName2, 2);
            testPeople.ArrPerson[2] = new Person(firstName3, lastName3, 3);
            testPeople.ArrPerson[3] = new Person(firstName4, lastName4, 4);
            testPeople.ArrPerson[4] = new Person(firstName5, lastName5, 5);

            // Act
            Person[] testPersons = testPeople.FindAll();

            // Assert
            Assert.Equal(testPeople.ArrPerson, testPersons);
        }

        [Fact]
        public void CheckFindAll_Blank()
        {
            // Arrange
            Person[] expPeople = new Person[0];
            PersonSequencer.PersonId = 0;
            People testPeople = new People();
            testPeople.ArrPerson = new Person[0];

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

            People testPeople = new People();
            testPeople.ArrPerson = new Person[1];
            testPeople.ArrPerson[0] = new Person(firstName, lastName, 1);

            // Act
            testPeople.Clear();
            actualSize = testPeople.ArrPerson.Length;

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

            Person trustedPerson = new Person(firstName, lastName, 1);
            Person trustedPerson2 = new Person(firstName2, lastName2, 2);
            Person trustedPerson3 = new Person(firstName3, lastName3, 3);
            Person trustedPerson4 = new Person(firstName4, lastName4, 4);
            Person trustedPerson5 = new Person(firstName5, lastName5, 5);

            PersonSequencer.PersonId = 0;
            People testPeople = new People();
            testPeople.ArrPerson = new Person[5];
            testPeople.ArrPerson[0] = trustedPerson;
            testPeople.ArrPerson[1] = trustedPerson2;
            testPeople.ArrPerson[2] = trustedPerson3;
            testPeople.ArrPerson[3] = trustedPerson4;
            testPeople.ArrPerson[4] = trustedPerson5;

            // Act
            Person actualPerson = testPeople.FindById(1);
            Person actualPerson2 = testPeople.FindById(2);
            Person actualPerson3 = testPeople.FindById(3);
            Person actualPerson4 = testPeople.FindById(4);
            Person actualPerson5 = testPeople.FindById(5);

            // Assert
            Assert.Equal(trustedPerson, actualPerson);
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

            Person trustedPerson = new Person(firstName, lastName, 1);
            Person trustedPerson2 = new Person(firstName2, lastName2, 2);
            Person trustedPerson3 = new Person(firstName3, lastName3, 3);
            Person trustedPerson4 = new Person(firstName4, lastName4, 4);
            Person trustedPerson5 = new Person(firstName5, lastName5, 5);

            PersonSequencer.PersonId = 0;
            People testPeople = new People();
            testPeople.ArrPerson = new Person[5];
            testPeople.ArrPerson[0] = trustedPerson;
            testPeople.ArrPerson[1] = trustedPerson2;
            testPeople.ArrPerson[2] = trustedPerson3;
            testPeople.ArrPerson[3] = trustedPerson4;
            testPeople.ArrPerson[4] = trustedPerson5;

            // Act
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

            Person trustedPerson = new Person(firstName, lastName, 1);
            Person trustedPerson2 = new Person(firstName2, lastName2, 2);
            Person trustedPerson3 = new Person(firstName3, lastName3, 3);
            Person trustedPerson4 = new Person(firstName4, lastName4, 4);
            Person trustedPerson5 = new Person(firstName5, lastName5, 5);

            PersonSequencer.PersonId = 0;
            People testPeople = new People();
            testPeople.ArrPerson = new Person[5];
            testPeople.ArrPerson[0] = trustedPerson;
            testPeople.ArrPerson[1] = trustedPerson2;
            testPeople.ArrPerson[2] = trustedPerson3;
            testPeople.ArrPerson[3] = trustedPerson4;
            testPeople.ArrPerson[4] = trustedPerson5;

            // Act
            testPeople.RemovePerson(trustedPerson);

            // Assert
            Assert.Equal(expArrPersonSize, testPeople.ArrPerson.Length);
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

            Person trustedPerson = new Person(firstName, lastName, 1);
            Person trustedPerson2 = new Person(firstName2, lastName2, 2);
            Person trustedPerson3 = new Person(firstName3, lastName3, 3);
            Person trustedPerson4 = new Person(firstName4, lastName4, 4);
            Person trustedPerson5 = new Person(firstName5, lastName5, 5);

            PersonSequencer.PersonId = 0;
            People testPeople = new People();
            testPeople.ArrPerson = new Person[5];
            testPeople.ArrPerson[0] = trustedPerson;
            testPeople.ArrPerson[1] = trustedPerson2;
            testPeople.ArrPerson[2] = trustedPerson3;
            testPeople.ArrPerson[3] = trustedPerson4;
            testPeople.ArrPerson[4] = trustedPerson5;

            // Act
            testPeople.RemovePerson(trustedPerson);
            testPeople.RemovePerson(trustedPerson3);
            testPeople.RemovePerson(trustedPerson5);

            // Assert
            Assert.Equal(expArrPersonSize, testPeople.ArrPerson.Length);
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

            Person trustedPerson = new Person(firstName, lastName, 1);
            Person trustedPerson2 = new Person(firstName2, lastName2, 2);
            Person trustedPerson3 = new Person(firstName3, lastName3, 3);
            Person trustedPerson4 = new Person(firstName4, lastName4, 4);
            Person trustedPerson5 = new Person(firstName5, lastName5, 5);

            PersonSequencer.PersonId = 0;
            People testPeople = new People();
            testPeople.ArrPerson = new Person[5];
            testPeople.ArrPerson[0] = trustedPerson;
            testPeople.ArrPerson[1] = trustedPerson2;
            testPeople.ArrPerson[2] = trustedPerson3;
            testPeople.ArrPerson[3] = trustedPerson4;
            testPeople.ArrPerson[4] = trustedPerson5;

            // Act
            testPeople.RemovePerson(trustedPerson);
            testPeople.RemovePerson(trustedPerson2);
            testPeople.RemovePerson(trustedPerson3);
            testPeople.RemovePerson(trustedPerson4);
            testPeople.RemovePerson(trustedPerson5);

            // Assert
            Assert.Equal(expArrPersonSize, testPeople.ArrPerson.Length);
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

            Person trustedPerson = new Person(firstName, lastName, 1);
            Person trustedPerson2 = new Person(firstName2, lastName2, 2);
            Person trustedPerson3 = new Person(firstName3, lastName3, 3);
            Person trustedPerson4 = new Person(firstName4, lastName4, 4);
            Person trustedPerson5 = new Person(firstName5, lastName5, 5);

            PersonSequencer.PersonId = 0;
            People testPeople = new People();
            testPeople.ArrPerson = new Person[5];
            testPeople.ArrPerson[0] = trustedPerson;
            testPeople.ArrPerson[1] = trustedPerson2;
            testPeople.ArrPerson[2] = trustedPerson3;
            testPeople.ArrPerson[3] = trustedPerson4;
            testPeople.ArrPerson[4] = trustedPerson5;
            Person donaldDuck = new Person(firstName323, lastName323, 323);

            // Act
            testPeople.RemovePerson(donaldDuck);

            // Assert
            Assert.Equal(expArrPersonSize, testPeople.ArrPerson.Length);
            Assert.Equal(trustedPerson, testPeople.ArrPerson[0]);
            Assert.Equal(trustedPerson2, testPeople.ArrPerson[1]);
            Assert.Equal(trustedPerson3, testPeople.ArrPerson[2]);
            Assert.Equal(trustedPerson4, testPeople.ArrPerson[3]);
            Assert.Equal(trustedPerson5, testPeople.ArrPerson[4]);
        }
    }
}
