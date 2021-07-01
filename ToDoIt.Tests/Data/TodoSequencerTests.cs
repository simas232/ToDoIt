using Xunit;
using ToDoIt.Data;

namespace ToDoIt.Tests.Data
{
    public class TodoSequencerTests
    {
        [Fact]
        public void TodoSequencer_TestIdIncrement()
        {
            // Arrange
            int firstIdRef = 1;
            int secondIdRef = 2;
            int thirdIdRef = 3;

            // Act
            int firstTodoId = TodoSequencer.NextTodoId();
            int secondTodoId = TodoSequencer.NextTodoId();
            int thirdTodoId = TodoSequencer.NextTodoId();

            // Assert        
            Assert.Equal(firstTodoId, firstIdRef);
            Assert.Equal(secondTodoId, secondIdRef);
            Assert.Equal(thirdTodoId, thirdIdRef);
        }

        [Fact]
        public void TodoSequencer_TestIdReset()
        {
            // Arrange
            int todoIdRef = 1;
            int todoId;

            // Act
            TodoSequencer.NextTodoId();
            TodoSequencer.NextTodoId();
            TodoSequencer.Reset();
            todoId = TodoSequencer.NextTodoId();

            // Assert        
            Assert.Equal(todoId, todoIdRef);
        }
    }
}
