using System.Collections.Generic;

namespace SchoolRegister.BAL.Entities
{
    public class Parent : User
    {
        public IList<Student> Students { get; set; }
    }
}