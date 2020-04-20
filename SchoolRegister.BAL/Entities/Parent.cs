using System.Collections.Generic;

namespace SchoolRegister.BAL.Entities
{
    public class Parent : User
    {
        public virtual IList<Student> Students { get; set; }
    }
}