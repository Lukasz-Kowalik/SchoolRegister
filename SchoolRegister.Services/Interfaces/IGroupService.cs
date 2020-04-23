using SchoolRegister.BAL.Entities;
using System;
using System.Collections.Generic;
using SchoolRegister.ViewModels.DTOs;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        List<Group> Get();

        Group Get(int id);

        void Add(GroupDto group);

        void Update(GroupDto group, int productId);

        void Delete(int id);
    }
}