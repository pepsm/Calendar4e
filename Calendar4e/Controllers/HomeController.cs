﻿using Calendar4e.Data;
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
        private TaskContext db = new TaskContext();
        public ActionResult Login()
        {
            return View();
        }

        // POST: Home/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username,Password")] Student @student)
        {
            if (ModelState.IsValid)
            {
                // this is login, but without registration

                @student.ThemeColor = "red";
                @student.EnrollmentDate = DateTime.Now.ToString("yyyy-MM-dd");

                using (TaskContext db = new TaskContext())
                {
                    var obj = db.Students.Where(s => s.Username.Equals(@student.Username) &&
                    s.Password.Equals(student.Password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserID"] = obj.StudentID.ToString();
                        Session["Username"] = obj.Username.ToString();
                        Session["Student"] = obj;
                        return RedirectToAction("Index", "Task");

                    }
                }
            }

            @ViewBag.Error = "Invalid username or password!";
            return View("Login");
        }
        public ActionResult Register()
        {
                return View();
        }

        // POST: Home/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Username,Password")] Student @student)
        {
            if (ModelState.IsValid)
            {
                using (TaskContext db = new TaskContext())
                {
                    if (this.GetStudentByName(student.Username) == null) 
                    {
                        Student s = new Student
                        {
                            Username = student.Username,
                            Password = student.Password,
                            EnrollmentDate = DateTime.Now.ToString("yyyy-MM-ddThh:mm tt"),
                            ThemeColor = "purple",
                            IsActive = true
                        };


                        db.Students.Add(s);
                        db.SaveChanges();
                        return View("Login");
                    }
                    else
                    {
                        @ViewBag.Error = "User in use. Try with another one!";
                        return View("Register");
                    }
                    
                }

            }
            return View();
        }


            private Student GetStudentByName(string name)
        {
            foreach (var s in db.Students.ToList())
            {
                if (s.Username == name) return s;
            }
            return null;
        }

    }
}