using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.BAL.Entities
{
    public class Role : IdentityRole<int>
    {
       
        public Role()
        {
        }

        public Role(string roleName) : base(roleName)
        {
        }
    }
}