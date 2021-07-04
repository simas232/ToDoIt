using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt.Data;
using ToDoIt.Models;

namespace ToDoIt.Tests.Data
{
    public class TodoItemsTests
    {
        [Fact]
        public void SizeZeroWorks()
        {
            // Arrange
            int expectedSize = 0;
            int actualSize;

            // Act
            TodoSequencer.reset();
            TodoItems actualTodoItems = new TodoItems();
            actualSize = actualTodoItems.Size();

            // Assert
            Assert.Equal(expectedSize, actualSize);
        }
        [Fact]
        public void SizeNonZeroWorks()
        {
            // Arrange
            String firstDescription = "Buy coconut milk";
            String secondDescription = "Go to the gym";
            String thirdDescription = "Install Visual Studio";
            int expectedSizeOneTodo = 1;
            int expectedSizeTwoTodos = 2;
            int expectedSizeThreeTodos = 3;
            int actualSizeOneTodo;
            int actualSizeTwoTodos;
            int actualSizeThreeTodos;

            // Act
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.Clear();
            actualTodoItems.AddTodo(firstDescription);
            actualSizeOneTodo = actualTodoItems.Size();
            actualTodoItems.AddTodo(secondDescription);
            actualSizeTwoTodos = actualTodoItems.Size();
            actualTodoItems.AddTodo(thirdDescription);
            actualSizeThreeTodos = actualTodoItems.Size();

            // Assert
            Assert.Equal(expectedSizeOneTodo, actualSizeOneTodo);
            Assert.Equal(expectedSizeTwoTodos, actualSizeTwoTodos);
            Assert.Equal(expectedSizeThreeTodos, actualSizeThreeTodos);
        }
    }
}
