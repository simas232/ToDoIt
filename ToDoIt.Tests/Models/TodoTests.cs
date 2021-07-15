using System;
using Xunit;
using ToDoIt.Models;

namespace ToDoIt.Tests.Models
{
    public class TodoTests
    {
        [Fact]
        public void TodoIdWorks()
        {
            // Arrange
            int expectedTodoId = 1;
            String description = "Buy coconut milk";

            // Act
            Todo actualTodo = new Todo(expectedTodoId, description);

            // Assert
            Assert.Equal(expectedTodoId, actualTodo.TodoId);
        }
        [Fact]
        public void DescriptionWorks()
        {
            // Arrange
            int todoId = 1;
            String expectedDescription = "Buy coconut milk";

            // Act
            Todo actualTodo = new Todo(todoId, expectedDescription);

            // Assert
            Assert.Equal(expectedDescription, actualTodo.Description);
        }
        [Fact]
        public void DoneDefaultWorks()
        {
            // Arrange
            int expectedTodoId = 1;
            String description = "Buy coconut milk";
            bool expectedDoneDefault = false;

            // Act
            Todo actualTodo = new Todo(expectedTodoId, description);

            // Assert
            Assert.Equal(expectedDoneDefault, actualTodo.Done);
        }
        [Fact]
        public void DoneWorks()
        {
            // Arrange
            int expectedTodoId = 1;
            String description = "Buy coconut milk";
            bool expectedDone = true;

            // Act
            Todo actualTodo = new Todo(expectedTodoId, description);
            actualTodo.Done = expectedDone;

            // Assert
            Assert.Equal(expectedDone, actualTodo.Done);
        }
        [Fact]
        public void AssigneeDefaultWorks()
        {
            // Arrange
            int expectedTodoId = 1;
            String description = "Buy coconut milk";
            Person expectedAssigneeDefault = null;

            // Act
            Todo actualTodo = new Todo(expectedTodoId, description);

            // Assert
            Assert.Equal(expectedAssigneeDefault, actualTodo.Assignee);
        }
        [Fact]
        public void AssigneeWorks()
        {
            // Arrange
            int expectedTodoId = 1;
            String description = "Buy coconut milk";
            string firstName = "Jane";
            string lastName = "Doe";
            Person actualAssignee = new Person(firstName, lastName, 1);

            Todo actualTodo = new Todo(expectedTodoId, description);

            // Act
            actualTodo.Assignee = actualAssignee;

            // Assert
            Assert.Equal(actualAssignee, actualTodo.Assignee);
        }
    }
}
