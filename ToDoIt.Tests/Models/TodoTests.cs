using System;
using Xunit;
using ToDoIt.Models;

namespace ToDoIt.Tests.Models
{
    public class TodoTests
    {
        [Fact]
        public void Todo_TestMinimalInput()
        {
            // Arrange
            int todoId = 0;
            String description = "Buy milk";
            bool done = false;
            Person assignee = null;

            // Act
            Todo testTodo = new Todo(todoId, description);

            // Assert        
            Assert.Equal(todoId, testTodo.TodoId);
            Assert.Equal(description, testTodo.Description);
            Assert.Equal(done, testTodo.Done);
            Assert.Equal(assignee, testTodo.Assignee);
        }

        [Fact]
        public void Todo_TestFullInput()
        {
            // Arrange
            int todoId = 0;
            String description = "Buy milk";
            bool done = false;
            Person assignee = new Person("John", "Doe", 0);

            // Act
            Todo testTodo = new Todo(todoId, description, done, assignee);

            // Assert        
            Assert.Equal(todoId, testTodo.TodoId);
            Assert.Equal(description, testTodo.Description);
            Assert.Equal(done, testTodo.Done);
            Assert.Equal(assignee, testTodo.Assignee);
        }
    }
}
