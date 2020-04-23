using System;
using System.Collections.Generic;
using System.Text;
using SchoolRegister.BAL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;

namespace SchoolRegister.Services.Services
{
  public  class GroupService:BaseService,IGroupService
    {
        public GroupService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }


        public List<Group> Get()
        {
            throw new NotImplementedException();
        }

        public Group Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(GroupDto @group)
        {
            throw new NotImplementedException();
        }

        public void Update(GroupDto @group, int productId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
