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
        public static int Size()
        {
            return TodoArray.Length;
        }

        public static Todo[] FindAll()
        {
            return TodoArray;
        }
    }
}
