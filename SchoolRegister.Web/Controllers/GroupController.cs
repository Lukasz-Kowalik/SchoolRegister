using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.BAL.Entities;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using System;
using System.Threading.Tasks;

namespace SchoolRegister.Web.Controllers
{
    public class GroupController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;

        public GroupController(UserManager<User> userManager, IGroupService groupService, IStudentService studentService)
        {
            _userManager = userManager;
            _groupService = groupService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View("Error");
            }
            var isTeacher = await _userManager.IsInRoleAsync(user, "Teacher");
            if (!isTeacher)
            {
                return View("Error");
            }

            var groups = _groupService.GetGroups();
            return View(groups);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (User.Identity.Name == null)
            {
                return View("Error");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GroupDto group)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                _groupService.Add(group);
                return RedirectToAction("Index");
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

        public IActionResult Delete(int id)
        {
            if (User.Identity.Name == null)
            {
                return View("Error");
            }
            _groupService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            if (User.Identity.Name == null)
            {
                return View("Error");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GroupDto group)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                _groupService.Update(group);
                return RedirectToAction("Index");
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

        public IActionResult Details(int? id)
        {
            if (User.Identity.Name == null)
            {
                return View("Error");
            }

            if (id == null)
            {
                return NotFound();
            }
            TempData.Remove("detailsId");
            TempData.Add("detailsId", id);
            var groupVm = _groupService.GetGroup(g => g.Id == id);

            return View(groupVm);
        }

        [HttpGet]
        public IActionResult AddStudentToGroup(int groupId)
        {
            if (User.Identity.Name == null)
            {
                return View("Error");
            }
            TempData.Remove("groupId");
            TempData.Add("groupId", groupId);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudentToGroup(StudentDto studentDto)
        {
            try
            {
                if (User.Identity.Name == null)
                {
                    return View("Error");
                }

                var groupId = (int) TempData["groupId"];

                _studentService.AddStudentToGroup(studentDto, groupId);

                return RedirectToAction($"Details/{groupId}");
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

        public IActionResult RemoveStudent(int? id)
        {
            if (User.Identity.Name == null)
            {
                return View("Error");
            }
            if (id == null)
            {
                return NotFound();
            }
            int groupId = (int)TempData["detailsId"];

            _studentService.RemoveStudentFromGroup(id);
            return RedirectToAction($"Details/{groupId}");
        }
    }
}