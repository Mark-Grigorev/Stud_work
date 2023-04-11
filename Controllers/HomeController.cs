using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult MainPage()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("ClassRoomPage", "ClassRoom");
            }
            return View();
        }
        public IActionResult AboutUsPage()
        {
            return PartialView();
        }
        public IActionResult EducationPage()
        {
            return PartialView();
        }
        public IActionResult AuthorizationPage()
        {
            return PartialView();
        }
        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
