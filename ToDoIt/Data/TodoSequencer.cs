namespace ToDoIt.Data
{
    public class TodoSequencer
    {
        // Fields
        private static int todoId;

        // Properties
        public static int TodoId
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
        public static int NextTodoId()
        {
            return ++todoId;
        }
        public static void Reset()
        {
            todoId = 0;
        }
    }
}
