using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Linq.Expressions;

namespace SchoolRegister.Services.Interfaces
{
    public interface IParentService
    {
      
        ParentVm GetParent(Expression<Func<Parent, bool>> expression);

        IEquatable<ParentVm> GetParents(Expression<Func<Parent, bool>> expression = null);


    }
}