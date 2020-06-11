using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.Vms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolRegister.Web.Controllers
{
    [Authorize]
    public class ChatController : BaseController<ChatController>
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;

        public ChatController(IStringLocalizer<ChatController> localizer, ILoggerFactory loggerFactory, IGroupService groupService, IStudentService studentService)
            : base(localizer, loggerFactory)
        {
            _groupService = groupService;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            var students = _studentService.GetStudents().ToList();
            students.Add(new StudentVm()
            {
                UserName = "All"
            });
            var chatGroups = _groupService.GetGroups();
            var chatGroupListItems = Mapper.Map<IEnumerable<SelectListItem>>(chatGroups);
            var studentListItems = Mapper.Map<IEnumerable<SelectListItem>>(students);
            return View(new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(studentListItems, chatGroupListItems));
        }
    }
}