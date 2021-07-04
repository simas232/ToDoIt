using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Models;

namespace ToDoIt.Data
{
    public class TodoItems
    {
        // Fields
        private static Todo[] todoArray = new Todo[0];

        // Properties
        public static Todo[] TodoArray
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
            return TodoArray.Length;
        }
        public Todo[] FindAll()
        {
            return TodoArray;
        }
    }
}
