using System;
using Xunit;
using ToDoIt.Data;
using ToDoIt.Models;

namespace ToDoIt.Tests.Data
{
    public class TodoItemsTests
    {
        [Fact]
        public void AddTodoWorks()
        {
            // Arrange
            String firstDescription = "Buy coconut milk";
            String secondDescription = "Go to the gym";
            String thirdDescription = "Install Visual Studio";
            int expectedFirstTodoId = 1;
            int expectedSecondTodoId = 2;
            int expectedThirdTodoId = 3;
            int expectedSize = 3;

            // Act
            TodoSequencer.reset();
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[0];// Replicate Clear() function functionality because we do no trust it yet
            Todo actualFirstTodo = actualTodoItems.AddTodo(firstDescription);
            Todo actualSecondTodo = actualTodoItems.AddTodo(secondDescription);
            Todo actualThirdTodo = actualTodoItems.AddTodo(thirdDescription);
            Todo[] testTodoItemsArray = actualTodoItems.FindAll();

            // Assert
            Assert.Equal(firstDescription, actualFirstTodo.Description);
            Assert.Equal(expectedFirstTodoId, actualFirstTodo.TodoId);
            Assert.Equal(secondDescription, actualSecondTodo.Description);
            Assert.Equal(expectedSecondTodoId, actualSecondTodo.TodoId);
            Assert.Equal(thirdDescription, actualThirdTodo.Description);
            Assert.Equal(expectedThirdTodoId, actualThirdTodo.TodoId);

            Assert.Equal(firstDescription, testTodoItemsArray[0].Description);
            Assert.Equal(expectedFirstTodoId, testTodoItemsArray[0].TodoId);
            Assert.Equal(secondDescription, testTodoItemsArray[1].Description);
            Assert.Equal(expectedSecondTodoId, testTodoItemsArray[1].TodoId);
            Assert.Equal(thirdDescription, testTodoItemsArray[2].Description);
            Assert.Equal(expectedThirdTodoId, testTodoItemsArray[2].TodoId);
            // Since three todo tasks are in actualTodoItems, the length of testTodoItemsArray should also be the same
            Assert.Equal(expectedSize, testTodoItemsArray.Length);
        }
        [Fact]
        public void SizeZeroWorks()
        {
            // Arrange
            int expectedSize = 0;
            int actualSize;

            // Act
            TodoSequencer.reset();
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[0];// Replicate Clear() function functionality because we do no trust it yet
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
            actualTodoItems.TodoArray = new Todo[0];// Replicate Clear() function functionality because we do no trust it yet
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
        [Fact]
        public void FindAllWorks()
        {
            // Arrange
            String firstDescription = "Buy coconut milk";
            String secondDescription = "Go to the gym";
            String thirdDescription = "Install Visual Studio";

            // Act
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.Clear();
            actualTodoItems.AddTodo(firstDescription);
            actualTodoItems.AddTodo(secondDescription);
            actualTodoItems.AddTodo(thirdDescription);
            Todo[] testTodoItemsArray = actualTodoItems.FindAll();

            // Assert
            Assert.Equal(actualTodoItems.TodoArray, testTodoItemsArray); 
        }
        [Fact]
        public void ClearWorks()
        {
            // Arrange
            int expectedSize = 0;
            int actualSize;
            String description = "Buy coconut milk";

            // Act
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.AddTodo(description);
            actualTodoItems.Clear();
            actualSize = actualTodoItems.Size();

            // Assert
            Assert.Equal(expectedSize, actualSize);
        }
        [Fact]
        public void FindByIdWorks()
        {
            // Arrange
            String firstDescription = "Buy coconut milk";
            String secondDescription = "Go to the gym";
            String thirdDescription = "Install Visual Studio";

            // Act
            TodoSequencer.reset();
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.Clear();
            Todo expectedFirstTodo = actualTodoItems.AddTodo(firstDescription);
            Todo expectedSecondTodo = actualTodoItems.AddTodo(secondDescription);
            Todo expectedThirdTodo = actualTodoItems.AddTodo(thirdDescription);
            Todo actualFirstTodo = actualTodoItems.FindById(1);
            Todo actualSecondTodo = actualTodoItems.FindById(2);
            Todo actualThirdTodo = actualTodoItems.FindById(3);

            // Assert
            Assert.Equal(expectedFirstTodo, actualFirstTodo);
            Assert.Equal(expectedSecondTodo, actualSecondTodo);
            Assert.Equal(expectedThirdTodo, actualThirdTodo);
        }
    }
}
