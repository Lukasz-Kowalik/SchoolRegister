using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolRegister.Services.Interfaces
{
    public interface IStudentService
    {
        StudentVm GetStudent(Expression<Func<Student, bool>> expression);

        IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> expression = null);
    }
}