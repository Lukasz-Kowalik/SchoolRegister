using Microsoft.AspNetCore.Identity;

namespace SchoolRegister.BAL.Entities
{
    public class Role : IdentityRole<int>
    {
        public RoleValue RoleValue { get; set; }

        public Role()
        {
        }

        public Role(string roleName, RoleValue roleValue) : base(roleName)
        {
            RoleValue = roleValue;
        }
    }
}