using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.DTOs;
using System.Collections.Generic;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGradeService
    {
        List<Grade> Get(StudentDto student);

        void AddOrUpdate(GradeDto grade, StudentDto student);
        void Remove(GradeDto grade, StudentDto student);
    }
}