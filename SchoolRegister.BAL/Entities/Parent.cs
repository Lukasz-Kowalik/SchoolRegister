using System;
using System.Collections.Generic;

namespace SchoolRegister.BAL.Entities
{
    public class Parent : User
    {
        public IList<Student> Students { get; set; }

        public Parent(string firstName, string lastName, DateTime registrationDate, IList<Student> students)
            : base(firstName, lastName, registrationDate)
        {
            Students = students;
        }

        public Parent()
        {
        }
    }
}