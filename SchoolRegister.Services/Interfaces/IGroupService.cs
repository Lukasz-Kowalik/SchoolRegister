using SchoolRegister.BAL.Entities;
using System;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGroupService
    {
        Lazy<Group> Get();

        Group Get(int id);

        void Add(Group @group);

        void Update(Group @group, int productId);

        void Delete(int id);
    }
}