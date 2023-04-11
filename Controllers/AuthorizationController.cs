using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using StudProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;


namespace StudProject.Controllers
{
    public class AuthorizationController : Controller
    {
        private StudProdContext db;
        public AuthorizationController(StudProdContext context)
        {
            db = context;
        }
        [HttpPost]
        
        public async Task<JsonResult> Authorization(string Login, string Password)
        {
            bool find = false;
            PersonalInformationOfSt student = await db.PersonalInformationOfSts.Include(r => r.PositionNavigator).FirstOrDefaultAsync(u => u.Login == Login && u.Password == Password);
            if(student != null)
            {
                find = true;
                await AuthenticateToStudent(student);
               
            }
            PersonalInformationOfTeacher teacher = await db.PersonalInformationOfTeachers.Include(r => r.PositionNavigation).FirstOrDefaultAsync(u => u.Login == Login && u.Password == Password);
            if(teacher != null) {

                find = true;
                await AuthenticateToTeacher(teacher);
            }            
            return Json(find);
        }
         private async Task AuthenticateToStudent(PersonalInformationOfSt student)
        {            
            var claims = new List<Claim>
            {              
                new Claim(ClaimsIdentity.DefaultNameClaimType, student.Login),  
                new Claim(ClaimsIdentity.DefaultRoleClaimType,  student.PositionNavigator?.Position1)
            };           
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));            
        }

        private async Task AuthenticateToTeacher(PersonalInformationOfTeacher teacher)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, teacher.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, teacher.PositionNavigation?.Position1)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("MainPage", "Home");
        }
    }
}
