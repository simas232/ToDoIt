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
        [Fact]
        public void FindByDoneStatusWorks_Mixed()
        {
            // Arrange
            String firstDescription = "Buy coconut milk";
            bool firstDoneStatus = true;
            String secondDescription = "Go to the gym";
            bool secondDoneStatus = false;
            String thirdDescription = "Install Visual Studio";
            bool thirdDoneStatus = false;
            String fourthDescription = "Eat a small cup of almonds";
            bool fourthDoneStatus = true;
            String fifthDescription = "Go to the park";
            bool fifthDoneStatus = true;
            int expectedDoneTasksArrayLength = 3;
            int expectedPendingTasksArrayLength = 2;

            // Act
            TodoSequencer.reset();
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.Clear();

            // Create five todo tasks using different descriptions
            actualTodoItems.AddTodo(firstDescription);
            actualTodoItems.AddTodo(secondDescription);
            actualTodoItems.AddTodo(thirdDescription);
            actualTodoItems.AddTodo(fourthDescription);
            actualTodoItems.AddTodo(fifthDescription);

            // Set Done values for these five newly added tasks
            actualTodoItems.TodoArray[0].Done = firstDoneStatus;
            actualTodoItems.TodoArray[1].Done = secondDoneStatus;
            actualTodoItems.TodoArray[2].Done = thirdDoneStatus;
            actualTodoItems.TodoArray[3].Done = fourthDoneStatus;
            actualTodoItems.TodoArray[4].Done = fifthDoneStatus;

            Todo[] actualCompletedTodos = actualTodoItems.FindByDoneStatus(true);
            Todo[] actualPendingTodos = actualTodoItems.FindByDoneStatus(false);

            // Assert
            Assert.Equal(expectedDoneTasksArrayLength, actualCompletedTodos.Length);
            Assert.Equal(actualTodoItems.TodoArray[0], actualCompletedTodos[0]);
            Assert.Equal(actualTodoItems.TodoArray[3], actualCompletedTodos[1]);
            Assert.Equal(actualTodoItems.TodoArray[4], actualCompletedTodos[2]);

            Assert.Equal(expectedPendingTasksArrayLength, actualPendingTodos.Length);
            Assert.Equal(actualTodoItems.TodoArray[1], actualPendingTodos[0]);
            Assert.Equal(actualTodoItems.TodoArray[2], actualPendingTodos[1]);
        }
        [Fact]
        public void FindByDoneStatusWorks_AllDone()
        {
            // Arrange
            String firstDescription = "Buy coconut milk";
            bool firstDoneStatus = true;
            String secondDescription = "Go to the gym";
            bool secondDoneStatus = true;
            String thirdDescription = "Install Visual Studio";
            bool thirdDoneStatus = true;
            String fourthDescription = "Eat a small cup of almonds";
            bool fourthDoneStatus = true;
            String fifthDescription = "Go to the park";
            bool fifthDoneStatus = true;
            int expectedPendingTasksArrayLength = 0;

            // Act
            TodoSequencer.reset();
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.Clear();

            // Create five todo tasks using different descriptions
            actualTodoItems.AddTodo(firstDescription);
            actualTodoItems.AddTodo(secondDescription);
            actualTodoItems.AddTodo(thirdDescription);
            actualTodoItems.AddTodo(fourthDescription);
            actualTodoItems.AddTodo(fifthDescription);

            // Set Done values for these five newly added tasks
            actualTodoItems.TodoArray[0].Done = firstDoneStatus;
            actualTodoItems.TodoArray[1].Done = secondDoneStatus;
            actualTodoItems.TodoArray[2].Done = thirdDoneStatus;
            actualTodoItems.TodoArray[3].Done = fourthDoneStatus;
            actualTodoItems.TodoArray[4].Done = fifthDoneStatus;

            Todo[] actualCompletedTodos = actualTodoItems.FindByDoneStatus(true);
            Todo[] actualPendingTodos = actualTodoItems.FindByDoneStatus(false);

            // Assert
            Assert.Equal(actualTodoItems.TodoArray, actualCompletedTodos);
            Assert.Equal(expectedPendingTasksArrayLength, actualPendingTodos.Length);
        }
        [Fact]
        public void FindByAssignee_FromPersonId()
        {
            // Arrange
            String firstDescription = "Buy coconut milk";
            Person firstAssignee = new Person("Shayan", "Alivand", 1);
            String secondDescription = "Go to the gym";
            String thirdDescription = "Install Visual Studio";
            Person thirdAssignee = new Person("Shayan", "Alivand", 1);
            String fourthDescription = "Eat a small cup of almonds";
            String fifthDescription = "Go to the park";
            Person fifthAssignee = new Person("Bart", "Simpson", 2);
            int expShayansTasksArrayLength = 2;
            int expBartsTasksArrayLength = 1;
            int expIncognitosTasksArrayLength = 0;

            // Act
            TodoSequencer.reset();
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.Clear();

            // Create five todo tasks using different descriptions
            actualTodoItems.AddTodo(firstDescription);
            actualTodoItems.AddTodo(secondDescription);
            actualTodoItems.AddTodo(thirdDescription);
            actualTodoItems.AddTodo(fourthDescription);
            actualTodoItems.AddTodo(fifthDescription);

            // Set assignee values for these five newly added tasks
            actualTodoItems.TodoArray[0].Assignee = firstAssignee;
            actualTodoItems.TodoArray[2].Assignee = thirdAssignee;
            actualTodoItems.TodoArray[4].Assignee = fifthAssignee;

            Todo[] shayansTodoItems = actualTodoItems.FindByAssignee(1);
            Todo[] bartsTodoItems = actualTodoItems.FindByAssignee(2);
            Todo[] incognitoTodoItems = actualTodoItems.FindByAssignee(9);

            // Assert
            Assert.Equal(expShayansTasksArrayLength, shayansTodoItems.Length);
            Assert.Equal(actualTodoItems.TodoArray[0], shayansTodoItems[0]);
            Assert.Equal(actualTodoItems.TodoArray[2], shayansTodoItems[1]);

            Assert.Equal(expBartsTasksArrayLength, bartsTodoItems.Length);
            Assert.Equal(actualTodoItems.TodoArray[4], bartsTodoItems[0]);

            Assert.Equal(expIncognitosTasksArrayLength, incognitoTodoItems.Length);
        }
        [Fact]
        public void FindByAssignee_FromPersonObj()
        {
            // Arrange
            String firstDescription = "Buy coconut milk";
            Person firstAssignee = new Person("Shayan", "Alivand", 1);
            String secondDescription = "Go to the gym";
            String thirdDescription = "Install Visual Studio";
            String fourthDescription = "Eat a small cup of almonds";
            String fifthDescription = "Go to the park";
            Person fifthAssignee = new Person("Bart", "Simpson", 2);
            Person incognitoAssignee = new Person("Eric", "Eric", 9);
            int expectedShayansTasksArrayLength = 2;
            int expectedBartsTasksArrayLength = 1;
            int expectedIncognitosTasksArrayLength = 0;

            // Act
            TodoSequencer.reset();
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.Clear();

            // Create five todo tasks using different descriptions
            actualTodoItems.AddTodo(firstDescription);
            actualTodoItems.AddTodo(secondDescription);
            actualTodoItems.AddTodo(thirdDescription);
            actualTodoItems.AddTodo(fourthDescription);
            actualTodoItems.AddTodo(fifthDescription);

            // Set assignee values for these five newly added tasks
            actualTodoItems.TodoArray[0].Assignee = firstAssignee;
            actualTodoItems.TodoArray[2].Assignee = firstAssignee;
            actualTodoItems.TodoArray[4].Assignee = fifthAssignee;

            Todo[] shayansTodoItems = actualTodoItems.FindByAssignee(firstAssignee);
            Todo[] bartsTodoItems = actualTodoItems.FindByAssignee(fifthAssignee);
            Todo[] incognitoTodoItems = actualTodoItems.FindByAssignee(incognitoAssignee);

            // Assert
            Assert.Equal(expectedShayansTasksArrayLength, shayansTodoItems.Length);
            Assert.Equal(actualTodoItems.TodoArray[0], shayansTodoItems[0]);
            Assert.Equal(actualTodoItems.TodoArray[2], shayansTodoItems[1]);

            Assert.Equal(expectedBartsTasksArrayLength, bartsTodoItems.Length);
            Assert.Equal(actualTodoItems.TodoArray[4], bartsTodoItems[0]);

            Assert.Equal(expectedIncognitosTasksArrayLength, incognitoTodoItems.Length);
        }
        [Fact]
        public void FindUnassignedTodoItemsWorks()
        {
            // Arrange
            String firstDescription = "Buy coconut milk";
            Person firstAssignee = new Person("Shayan", "Alivand", 1);
            String secondDescription = "Go to the gym";
            String thirdDescription = "Install Visual Studio";
            Person thirdAssignee = new Person("Shayan", "Alivand", 1);
            String fourthDescription = "Eat a small cup of almonds";
            String fifthDescription = "Go to the park";
            Person fifthAssignee = new Person("Bart", "Simpson", 2);
            int expUnassignedTasksArrayLength = 2;

            // Act
            TodoSequencer.reset();
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.Clear();

            // Create five todo tasks using different descriptions
            actualTodoItems.AddTodo(firstDescription);
            actualTodoItems.AddTodo(secondDescription);
            actualTodoItems.AddTodo(thirdDescription);
            actualTodoItems.AddTodo(fourthDescription);
            actualTodoItems.AddTodo(fifthDescription);

            // Set assignee values for these five newly added tasks
            actualTodoItems.TodoArray[0].Assignee = firstAssignee;
            actualTodoItems.TodoArray[2].Assignee = thirdAssignee;
            actualTodoItems.TodoArray[4].Assignee = fifthAssignee;

            Todo[] actualUnassignedTodoItems = actualTodoItems.FindUnassignedTodoItems();

            // Assert
            Assert.Equal(expUnassignedTasksArrayLength, actualUnassignedTodoItems.Length);
            Assert.Equal(actualTodoItems.TodoArray[1], actualUnassignedTodoItems[0]);
            Assert.Equal(actualTodoItems.TodoArray[3], actualUnassignedTodoItems[1]);
        }
    }
}
