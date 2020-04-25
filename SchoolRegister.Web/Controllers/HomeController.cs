using Microsoft.AspNetCore.Mvc;
using SchoolRegister.DAL.EF;
using SchoolRegister.Services.Interfaces;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using SchoolRegister.BAL.Entities;
using SchoolRegister.ViewModels.Vms;

namespace SchoolRegister.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}