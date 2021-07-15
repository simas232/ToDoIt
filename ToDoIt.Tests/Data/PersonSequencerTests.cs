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
            int expFirstPersonId = 1;
            int expSecondPersonId = 2;

            int firstId;
            int secondId;
            PersonSequencer.PersonId = 0;// run PersonSeqeuncer.Clear() in other way, becausae we do not trust this function yet

            // Act
            firstId = PersonSequencer.NextPersonId();
            secondId = PersonSequencer.NextPersonId();

            // Assert
            Assert.Equal(expFirstPersonId, firstId);
            Assert.Equal(expSecondPersonId, secondId);
        }

        [Fact]
        public void CheckReset()
        {
            // Arrange
            int expPersonId = 0;
            int actualPersonId;
            PersonSequencer.PersonId = 2;

            // Act
            PersonSequencer.Reset();
            actualPersonId = PersonSequencer.PersonId;

            // Assert
            Assert.Equal(expPersonId, actualPersonId);
        }
    }
}
