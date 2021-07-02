namespace ToDoIt.Data
{
    public class TodoSequencer
    {
        private static int todoId;

        public static int TodoId {
            get { return todoId; }
            set { todoId = value; }
        }

        public static int NextTodoId()
        {
            return ++TodoId;
        }

        public static int Reset()
        {
            return TodoId = 0;
        }
    }
}
