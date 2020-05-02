using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.Vms;

namespace SchoolRegister.Services.Interfaces
{
   public interface IStudentService
   {
       StudentVm GetStudent(Expression<Func<Student, bool>> expression);
       IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> expression = null);
   }
}
