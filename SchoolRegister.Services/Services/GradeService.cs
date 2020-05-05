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
        private readonly ISubjectService _subjectService;

        public GradeService(ApplicationDbContext dbContext, IStudentService studentService, ISubjectService subjectService) : base(dbContext)
        {
            _studentService = studentService;
            _subjectService = subjectService;
        }

        public IEnumerable<GradeVm> GetGrades(Expression<Func<Grade, bool>> expression)
        {
            var gradesEntities = _dbContext.Grade
                .Include(g => g.Subject)
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
            var gradeEntity = _dbContext.Grade.SingleOrDefault(expression);
            var grade = Mapper.Map<GradeVm>(gradeEntity);
            return grade;
        }

        public void AddGrade(GradeDto grade)
        {
            var subject = _subjectService.GetSubject(s => s.Id == grade.SubjectId);
            if (subject == null)
            {
                throw new ArgumentException("Subject doesn't exist");
            }

            var student = _studentService.GetStudent(s => s.Id == grade.StudentId);
            if (student == null)
            {
                throw new ArgumentException("Student doesn't exist");
            }

            var gradeEntity = Mapper.Map<Grade>(grade);
            _dbContext.Grade.Add(gradeEntity);
            _dbContext.SaveChanges();
        }
    }
}