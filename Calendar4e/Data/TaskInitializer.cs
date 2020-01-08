﻿using System;
using System.Text;
using Calendar4e.Models;
using System.Collections.Generic;
using System.Linq;

using Calendar4e.Controllers;

namespace Calendar4e.Data
{
        public class TaskInitializer : System.Data.Entity.DropCreateDatabaseAlways<TaskContext>
        {
            protected override void Seed(TaskContext context)
            {

                var students = new List<Student>
                {
                    new Student{Username="username",Password = "password",EnrollmentDate=DateTime.Parse("2020-01-01 01:50 PM").ToString("yyyy-MM-ddThh:mm tt"), ThemeColor = "rgb(222, 71, 29)", IsActive=true}
                };

                students.ForEach(s => context.Students.Add(s));
                context.SaveChanges();

                var tasks = new List<Task>
                {
                    new Task{subject="subject1",Student = students.Single(s => s.Username == "username"), description="description", start=DateTime.Parse("2020-01-07").ToString("yyyy-MM-dd"), end=DateTime.Parse("2020-01-08").ToString("yyyy-MM-dd"), allDay = true},
                    new Task{subject="subject2",Student = students.Single(s => s.Username == "username"), description="description", start=DateTime.Parse("2020-01-09").ToString("yyyy-MM-dd"), end=DateTime.Parse("2020-01-10").ToString("yyyy-MM-dd"), allDay = true},
                    new Task{subject="subject3",Student = students.Single(s => s.Username == "username"),description="description", start=DateTime.Parse("2020-01-11").ToString("yyyy-MM-dd"), end=DateTime.Parse("2020-01-12").ToString("yyyy-MM-dd"), allDay = true},
                };

                tasks.ForEach(t => context.Tasks.Add(t));
                context.SaveChanges();

                var complaints = new List<Complaint>
                {
                    new Complaint { Title = "complaint1", Description = "description1", Date = DateTime.Parse("2020-01-08 05:50 PM").ToString("yyyy-MM-ddTHH:mm"), Email = "example@gmail.com" }
                };
                complaints.ForEach(c => context.Complaints.Add(c));
                context.SaveChanges();
            
            }
        }
}