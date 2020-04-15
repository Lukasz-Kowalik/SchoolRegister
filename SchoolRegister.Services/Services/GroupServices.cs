using System;
using System.Collections.Generic;
using System.Text;
using SchoolRegister.BAL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;

namespace SchoolRegister.Services.Services
{
    class GroupServices:BaseService,IGroupService
    {
        public GroupServices(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Lazy<Group> Get()
        {
            throw new NotImplementedException();
        }

        public Group Get(int id)
        {
            throw new NotImplementedException();
        }
        
        public void Add(Group @group)
        {
            throw new NotImplementedException();
        }

        public void Update(Group @group, int productId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
