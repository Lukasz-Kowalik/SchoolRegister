using SchoolRegister.BAL.Entities;
using System;
using System.Collections.Generic;
using SchoolRegister.ViewModels.DTOs;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        List<Group> GetGroups();

        Group GetGroup(int id);

        void Add(GroupDto group);

        void Update(GroupDto group, int productId);

        void Delete(int id);
    }
}