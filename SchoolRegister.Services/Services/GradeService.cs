using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.BAL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolRegister.Services.Services
{
    public class GradeService : BaseService, IGradeService
    {
        private readonly IStudentService _studentService;

        public GradeService(ApplicationDbContext dbContext, IStudentService studentService) : base(dbContext)
        {
            _studentService = studentService;
        }

        public IEnumerable<GradeVm> GetGrades(Expression<Func<Grade, bool>> expression)
        {
            var gradesEntities = _dbContext.Grade
                .AsNoTracking()
                .AsQueryable();
            if (expression != null)
            {
                gradesEntities = gradesEntities.Where(expression);
            }

            var gradesVm = Mapper.Map<IEnumerable<GradeVm>>(gradesEntities);
            return gradesVm;
        }

        public GradeVm GetGrade(Expression<Func<Grade, bool>> expression)
        {
            var gradeEntity = _dbContext.Grade.AsNoTracking().SingleOrDefault(expression);
            var grade = Mapper.Map<GradeVm>(gradeEntity);
            return grade;
        }

        public bool Add(GradeVm grade, Student student)
        {
            var gradeDto = Mapper.Map<GradeVm>(grade);
            return true;
        }

        public bool Update(GradeVm grade, Student student)
        {
            throw new NotImplementedException();
        }

        public bool Remove(GradeDto grade, Student student)
        {
            throw new NotImplementedException();
        }
    }
}