using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudProject.Controllers
{
    public class ClassRoomController : Controller
    {
        private StudProdContext db;
        public ClassRoomController(StudProdContext context)
        {
            db = context;
        }
        
        
        public IActionResult ClassRoomPage()
        {
            ViewData["Position"] = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return View();
        }
        public IActionResult TestsPage()
        {
            var tests = db.Tests.Include(p => p.TeacherNavigation).Include(u => u.SubjectNavigation).ToList();
            return View(tests);
        }
        
        public EmptyResult CreateQuest(string Name, string Correct, string F, string S, string T, string Fo)
        {           
            PersonalInformationOfTeacher teacherPers =  db.PersonalInformationOfTeachers.FirstOrDefault(u => u.Login == User.Identity.Name);
            Teacher teacher =  db.Teachers.FirstOrDefault(p => p.Id == teacherPers.Teacher);
            int iden = teacher.Id;
            TheSubject subject =  db.TheSubjects.Where(s => s.TeacherID == iden).FirstOrDefault();
            Test newTest = new Test();
            newTest.NameOfQuestion = Name;
            newTest.Subject = subject.Id;
            newTest.Teacher = teacher.Id;
            newTest.CorrectAnswer = Correct;
            newTest.FQuest = F;
            newTest.SQuest = S;
            newTest.TQuest = T;
            newTest.FoQuest = Fo;
            newTest.GetTest = false;
            db.Tests.Add(newTest);
            db.SaveChangesAsync();
            return new EmptyResult();
        }
        public IActionResult GetOnceTest(int? id)
        {
            Test test = db.Tests.Where(p => p.Id == id).FirstOrDefault();
            test.GetTest = true;
            db.SaveChanges();
            return RedirectToAction(nameof(TestsPage));
            

        }
        public IActionResult RemoveGetOnceTest(int? id)
        {
            Test test = db.Tests.Where(p => p.Id == id).FirstOrDefault();
            test.GetTest = false;
            db.SaveChanges();
            return RedirectToAction(nameof(TestsPage));
            
        }
        public IActionResult GetAllTetst()
        {
            var tests = db.Tests.Include(p => p.TeacherNavigation).Include(u => u.SubjectNavigation).ToList();
            foreach(var item in tests)
            {
                item.GetTest = true;
                db.SaveChanges();
            }
            return RedirectToAction(nameof(TestsPage));
        }
        public IActionResult RemoveallTetsts()
        {
            var tests = db.Tests.Include(p => p.TeacherNavigation).Include(u => u.SubjectNavigation).ToList();
            foreach (var item in tests)
            {
                item.GetTest = false;
                db.SaveChanges();
            }
            return RedirectToAction(nameof(TestsPage));
        }
        public IActionResult SelectTestPages()
        {
            var subjects = db.TheSubjects.ToList();
            return View(subjects);
        }
        public IActionResult QuestPage(int? id)
        {
            var questions = db.Tests.Where(p => p.Subject == id).ToList();
            return View(questions);
        }
        public JsonResult CheckAns(int id, string ans) 
        {
            bool correct = false;
            Test quest = db.Tests.Where(p => p.Id == id).FirstOrDefault();
            if(quest.CorrectAnswer == ans)
            {
                correct = true;
            }
            return Json(correct);
        }
    }
}
