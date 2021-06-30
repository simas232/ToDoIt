using Xunit;
using ToDoIt.Models;

namespace ToDoIt.Tests.Models
{
    public class PersonTests
    {
        [Fact]
        public void PersonDetails()
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
    }
}
