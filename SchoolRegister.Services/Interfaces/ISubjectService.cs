using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.Vms;

namespace SchoolRegister.Services.Interfaces
{
    public interface ISubjectService
    {
        SubjectVm AddOrUpdate(AddOrUpdateSubjectDto addOrUpdateDto);
        SubjectVm GetSubject(Expression<Func<Subject, bool>> filterPredicate);
        IEnumerable<SubjectVm> GetSubjects(Expression<Func<Subject, bool>> filterProduct = null);
    }
}
