using Xunit;
using ToDoIt.Models;
using ToDoIt.Data;

namespace ToDoIt.Tests.Data
{
    public class PersonSequencerTests
    {
        [Fact]
        public void PersonSequenceInput()
        {
            // Arrange
            int firstId;
            int secondId;
            int firstIdAfterReset;
            // Act
            firstId = PersonSequencer.NextPersonId();
            secondId = PersonSequencer.NextPersonId();
            PersonSequencer.Reset();
            firstIdAfterReset = PersonSequencer.NextPersonId();

            // Assert
            Assert.Equal(1, firstId);
            Assert.Equal(2, secondId);
            Assert.Equal(1, firstIdAfterReset);

        }
    }
}
