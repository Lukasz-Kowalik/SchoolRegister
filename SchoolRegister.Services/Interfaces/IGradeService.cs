using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.DTOs;
using System.Collections.Generic;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGradeService
    {
        List<Grade> Get(Student student);

        void AddOrUpdate(GradeDto grade, Student student);
        void Remove(GradeDto grade, Student student);
    }
}