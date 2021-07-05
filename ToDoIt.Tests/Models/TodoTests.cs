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
            int todoId = 1;
            String description = "Buy coconut milk";

            // Act
            Todo testTodo = new Todo(todoId, description);

            // Assert
            Assert.Equal(todoId, testTodo.TodoId);
        }
        [Fact]
        public void DescriptionWorks()
        {
            // Arrange
            int todoId = 1;
            String description = "Buy coconut milk";

            // Act
            Todo testTodo = new Todo(todoId, description);

            // Assert
            Assert.Equal(description, testTodo.Description);
        }
        [Fact]
        public void DoneDefaultWorks()
        {
            // Arrange
            int todoId = 1;
            String description = "Buy almond milk";
            bool done = false;

            // Act
            Todo testTodo = new Todo(todoId, description);

            // Assert
            Assert.Equal(done, testTodo.Done);
        }
        [Fact]
        public void DoneWorks()
        {
            // Arrange
            int todoId = 1;
            String description = "Buy coconut milk";
            bool done = true;

            // Act
            Todo testTodo = new Todo(todoId, description);
            testTodo.Done = done;

            // Assert
            Assert.Equal(done, testTodo.Done);
        }
        [Fact]
        public void AssigneeDefaultWorks()
        {
            // Arrange
            int todoId = 1;
            String description = "Buy almond milk";
            Person assignee = null;

            // Act
            Todo testTodo = new Todo(todoId, description);

            // Assert
            Assert.Equal(assignee, testTodo.Assignee);
        }
        [Fact]
        public void AssigneeWorks()
        {
            // Arrange
            int todoId = 1;
            String description = "Buy coconut milk";
            string firstName = "Jane";
            string lastName = "Doe";
            Person testAssignee = new Person(firstName, lastName, todoId);

            // Act
            Todo testTodo = new Todo(todoId, description);
            testTodo.Assignee = testAssignee;

            // Assert
            Assert.Equal(testAssignee, testTodo.Assignee);
        }
    }
}
