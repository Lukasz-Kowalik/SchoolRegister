using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolRegister.Services.Interfaces
{
    public interface ITeacherService
    {
        bool SendEmailToParent(EmailMessageDto parent);

        TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filter);

        IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filter = null);
    }
}