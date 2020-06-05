using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.BAL.Entities;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.Web.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolRegister.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IStudentService _studentService;

        public StudentController(UserManager<User> userManager, IStudentService studentService)
        {
            _userManager = userManager;
            _studentService = studentService;
        }

        // GET: StudentController
        [Authorize(Roles = "Teacher, Admin")]
        public async Task<IActionResult> Index(string studentsFilterValue = null)
        {
            Expression<Func<Student, bool>> filterPredicate = null;
            if (!string.IsNullOrWhiteSpace(studentsFilterValue))
            {
                filterPredicate = x => x.LastName.Contains(studentsFilterValue);
            }

            bool isAjax = HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";

            var user = await _userManager.GetUserAsync(User);
            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (isAdmin)
            {
                var studentsVm = _studentService.GetStudents(filterPredicate);
                if (isAjax)
                {
                    return PartialView("_StudentsTableDataPartial", studentsVm);
                }
                return View(studentsVm);
            }
            var isTeacher = await _userManager.IsInRoleAsync(user, "Teacher");

            if (isTeacher)
            {
                var teacher = _userManager.GetUserAsync(User).Result as Teacher;

                Expression<Func<Student, bool>> filterStudents =
                    s => s.Group.SubjectGroups.Any(sg => sg.Subject.TeacherId == teacher.Id);

                var finalExpression = filterPredicate != null
                    ? Expression.Lambda<Func<Student, bool>>(
                        Expression.AndAlso(filterPredicate.Body,
                            new ExpressionParameterReplacer(filterStudents.Parameters, filterPredicate.Parameters)
                                .Visit(filterStudents.Body)), filterPredicate.Parameters)
                    : filterStudents;

                var studentsVm = _studentService.GetStudentsForTeacher(finalExpression);
                if (isAjax)
                {
                    return PartialView("_StudentsTableDataPartial", studentsVm);
                }
                return View(studentsVm);
            }
            else
            {
                return View("Error");
            }
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}