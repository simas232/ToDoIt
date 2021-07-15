using Xunit;
using ToDoIt.Models;
using System;

namespace ToDoIt.Tests.Models
{
    public class PersonTests
    {
        [Fact]
        public void CheckPersonDetails()
        {
            // Arrange
            string firstName = "Shayan";
            string lastName = "Alivand";
            int personId = 0;

            // Act
            Person testPerson = new Person(firstName, lastName, personId);

            // Assert        
            Assert.Equal(firstName, testPerson.FirstName);
            Assert.Equal(lastName, testPerson.LastName);
            Assert.Equal(personId, testPerson.PersonId);
        }

        [Fact]
        public void CheckPersonOneDetails_BlankFirstName()
        {
            // Arrange
            string firstName = "";
            string lastName = "Alivand";
            int personId = 0;

            // Act
            Action act = () => new Person(firstName, lastName, personId);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Null or Empty First name is not allowed.", exception.Message);
        }

        [Fact]
        public void CheckPersonOneDetails_BlankLastName()
        {
            // Arrange
            string firstName = "Shayan";
            string lastName = "";
            int personId = 0;

            // Act
            Action act = () => new Person(firstName, lastName, personId);

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Null or Empty Last name is not allowed.", exception.Message);
        }
    }
}
