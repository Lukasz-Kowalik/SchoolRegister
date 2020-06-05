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
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public StudentVm GetStudent(Expression<Func<Student, bool>> expression)
        {
            var studentEntity = _dbContext.Users.OfType<Student>().Include(x => x.Grades)
                .Include(s => s.Grades)
                .Include(s => s.Group)
                .Include(s => s.Parent)
                .AsQueryable()
                .SingleOrDefault(expression);
            var studentVm = Mapper.Map<StudentVm>(studentEntity);
            return studentVm;
        }

        public IEnumerable<StudentVm> GetStudentsForTeacher(Expression<Func<Student, bool>> expression = null)
        {
            var studentsEntity = _dbContext.Users.OfType<Student>()
                    .Include(s => s.Grades)
                    .ThenInclude(g => g.Subject)
                    .Include(s => s.Group)
                    .ThenInclude(g=>g.SubjectGroups)
                    .ThenInclude(sg => sg.Subject)
                    .ThenInclude(s=>s.Teacher)
                    .Include(s => s.Parent)
                .AsQueryable();
            if (expression != null)
            {
                studentsEntity = studentsEntity.Where(expression);
            }
            var studentVm = Mapper.Map<IEnumerable<StudentVm>>(studentsEntity);
            return studentVm;
        }
        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> expression = null)
        {
            var studentsEntity = _dbContext.Users.OfType<Student>()
                .Include(s => s.Grades)
                .ThenInclude(g => g.Subject)
                .Include(s => s.Group)
                .Include(s => s.Parent)
                .AsQueryable();
            if (expression != null)
            {
                studentsEntity = studentsEntity.Where(expression);
            }
            var studentVm = Mapper.Map<IEnumerable<StudentVm>>(studentsEntity);
            return studentVm;
        }
        public void Update(StudentVm studentVm)
        {
            if (studentVm == null)
            {
                throw new ArgumentNullException("Value is a null");
            }

            var studentEntity = Mapper.Map<Student>(studentVm);
            _dbContext.Users.Update(studentEntity);
            _dbContext.SaveChanges();
        }

        public void RemoveStudentFromGroup(int? studentId)
        {
            if (studentId == null)
            {
                throw new ArgumentNullException("Value is a null");
            }

            var student = _dbContext.Users.OfType<Student>().SingleOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                student.GroupId = null;
                _dbContext.Users.Update(student);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Student doesn't exists.");
            }
        }

        public void AddStudentToGroup(StudentDto studentDto, int? groupId)
        {
            if (studentDto == null || groupId == null)
            {
                throw new ArgumentNullException("Value is a null");
            }

            var studentEntity = _dbContext.Users.OfType<Student>()
                .SingleOrDefault(s => s.Id == studentDto.Id);

            if (studentEntity != null)
            {
                var isGroupExists = _dbContext.Groups.Any(g => g.Id == groupId);

                if (isGroupExists)
                {
                    studentEntity.GroupId = groupId;
                    _dbContext.Users.Update(studentEntity);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new AggregateException();
                }
            }
            else
            {
                throw new ArgumentException("Student doesn't exists.");
            }
        }
    }
}