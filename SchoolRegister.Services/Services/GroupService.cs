using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.BAL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolRegister.Services.Services
{
    public class GroupService : BaseService, IGroupService
    {
        public GroupService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<GroupVm> GetGroups(Expression<Func<Group, bool>> expression = null)
        {
            var groupsEntity = _dbContext.Groups
                .Include(g => g.Students)
                .Include(g => g.SubjectGroups)
                .AsQueryable();
            if (expression != null)
            {
                groupsEntity = groupsEntity.Where(expression);
            }

            var groupsVm = Mapper.Map<IEnumerable<GroupVm>>(groupsEntity);
            return groupsVm;
        }

        public GroupVm GetGroup(Expression<Func<Group, bool>> expression)
        {
            var groupsEntity = _dbContext.Groups
                .Include(g => g.Students)
                .Include(g => g.SubjectGroups)
                .SingleOrDefault(expression);
            var groupVm = Mapper.Map<GroupVm>(groupsEntity);
            return groupVm;
        }

        public void Add(GroupDto @group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("Group is a null");
            }
            var isExist = _dbContext.Groups.Any(g => g.Name == group.Name);
            if (isExist)
            {
                throw new ArgumentException("Group already exists");
            }

            var groupEntity = Mapper.Map<Group>(group);
            _dbContext.Groups.Add(groupEntity);
            _dbContext.SaveChanges();
        }

        public void Update(GroupDto @group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("Value is a null");
            }

            var groupEntity = Mapper.Map<Group>(group);
            _dbContext.Groups.Update(groupEntity);
            _dbContext.SaveChanges();
        }

        public void Delete(int groupId)
        {
            var group = _dbContext.Groups.Single(g => g.Id == groupId);
            if (group == null)
            {
                throw new ArgumentNullException("group doesn't exists");
            }
            _dbContext.Groups.Remove(group);
            _dbContext.SaveChanges();
        }
    }
}