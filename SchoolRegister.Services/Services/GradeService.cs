using System;
using System.Collections.Generic;
using System.Text;
using SchoolRegister.BAL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;

namespace SchoolRegister.Services.Services
{
  public  class GradeService:BaseService,IGradeService
    {
        public GradeService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public List<Grade> Get(Student student)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdate(GradeDto grade, Student student)
        {
            throw new NotImplementedException();
        }

        public void Remove(GradeDto grade, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
