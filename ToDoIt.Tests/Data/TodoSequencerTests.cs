using Xunit;
using ToDoIt.Data;

namespace ToDoIt.Tests.Data
{
    public class TodoSequencerTests
    {
        [Fact]
        public void TodoIdIncrementWorks()
        {
            // Arrange
            int expectedFirstTodoId = 1;
            int expectedSecondTodoId = 2;
            int expectedThirdTodoId = 3;
            int actualFirstTodoId;
            int actualSecondTodoId;
            int actualThirdTodoId;

            // Act
            TodoSequencer.TodoId = 0;// Replicate Reset() function functionality because it is not tested yet
            actualFirstTodoId = TodoSequencer.NextTodoId();
            actualSecondTodoId = TodoSequencer.NextTodoId();
            actualThirdTodoId = TodoSequencer.NextTodoId();

            // Assert
            Assert.Equal(expectedFirstTodoId, actualFirstTodoId);
            Assert.Equal(expectedSecondTodoId, actualSecondTodoId);
            Assert.Equal(expectedThirdTodoId, actualThirdTodoId);
        }

        [Fact]
        public void TodoIdResetWorks()
        {
            // Arrange
            int expectedTodoId = 1;
            int actualTodoId;

            // Act
            TodoSequencer.NextTodoId();
            TodoSequencer.NextTodoId();
            TodoSequencer.Reset();
            actualTodoId = TodoSequencer.NextTodoId();

            // Assert
            Assert.Equal(expectedTodoId, actualTodoId);
        }
    }
}
