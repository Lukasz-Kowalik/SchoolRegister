using System;
using System.Collections.Generic;

namespace SchoolRegister.BAL.Entities
{
    public class Teacher : User
    {
        public IList<Subject> Subjects { get; set; }

        public string Title { get; set; }

        public Teacher()
        {
        }

        public Teacher(string firstName, string lastName, DateTime registrationDate, IList<Subject> subjects, string title)
            : base(firstName, lastName, registrationDate)
        {
            Subjects = subjects;
            Title = title;
        }
    }
}