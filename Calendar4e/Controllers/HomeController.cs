using Calendar4e.Data;
using Calendar4e.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calendar4e.Controllers
{
    public class HomeController : Controller
    {
        private EventContext db = new EventContext();
        public ActionResult Index()
        {
            return View();
        }


        // POST: Home/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "name")] Student @student)
        {
            if (ModelState.IsValid)
            {
                @student.themeColor = "red";
                @student.enrollmentDate = DateTime.Now.ToString("yyyy-MM-dd");

                if (Exists(@student))
                {
                    @ViewBag.Error = "Pick a different name";
                    return View("Index");
                }
                db.Students.Add(@student);
                db.SaveChanges();
                return RedirectToAction("Index", "Events"); 
            }
            return View("Index");
        }


        private bool Exists(Student student)
        {
            List<Student> list = db.Students.ToList();
            foreach (var s in list)
            {
                if (s.name == student.name) return true;
            }
            return false;
        }
    }
}