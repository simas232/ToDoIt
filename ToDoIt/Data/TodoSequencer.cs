namespace ToDoIt.Data
{
    public class TodoSequencer
    {
        // Fields
        private static int todoId;

        // Properties
        public int TodoId
        {
            get
            {
                return todoId;
            }
            set
            {
                todoId = value;
            }
        }

        // Methods
        public static int nextTodoId()
        {
            return ++todoId;
        }
        public static void reset()
        {
            todoId = 0;
        }
    }
}
