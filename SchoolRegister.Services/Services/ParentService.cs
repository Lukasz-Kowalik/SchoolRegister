using AutoMapper;
using SchoolRegister.BAL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SchoolRegister.Services.Services
{
    public class ParentService : BaseService, IParentService
    {
        public ParentService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public ParentVm GetParent(Expression<Func<Parent, bool>> expression)
        {
            var parentEntity = _dbContext.Users.OfType<Parent>()
                .Include(p => p.Students)
                .ThenInclude(s => s.Grades)
                .SingleOrDefault(expression);
            var parentVm = Mapper.Map<ParentVm>(parentEntity);
            return parentVm;
        }

        public IEquatable<ParentVm> GetParents(Expression<Func<Parent, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}