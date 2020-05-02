using System;
using System.Linq.Expressions;
using SchoolRegister.BAL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.Vms;

namespace SchoolRegister.Services.Services
{
    public class ParentService: BaseService,IParentService
    {
        public ParentService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public ParentVm GetParent(Expression<Func<Parent, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEquatable<ParentVm> GetParents(Expression<Func<Parent, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public bool AddStudent(ParentVm parent)
        {
            throw new NotImplementedException();
        }
    }
}