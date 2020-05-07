using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> expression = null);

        GroupVm GetGroup(Expression<Func<Group, bool>> expression);

        void Add(GroupDto group);
        
        void Update(GroupDto group);
        void Delete(int groupId);
        
    }
}