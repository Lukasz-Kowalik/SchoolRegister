﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SchoolRegister.BAL.Entities;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Threading.Tasks;

namespace SchoolRegister.Web.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : BaseController<TeacherController>
    {
        private readonly ITeacherService _teacherService;
        private readonly UserManager<User> _userManager;
        private readonly IStudentService _studentService;

        public TeacherController(ITeacherService teacherService, UserManager<User> userManager, IStudentService studentService,
            IStringLocalizer<TeacherController> localizer, ILoggerFactory loggerFactory
        ) : base(localizer, loggerFactory)
        {
            _teacherService = teacherService;
            _userManager = userManager;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
          
            if (_userManager.IsInRoleAsync(user, "Teacher").Result)
            {
                return View();
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(EmailMessageDto email)
        {
            try
            {
                var result = _teacherService.SendEmailToParent(email);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Teacher");
                }
            }
            catch (Exception e)
            {
                if (e is ArgumentNullException || e is ArgumentException)
                {
                    ViewBag.Info = e.Message;
                    return View();
                }

                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> IssueFinalGrade()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View("Error");
            }
            var isTeacher = await _userManager.IsInRoleAsync(user, "Teacher");
            return isTeacher ? View() : View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IssueFinalGrade(StudentVm student)
        {
            var studentEntity = _studentService.GetStudent(s => s.Id == student.Id);
            return View(studentEntity);
        }
    }
}