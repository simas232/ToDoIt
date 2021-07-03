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
        public void checkAddPersonTest()
        {
            // Arrange
            //string firstName = "Simons";
            //string lastName = "Gothenburg";

            // Act
            //Person testPersons = People.AddPerson(firstName, lastName);

            // Assert        
            //Assert.Equal(firstName, testPersons.FirstName);
            //Assert.Equal(lastName, testPersons.LastName);
            //Assert.Equal(0, testPersons.PersonId);

            Assert.Equal(4, People.Size());

        }

    }
}
