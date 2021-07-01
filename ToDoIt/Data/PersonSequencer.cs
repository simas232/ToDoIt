using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt.Data
{
    public class PersonSequencer
    {
        private static int personId;

        public static int PersonId
        {
            get { return personId; }
            private set { personId = NextPersonId(); }
        }
        public static int NextPersonId()
        {
            return ++personId;
        }
        public static void Reset()
        {
            personId = 0;
        }
    }
}
