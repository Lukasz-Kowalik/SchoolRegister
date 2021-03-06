﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SchoolRegister.BAL.Entities;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Web.Controllers
{
    [Authorize]
    public class GradeController : BaseController<GradeController>
    {
        private readonly IGradeService _gradeService;
        private readonly UserManager<User> _userManager;
        private readonly IParentService _parentService;

        public GradeController(UserManager<User> userManager, IGradeService gradeService, IParentService parentService,
            IStringLocalizer<GradeController> localizer, ILoggerFactory loggerFactory
        ) : base(localizer, loggerFactory)
        {
            _gradeService = gradeService;
            _parentService = parentService;
            _userManager = userManager;
        }

        [Authorize(Roles = "Parent,Student,Teacher")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var isParent = await _userManager.IsInRoleAsync(user, "Parent");
            var isStudent = await _userManager.IsInRoleAsync(user, "Student");
            var isTeacher = await _userManager.IsInRoleAsync(user, "Teacher");
            if (isStudent)
            {
                return View(_gradeService.GetGrades(g => g.StudentId == user.Id));
            }
            else if (isParent)
            {
                var students = _parentService.GetParent(s => s.Id == user.Id).Students;
                var grades = _gradeService.GetGrades(
                    g => students.Any(
                        s => s.Id == g.StudentId
                        )
                    );

                return View(grades);
            }
            else if (isTeacher)
            {
                return RedirectToAction("AddGrade");
            }
            else
            {
                return View("Error");
            }
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public IActionResult AddGrade()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddGrade(GradeDto grade)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                _gradeService.AddGrade(grade);
                ViewBag.Success = _localizer["Grade added"];
                return View();
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
    }
}