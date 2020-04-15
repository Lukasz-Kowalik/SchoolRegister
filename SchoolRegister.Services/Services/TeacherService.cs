using System;
using System.Collections.Generic;
using System.Text;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;

namespace SchoolRegister.Services.Services
{
    public class TeacherService:BaseService,ITeacherService
    {
        public TeacherService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void SendEmail(StudentDto student)
        {
            throw new NotImplementedException();
        }

        public void SendEmail(ParentDto parent)
        {
            throw new NotImplementedException();
        }
    }
}
