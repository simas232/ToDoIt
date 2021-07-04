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
        public static int nextTodoId()
        {
            return ++TodoId;
        }
        public static void reset()
        {
            TodoId = 0;
        }
    }
}
