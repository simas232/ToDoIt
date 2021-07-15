using Xunit;
using ToDoIt.Data;

namespace ToDoIt.Tests.Data
{
    public class TodoSequencerTests
    {
        [Fact]
        public void TodoIdWorks()
        {
            // Arrange
            int expectedTodoId = 5;

            // Act
            TodoSequencer.TodoId = expectedTodoId;

            // Assert
            Assert.Equal(expectedTodoId, TodoSequencer.TodoId);
        }
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

            TodoSequencer.TodoId = 0;

            // Act
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
            int expectedTodoId = 0;

            TodoSequencer.TodoId = 5;

            // Act
            TodoSequencer.Reset();

            // Assert
            Assert.Equal(expectedTodoId, TodoSequencer.TodoId);
        }
    }
}
