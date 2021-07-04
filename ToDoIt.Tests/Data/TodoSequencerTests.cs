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
            TodoSequencer.reset();
            actualFirstTodoId = TodoSequencer.nextTodoId();
            actualSecondTodoId = TodoSequencer.nextTodoId();
            actualThirdTodoId = TodoSequencer.nextTodoId();

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
            TodoSequencer.nextTodoId();
            TodoSequencer.nextTodoId();
            TodoSequencer.reset();
            actualTodoId = TodoSequencer.nextTodoId();

            // Assert
            Assert.Equal(expectedTodoId, actualTodoId);
        }
    }
}
