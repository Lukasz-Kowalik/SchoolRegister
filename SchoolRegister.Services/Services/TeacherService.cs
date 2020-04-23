using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SchoolRegister.BAL.Entities;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;

namespace SchoolRegister.Services.Services
{
    public class TeacherService : BaseService, ITeacherService
    {
        private readonly SmtpClient _smtpClient;
        private readonly UserManager<User> _userManager;
        private readonly IGradeService _gradeService;

        public TeacherService(ApplicationDbContext dbContext, SmtpClient smtpClient, UserManager<User> userManager, IGradeService gradeService) : base(dbContext)
        {
            _smtpClient = smtpClient;
            _userManager = userManager;
            _gradeService = gradeService;
        }

        public bool SendEmailToParent(EmailMessageDto email)
        {
            try
            {
                if (email == null)
                {
                    throw new ArgumentNullException("email is null");
                }

                var teacher = _dbContext.Users.OfType<Teacher>()
                    .FirstOrDefault(x => x.Id == email.TeacherId);

                var student = _dbContext.Users.OfType<Student>()
                    .FirstOrDefault(s => s.Id == email.StudentId);

                if (teacher == null || student == null)
                {
                    throw new ArgumentNullException("user don't exist");
                }

                if (!_userManager.IsInRoleAsync(teacher, "Teacher").Result)
                {
                    throw new ArgumentNullException("user is not a teacher");
                }

                if (!_userManager.IsInRoleAsync(student, "Student").Result)
                {
                    throw new ArgumentNullException("user is not a student");
                }

                var mailMessage = new MailMessage(to: student.Parent.Email,
                    subject: email.MessageTitle,
                    body: email.Message,
                    from: teacher.Email);
                _smtpClient.Send(mailMessage);

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filter)
        {
            var teacherEntity = _dbContext.Users.OfType<Teacher>().AsQueryable();
            if (filter != null)
            {
                teacherEntity = teacherEntity.Where(filter);
            }

            var teacherVm = Mapper.Map<TeacherVm>(teacherEntity);
            return teacherVm;
        }

        public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>> filter = null)
        {
            var teachers = _dbContext.Users.OfType<Teacher>().AsQueryable();
            if (filter != null)
            {
                teachers = teachers.Where(filter);
            }

            var teachersVm = Mapper.Map<IEnumerable<TeacherVm>>(teachers);
            return teachersVm;
        }
        protected override void Dispose(bool disposing)
        {
            _smtpClient.Dispose();
            base.Dispose(disposing);
        }
    }
}