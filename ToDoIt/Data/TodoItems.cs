using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Models;

namespace ToDoIt.Data
{
    public class TodoItems
    {
        private static Todo[] todoArray = new Todo[0];
        public static Todo[] TodoArray
        {
            get { return todoArray; }
            set { todoArray = value; }
        }

        public static int Size()
        {
            return TodoArray.Length;
        }
    }
}
