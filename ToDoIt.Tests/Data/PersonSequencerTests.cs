using Xunit;
using ToDoIt.Models;
using ToDoIt.Data;

namespace ToDoIt.Tests.Data
{
    public class PersonSequencerTests
    {
        [Fact]
        public void CheckNextPersonId()
        {
            // Arrange
            int firstId;
            int secondId;
            // Act
            PersonSequencer.PersonId = 0;// run PersonSeqeuncer.NextPersonId() in other way, becausae we do not trust this function yet
            firstId = PersonSequencer.NextPersonId();
            secondId = PersonSequencer.NextPersonId();

            // Assert
            Assert.Equal(1, firstId);
            Assert.Equal(2, secondId);
        }

        [Fact]
        public void CheckReset()
        {
            // Arrange
            int firstIdAfterReset;
            // Act
            PersonSequencer.NextPersonId();
            PersonSequencer.NextPersonId();
            PersonSequencer.Reset();
            firstIdAfterReset = PersonSequencer.NextPersonId();

            // Assert
            Assert.Equal(1, firstIdAfterReset);

        }

    }
}
