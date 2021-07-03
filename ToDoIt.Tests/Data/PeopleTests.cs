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
        public void CheckAddPersonTest()
        {
            // Arrange
            string firstName = "Simons";
            string lastName = "Gothenburg";

            // Act
            People testPeople = new People();
            Person testPerson = testPeople.AddPerson(firstName, lastName);

            // Assert        
            Assert.Equal(firstName, testPerson.FirstName);
            Assert.Equal(lastName, testPerson.LastName);
            Assert.Equal(1, testPerson.PersonId);
        }

    }
}
