using System;

namespace SchoolRegister.BAL
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime RegistrationDate { get; set; }
    }
}