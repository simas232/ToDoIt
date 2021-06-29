using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt.Models
{
    public class Todo
    {
        private readonly int todoId;
        private String description;
        private bool done;
        private Person assignee;

        public int TodoId { get; set; }
        public String Description { get; set; }
        public bool Done { get; set; }
        public Person Assignee { get; set; }

        public Todo(int todoId, String description)
        {
            TodoId = todoId;
            Description = description;
            Done = done;
            Assignee = assignee;
        }
    }
}
