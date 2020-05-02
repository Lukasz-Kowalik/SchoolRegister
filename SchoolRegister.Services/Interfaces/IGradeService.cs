using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGradeService
    {
        IEnumerable<GradeVm> GetGrades(Expression<Func<Grade,bool>> expression=null);
        GradeVm GetGrade(Expression<Func<Grade, bool>> expression);
        bool Add(GradeVm  grade, Student student);
        bool Update(GradeVm grade, Student student);
        bool Remove(GradeDto grade, Student student);
    }
}