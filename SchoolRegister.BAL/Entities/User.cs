using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.BAL
{
    public class User : IUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public User()
        {
        }

        public User(string firstName, string lastName, DateTime registrationDate)
        {
            FirstName = firstName;
            LastName = lastName;
            RegistrationDate = registrationDate;
        }
    }
}