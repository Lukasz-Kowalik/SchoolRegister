using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SchoolRegister.ViewModels.DTOs;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGradeService
    {
        IEnumerable<GradeVm> GetGrades(Expression<Func<Grade, bool>> expression = null);
        GradeVm GetGrade(Expression<Func<Grade, bool>> expression);
        void AddGrade(GradeDto grade);
    }
}