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
            Array.Resize(ref todoArray, Size() + 1);
            todoArray[Size() - 1] = new Todo(TodoSequencer.nextTodoId(), description);
            return todoArray[Size() - 1];
        }
        public void Clear()
        {
            todoArray = new Todo[0];
        }
    }
}
