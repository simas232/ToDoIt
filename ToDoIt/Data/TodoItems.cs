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
    }
}
