using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SchoolRegister.ViewModels.DTOs;

namespace SchoolRegister.Services.Interfaces
{
    public interface IStudentService
    {
        StudentVm GetStudent(Expression<Func<Student, bool>> expression);

        IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> expression = null);

        void Update(StudentVm studentVm);
        void RemoveStudentFromGroup(int? studentId);
        void AddStudentToGroup(StudentDto studentDto, int? groupId);
    }
}