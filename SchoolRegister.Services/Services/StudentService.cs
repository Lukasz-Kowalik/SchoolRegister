using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SchoolRegister.BAL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.Vms;

namespace SchoolRegister.Services.Services
{
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public StudentVm GetStudent(Expression<Func<Student, bool>> expression)
        {
         //   var student = _dbContext.Users.Where(s=>s.);
            throw new NotImplementedException();
        }

        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
    }
}