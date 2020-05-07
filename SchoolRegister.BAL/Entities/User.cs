using Microsoft.AspNetCore.Identity;
using System;

namespace SchoolRegister.BAL.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}