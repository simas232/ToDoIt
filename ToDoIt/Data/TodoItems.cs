using System;
using ToDoIt.Models;

namespace ToDoIt.Data
{
    public class TodoItems
    {
        // Fields
        private static Todo[] todoArray = new Todo[0];

        // Properties
        public Todo[] TodoArray
        {
            get
            {
                return todoArray;
            }
            set
            {
                todoArray = value;
            }
        }

        // Methods
        public int Size()
        {
            return todoArray.Length;
        }
        public Todo[] FindAll()
        {
            return todoArray;
        }
        public Todo FindById(int todoId)
        {
            // It is assumed that only one person with personId exists. If there are multiple, then only first hit is returned
            foreach (Todo todoEntry in todoArray)
            {
                if (todoEntry.TodoId == todoId)
                {
                    return todoEntry;
                }
            }
            return null;
        }
        public Todo AddTodo(String description)
        {
            Array.Resize(ref todoArray, todoArray.Length + 1);
            todoArray[todoArray.Length - 1] = new Todo(TodoSequencer.nextTodoId(), description);
            return todoArray[todoArray.Length - 1];
        }
        public void Clear()
        {
            todoArray = new Todo[0];
        }
        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] filteredTodoArray = new Todo[0];
            foreach (Todo todoEntry in todoArray)
            {
                if (todoEntry.Done == doneStatus)
                {
                    Array.Resize(ref filteredTodoArray, filteredTodoArray.Length + 1);
                    filteredTodoArray[filteredTodoArray.Length - 1] = todoEntry;
                }
            }
            return filteredTodoArray;
        }
        public Todo[] FindByAssignee(int personId)
        {
            Todo[] filteredTodoArray = new Todo[0];
            foreach (Todo todoEntry in todoArray)
            {
                if (todoEntry.Assignee != null)
                {
                    if (todoEntry.Assignee.PersonId == personId)
                    {
                        Array.Resize(ref filteredTodoArray, filteredTodoArray.Length + 1);
                        filteredTodoArray[filteredTodoArray.Length - 1] = todoEntry;
                    }
                }
            }
            return filteredTodoArray;
        }
        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] filteredTodoArray = new Todo[0];
            foreach (Todo todoEntry in todoArray)
            {
                if (todoEntry.Assignee == assignee)
                {
                    Array.Resize(ref filteredTodoArray, filteredTodoArray.Length + 1);
                    filteredTodoArray[filteredTodoArray.Length - 1] = todoEntry;
                }
            }
            return filteredTodoArray;
        }
        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] filteredTodoArray = new Todo[0];
            foreach (Todo todoEntry in todoArray)
            {
                if (todoEntry.Assignee == null)
                {
                    Array.Resize(ref filteredTodoArray, filteredTodoArray.Length + 1);
                    filteredTodoArray[filteredTodoArray.Length - 1] = todoEntry;
                }
            }
            return filteredTodoArray;
        }
        public void RemoveTodo(Todo todoEntryToRemove)
        {
            //This function firstly identifies the index of person to be deleted and the reformats the array by skipping that index
            int indexToRemove = 0;

            foreach (Todo todoEntry in todoArray)
            {
                if (todoEntry == todoEntryToRemove)
                {
                    break;
                }
                indexToRemove++;
            }
            if ((indexToRemove == todoArray.Length) || (todoArray.Length == 0)) 
            {
                return;
            }

            for (int index = 0; index < todoArray.Length - 1; index++)
            {
                todoArray[index] = index < indexToRemove ? todoArray[index] : todoArray[index + 1];
            }
            Array.Resize(ref todoArray, todoArray.Length - 1);
        }
    }
}
