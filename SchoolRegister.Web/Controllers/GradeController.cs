using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.BAL.Entities;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Web.Controllers
{
    public class GradeController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IGradeService _gradeService;
        private readonly UserManager<User> _userManager;
        private readonly IParentService _parentService;
        private readonly ISubjectService _subjectService;

        public GradeController(UserManager<User> userManager, IStudentService studentService, IGradeService gradeService, IParentService parentService, ISubjectService subjectService)
        {
            _studentService = studentService;
            _gradeService = gradeService;
            _parentService = parentService;
            _subjectService = subjectService;
            _userManager = userManager;
        }

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

        [HttpGet]
        public async Task<IActionResult> AddGrade()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGrade(GradeDto grade)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                _gradeService.AddGrade(grade);
                ViewBag.Success = $"Grade added";
                return View();
            }
            catch (ArgumentException e)
            {
                ViewBag.NotFound = e.Message;
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("Error");
            }
        }
    }
}