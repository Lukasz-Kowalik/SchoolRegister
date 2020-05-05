using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.BAL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolRegister.Services.Services
{
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public StudentVm GetStudent(Expression<Func<Student, bool>> expression)
        {
            var studentEntity = _dbContext.Users.OfType<Student>().Include(x=>x.Grades)
                .Include(s => s.Grades)
                .Include(s => s.Group)
                .Include(s => s.Parent)
                .AsQueryable()
                .SingleOrDefault(expression);
            var studentVm = Mapper.Map<StudentVm>(studentEntity);
            return studentVm;
        }

        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> expression = null)
        {
            var studentsEntity = _dbContext.Users.OfType<Student>()
                    .Include(s => s.Grades)
                    .ThenInclude(g=>g.Subject)
                    .Include(s=>s.Group)
                    .Include(s=>s.Parent)
                .AsQueryable();
            if (expression == null)
            {
                studentsEntity = studentsEntity.Where(expression);
            }
            var studentVm = Mapper.Map<IEnumerable<StudentVm>>(studentsEntity);
            return studentVm;
        }
    }
}