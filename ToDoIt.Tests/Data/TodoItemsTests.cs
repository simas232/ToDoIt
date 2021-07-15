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
            String expectedFirstDescription = "Buy coconut milk";
            String expectedSecondDescription = "Go to the gym";
            String expectedThirdDescription = "Install Visual Studio";
            int expectedFirstTodoId = 1;
            int expectedSecondTodoId = 2;
            int expectedThirdTodoId = 3;
            int expectedSize = 3;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[0];

            // Act
            Todo actualFirstTodo = actualTodoItems.AddTodo(expectedFirstDescription);
            Todo actualSecondTodo = actualTodoItems.AddTodo(expectedSecondDescription);
            Todo actualThirdTodo = actualTodoItems.AddTodo(expectedThirdDescription);
            Todo[] testTodoItemsArray = actualTodoItems.TodoArray;

            // Assert

            // Check if Todo objects returned by AddTodo function contain valid todoIds and descriptions
            Assert.Equal(expectedFirstDescription, actualFirstTodo.Description);
            Assert.Equal(expectedFirstTodoId, actualFirstTodo.TodoId);
            Assert.Equal(expectedSecondDescription, actualSecondTodo.Description);
            Assert.Equal(expectedSecondTodoId, actualSecondTodo.TodoId);
            Assert.Equal(expectedThirdDescription, actualThirdTodo.Description);
            Assert.Equal(expectedThirdTodoId, actualThirdTodo.TodoId);

            // Check if actualTodoItems Todo array contain Todo objects with valid todoIds and descriptions
            Assert.Equal(expectedFirstDescription, testTodoItemsArray[0].Description);
            Assert.Equal(expectedFirstTodoId, testTodoItemsArray[0].TodoId);
            Assert.Equal(expectedSecondDescription, testTodoItemsArray[1].Description);
            Assert.Equal(expectedSecondTodoId, testTodoItemsArray[1].TodoId);
            Assert.Equal(expectedThirdDescription, testTodoItemsArray[2].Description);
            Assert.Equal(expectedThirdTodoId, testTodoItemsArray[2].TodoId);

            // Since three Todo tasks were added actualTodoItems, the length of testTodoItemsArray should also be the same
            Assert.Equal(expectedSize, testTodoItemsArray.Length);
        }
        [Fact]
        public void SizeZeroWorks()
        {
            // Arrange
            int expectedSize;
            int actualSize;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[0];
            expectedSize = actualTodoItems.TodoArray.Length;

            // Act
            actualSize = actualTodoItems.Size();

            // Assert
            Assert.Equal(expectedSize, actualSize);
        }
        [Fact]
        public void SizeNonZeroWorks()
        {
            // Arrange
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");
            int expectedSizeOneTodo = 1;
            int expectedSizeTwoTodos = 2;
            int expectedSizeThreeTodos = 3;
            int actualSizeOneTodo;
            int actualSizeTwoTodos;
            int actualSizeThreeTodos;

            TodoItems actualTodoItems = new TodoItems();

            // Act
            actualTodoItems.TodoArray = new Todo[1];
            actualTodoItems.TodoArray[0] = firstTodo;
            actualSizeOneTodo = actualTodoItems.Size();

            actualTodoItems.TodoArray = new Todo[2];
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualSizeTwoTodos = actualTodoItems.Size();

            actualTodoItems.TodoArray = new Todo[3];
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;
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
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");

            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[3];
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;

            // Act
            Todo[] testTodoItemsArray = actualTodoItems.FindAll();

            // Assert
            Assert.Equal(actualTodoItems.TodoArray, testTodoItemsArray); 
        }
        [Fact]
        public void ClearWorks()
        {
            // Arrange
            Todo firstTodo = new Todo(1, "Buy coconut milk");

            int expectedSize = 0;
            int actualSize;

            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[1];
            actualTodoItems.TodoArray[0] = firstTodo;

            // Act
            actualTodoItems.Clear();
            actualSize = actualTodoItems.TodoArray.Length;

            // Assert
            Assert.Equal(expectedSize, actualSize);
        }
        [Fact]
        public void FindById_EntryFoundWorks()
        {
            // Arrange
            Todo expectedFirstTodo = new Todo(1, "Buy coconut milk");
            Todo expectedSecondTodo = new Todo(2, "Go to the gym");
            Todo expectedThirdTodo = new Todo(3, "Install Visual Studio");

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[3];
            actualTodoItems.TodoArray[0] = expectedFirstTodo;
            actualTodoItems.TodoArray[1] = expectedSecondTodo;
            actualTodoItems.TodoArray[2] = expectedThirdTodo;

            // Act
            Todo actualFirstTodo = actualTodoItems.FindById(1);
            Todo actualSecondTodo = actualTodoItems.FindById(2);
            Todo actualThirdTodo = actualTodoItems.FindById(3);

            // Assert
            Assert.Equal(expectedFirstTodo, actualFirstTodo);
            Assert.Equal(expectedSecondTodo, actualSecondTodo);
            Assert.Equal(expectedThirdTodo, actualThirdTodo);
        }
        [Fact]
        public void FindById_NoEntriesFoundWorks()
        {
            // Arrange
            Todo expectedFirstTodo = new Todo(1, "Buy coconut milk");
            Todo expectedSecondTodo = new Todo(2, "Go to the gym");
            Todo expectedThirdTodo = new Todo(3, "Install Visual Studio");
            Todo expectedTodo = null;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[3];
            actualTodoItems.TodoArray[0] = expectedFirstTodo;
            actualTodoItems.TodoArray[1] = expectedSecondTodo;
            actualTodoItems.TodoArray[2] = expectedThirdTodo;

            // Act
            Todo actualTodo = actualTodoItems.FindById(9);

            // Assert
            Assert.Equal(expectedTodo, actualTodo);
        }
        [Fact]
        public void FindByDoneStatus_MixedWorks()
        {
            // Arrange
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");
            Todo fourthTodo = new Todo(4, "Eat a small cup of almonds");
            Todo fifthTodo = new Todo(5, "Go to the park");
            bool firstDoneStatus = true;
            bool secondDoneStatus = false;
            bool thirdDoneStatus = false;
            bool fourthDoneStatus = true;
            bool fifthDoneStatus = true;
            int expectedDoneTasksArrayLength = 3;
            int expectedPendingTasksArrayLength = 2;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[5];

            // Create five todo tasks using different descriptions
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;
            actualTodoItems.TodoArray[3] = fourthTodo;
            actualTodoItems.TodoArray[4] = fifthTodo;

            // Set Done values for these five newly added tasks
            actualTodoItems.TodoArray[0].Done = firstDoneStatus;
            actualTodoItems.TodoArray[1].Done = secondDoneStatus;
            actualTodoItems.TodoArray[2].Done = thirdDoneStatus;
            actualTodoItems.TodoArray[3].Done = fourthDoneStatus;
            actualTodoItems.TodoArray[4].Done = fifthDoneStatus;

            // Act
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
        public void FindByDoneStatus_AllDoneWorks()
        {
            // Arrange
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");
            Todo fourthTodo = new Todo(4, "Eat a small cup of almonds");
            Todo fifthTodo = new Todo(5, "Go to the park");

            bool firstDoneStatus = true;
            bool secondDoneStatus = true;
            bool thirdDoneStatus = true;
            bool fourthDoneStatus = true;
            bool fifthDoneStatus = true;
            int expectedPendingTasksArrayLength = 0;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[5];

            // Create five todo tasks using different descriptions
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;
            actualTodoItems.TodoArray[3] = fourthTodo;
            actualTodoItems.TodoArray[4] = fifthTodo;

            // Set Done values for these five newly added tasks
            actualTodoItems.TodoArray[0].Done = firstDoneStatus;
            actualTodoItems.TodoArray[1].Done = secondDoneStatus;
            actualTodoItems.TodoArray[2].Done = thirdDoneStatus;
            actualTodoItems.TodoArray[3].Done = fourthDoneStatus;
            actualTodoItems.TodoArray[4].Done = fifthDoneStatus;

            // Act
            Todo[] actualCompletedTodos = actualTodoItems.FindByDoneStatus(true);
            Todo[] actualPendingTodos = actualTodoItems.FindByDoneStatus(false);

            // Assert
            Assert.Equal(actualTodoItems.TodoArray, actualCompletedTodos);
            Assert.Equal(expectedPendingTasksArrayLength, actualPendingTodos.Length);
        }
        [Fact]
        public void FindByAssignee_FromPersonIdWorks()
        {
            // Arrange
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");
            Todo fourthTodo = new Todo(4, "Eat a small cup of almonds");
            Todo fifthTodo = new Todo(5, "Go to the park");

            Person firstAssignee = new Person("Shayan", "Alivand", 1);
            Person fifthAssignee = new Person("Bart", "Simpson", 2);
            int expShayansTasksArrayLength = 2;
            int expBartsTasksArrayLength = 1;
            int expIncognitosTasksArrayLength = 0;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[5];

            // Create five todo tasks using different descriptions
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;
            actualTodoItems.TodoArray[3] = fourthTodo;
            actualTodoItems.TodoArray[4] = fifthTodo;

            // Set assignee values for these five newly added tasks
            actualTodoItems.TodoArray[0].Assignee = firstAssignee;
            actualTodoItems.TodoArray[2].Assignee = firstAssignee;
            actualTodoItems.TodoArray[4].Assignee = fifthAssignee;

            // Act
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
        public void FindByAssignee_FromPersonObjWorks()
        {
            // Arrange
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");
            Todo fourthTodo = new Todo(4, "Eat a small cup of almonds");
            Todo fifthTodo = new Todo(5, "Go to the park");

            Person firstAssignee = new Person("Shayan", "Alivand", 1);
            Person fifthAssignee = new Person("Bart", "Simpson", 2);

            Person incognitoAssignee = new Person("Eric", "Eric", 9);
            int expectedShayansTasksArrayLength = 2;
            int expectedBartsTasksArrayLength = 1;
            int expectedIncognitosTasksArrayLength = 0;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[5];

            // Create five todo tasks using different descriptions
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;
            actualTodoItems.TodoArray[3] = fourthTodo;
            actualTodoItems.TodoArray[4] = fifthTodo;

            // Set assignee values for these five newly added tasks
            actualTodoItems.TodoArray[0].Assignee = firstAssignee;
            actualTodoItems.TodoArray[2].Assignee = firstAssignee;
            actualTodoItems.TodoArray[4].Assignee = fifthAssignee;

            // Act
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
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");
            Todo fourthTodo = new Todo(4, "Eat a small cup of almonds");
            Todo fifthTodo = new Todo(5, "Go to the park");

            Person firstAssignee = new Person("Shayan", "Alivand", 1);
            Person fifthAssignee = new Person("Bart", "Simpson", 2);

            int expUnassignedTasksArrayLength = 2;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[5];

            // Create five todo tasks using different descriptions
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;
            actualTodoItems.TodoArray[3] = fourthTodo;
            actualTodoItems.TodoArray[4] = fifthTodo;

            // Set assignee values for these five newly added tasks
            actualTodoItems.TodoArray[0].Assignee = firstAssignee;
            actualTodoItems.TodoArray[2].Assignee = firstAssignee;
            actualTodoItems.TodoArray[4].Assignee = fifthAssignee;

            // Act
            Todo[] actualUnassignedTodoItems = actualTodoItems.FindUnassignedTodoItems();

            // Assert
            Assert.Equal(expUnassignedTasksArrayLength, actualUnassignedTodoItems.Length);
            Assert.Equal(actualTodoItems.TodoArray[1], actualUnassignedTodoItems[0]);
            Assert.Equal(actualTodoItems.TodoArray[3], actualUnassignedTodoItems[1]);
        }
        [Fact]
        public void RemoveTodo_FirstEntryWorks()
        {
            // Arrange
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");
            Todo fourthTodo = new Todo(4, "Eat a small cup of almonds");
            Todo fifthTodo = new Todo(5, "Go to the park");

            int expectedTasksArrayLength = 4;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[5];

            // Create five todo tasks using different descriptions
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;
            actualTodoItems.TodoArray[3] = fourthTodo;
            actualTodoItems.TodoArray[4] = fifthTodo;

            // Act
            actualTodoItems.RemoveTodo(firstTodo);

            // Assert
            Assert.Equal(expectedTasksArrayLength, actualTodoItems.TodoArray.Length);
            Assert.Equal(secondTodo, actualTodoItems.TodoArray[0]);
            Assert.Equal(thirdTodo, actualTodoItems.TodoArray[1]);
            Assert.Equal(fourthTodo, actualTodoItems.TodoArray[2]);
            Assert.Equal(fifthTodo, actualTodoItems.TodoArray[3]);
        }
        [Fact]
        public void RemoveTodo_MiddleEntryWorks()
        {
            // Arrange
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");
            Todo fourthTodo = new Todo(4, "Eat a small cup of almonds");
            Todo fifthTodo = new Todo(5, "Go to the park");

            int expectedTasksArrayLength = 4;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[5];

            // Create five todo tasks using different descriptions
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;
            actualTodoItems.TodoArray[3] = fourthTodo;
            actualTodoItems.TodoArray[4] = fifthTodo;

            // Act
            actualTodoItems.RemoveTodo(thirdTodo);

            // Assert
            Assert.Equal(expectedTasksArrayLength, actualTodoItems.TodoArray.Length);
            Assert.Equal(firstTodo, actualTodoItems.TodoArray[0]);
            Assert.Equal(secondTodo, actualTodoItems.TodoArray[1]);
            Assert.Equal(fourthTodo, actualTodoItems.TodoArray[2]);
            Assert.Equal(fifthTodo, actualTodoItems.TodoArray[3]);
        }
        [Fact]
        public void RemoveTodo_LastEntryWorks()
        {
            // Arrange
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");
            Todo fourthTodo = new Todo(4, "Eat a small cup of almonds");
            Todo fifthTodo = new Todo(5, "Go to the park");

            int expectedTasksArrayLength = 4;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[5];

            // Create five todo tasks using different descriptions
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;
            actualTodoItems.TodoArray[3] = fourthTodo;
            actualTodoItems.TodoArray[4] = fifthTodo;

            // Act
            actualTodoItems.RemoveTodo(fifthTodo);

            // Assert
            Assert.Equal(expectedTasksArrayLength, actualTodoItems.TodoArray.Length);
            Assert.Equal(firstTodo, actualTodoItems.TodoArray[0]);
            Assert.Equal(secondTodo, actualTodoItems.TodoArray[1]);
            Assert.Equal(thirdTodo, actualTodoItems.TodoArray[2]);
            Assert.Equal(fourthTodo, actualTodoItems.TodoArray[3]);
        }
        [Fact]
        public void RemoveTodo_ThreeEntriesWorks()
        {
            // Arrange
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");
            Todo fourthTodo = new Todo(4, "Eat a small cup of almonds");
            Todo fifthTodo = new Todo(5, "Go to the park");

            int expectedTasksArrayLength = 2;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[5];

            // Create five todo tasks using different descriptions
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;
            actualTodoItems.TodoArray[3] = fourthTodo;
            actualTodoItems.TodoArray[4] = fifthTodo;

            // Act

            // Remove first, third and fifth entries so only second and fourth original entries should remain
            actualTodoItems.RemoveTodo(firstTodo);
            actualTodoItems.RemoveTodo(thirdTodo);
            actualTodoItems.RemoveTodo(fifthTodo);

            // Assert
            Assert.Equal(expectedTasksArrayLength, actualTodoItems.TodoArray.Length);
            Assert.Equal(secondTodo, actualTodoItems.TodoArray[0]);
            Assert.Equal(fourthTodo, actualTodoItems.TodoArray[1]);

        }
        [Fact]
        public void RemoveTodo_AllEntriesWorks()
        {
            // Arrange
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");
            Todo fourthTodo = new Todo(4, "Eat a small cup of almonds");
            Todo fifthTodo = new Todo(5, "Go to the park");

            int expectedTasksArrayLength = 0;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[5];

            // Create five todo tasks using different descriptions
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;
            actualTodoItems.TodoArray[3] = fourthTodo;
            actualTodoItems.TodoArray[4] = fifthTodo;

            // Act

            // Remove all five entries from the object
            actualTodoItems.RemoveTodo(firstTodo);
            actualTodoItems.RemoveTodo(secondTodo);
            actualTodoItems.RemoveTodo(thirdTodo);
            actualTodoItems.RemoveTodo(fourthTodo);
            actualTodoItems.RemoveTodo(fifthTodo);

            // Assert
            Assert.Equal(expectedTasksArrayLength, actualTodoItems.TodoArray.Length);
        }
        [Fact]
        public void RemoveTodo_NoEntriesFoundWorks()
        {
            // Arrange
            Todo firstTodo = new Todo(1, "Buy coconut milk");
            Todo secondTodo = new Todo(2, "Go to the gym");
            Todo thirdTodo = new Todo(3, "Install Visual Studio");
            Todo fourthTodo = new Todo(4, "Eat a small cup of almonds");
            Todo fifthTodo = new Todo(5, "Go to the park");

            Todo falseTask = new Todo(9, "Go fishing");

            int expectedTasksArrayLength = 5;

            TodoSequencer.TodoId = 0;
            TodoItems actualTodoItems = new TodoItems();
            actualTodoItems.TodoArray = new Todo[5];

            // Create five todo tasks using different descriptions
            actualTodoItems.TodoArray[0] = firstTodo;
            actualTodoItems.TodoArray[1] = secondTodo;
            actualTodoItems.TodoArray[2] = thirdTodo;
            actualTodoItems.TodoArray[3] = fourthTodo;
            actualTodoItems.TodoArray[4] = fifthTodo;

            // Act
            actualTodoItems.RemoveTodo(falseTask);

            // Assert
            Assert.Equal(expectedTasksArrayLength, actualTodoItems.TodoArray.Length);
            Assert.Equal(firstTodo, actualTodoItems.TodoArray[0]);
            Assert.Equal(secondTodo, actualTodoItems.TodoArray[1]);
            Assert.Equal(thirdTodo, actualTodoItems.TodoArray[2]);
            Assert.Equal(fourthTodo, actualTodoItems.TodoArray[3]);
            Assert.Equal(fifthTodo, actualTodoItems.TodoArray[4]);
        }
    }
}
