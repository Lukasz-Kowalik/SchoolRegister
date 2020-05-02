using System;
using System.Linq.Expressions;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.Vms;

namespace SchoolRegister.Services.Interfaces
{
    public interface IParentService
    {
        //I don't know exactly what I need 
        ParentVm GetParent(Expression<Func<Parent,bool>> expression);
        IEquatable<ParentVm> GetParents(Expression<Func<Parent, bool>> expression = null);
        bool AddStudent(ParentVm parent);
    }
}