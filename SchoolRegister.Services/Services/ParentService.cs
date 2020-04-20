using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;

namespace SchoolRegister.Services.Services
{
    public class ParentService: BaseService,IParentService
    {
        public ParentService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}