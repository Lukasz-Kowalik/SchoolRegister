using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SchoolRegister.BAL.Entities;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using System;
using System.Linq;

namespace SchoolRegister.Web.Controllers
{
    [Authorize(Roles = "Teacher,Admin")]
    public class SubjectController : BaseController<SubjectController>
    {
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        private readonly UserManager<User> _userManager;

        public SubjectController(ISubjectService subjectService, ITeacherService teacherService, UserManager<User> userManager,
            IStringLocalizer<SubjectController> localizer, ILoggerFactory loggerFactory
            ) : base(localizer, loggerFactory)
        {
            _subjectService = subjectService;
            _teacherService = teacherService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                return View(_subjectService.GetSubjects());
            }
            else if (_userManager.IsInRoleAsync(user, "Teacher").Result)
            {
                var teacher = _userManager.GetUserAsync(User).Result as Teacher;
                return View(_subjectService.GetSubjects(x => x.TeacherId == user.Id));
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult AddOrEditSubject(int? id = null)
        {
            var teachersVm = _teacherService.GetTeachers();
            ViewBag.TeachersSelectList = new SelectList(teachersVm.Select(t => new
            {
                Text = $"{t.FirstName} {t.LastName}",
                Value = t.Id
            })
                , "Value", "Text");

            if (id.HasValue)
            {
                var subjectVm = _subjectService.GetSubject(subject => subject.Id == id);
                ViewBag.ActionType = _localizer["Edit"];
                return View(Mapper.Map<AddOrUpdateSubjectDto>(subjectVm));
            }
            ViewBag.ActionType = _localizer["Add"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEditSubject(AddOrUpdateSubjectDto addOrUpdateSubjectDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _subjectService.AddOrUpdate(addOrUpdateSubjectDto);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}