﻿using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Models;

namespace ToDoIt.Data
{
    public class People
    {
        private static Person[] arrPerson = new Person[0];
        public static Person[] ArrPerson
        { ​​​​​​​
            get {​​​​​​​ return arrPerson; }​​​​​​​
            set {​​​​​​​ arrPerson = value; }​​​​​​​
        }​​​​​​​

        public static int Size()
        {
            return ArrPerson.Length;
        }
    }
}
