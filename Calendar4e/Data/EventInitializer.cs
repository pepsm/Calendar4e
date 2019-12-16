﻿using System;
using System.Linq;
using System.Web;
using Calendar4e.Models;
using System.Collections.Generic;

namespace Calendar4e.Data
{
        public class EventInitializer : System.Data.Entity.DropCreateDatabaseAlways<EventContext>
        {
            protected override void Seed(EventContext context)
            {
                var students = new List<Student>
            {
                new Student{name="Alonso",enrollmentDate=DateTime.Parse("2002-09-01").ToString(), themeColor = "red", isActive=true},
                new Student{name="Gosho",enrollmentDate=DateTime.Parse("2003-09-01").ToString(), themeColor = "blue", isActive=true},
                new Student{name="Tosho",enrollmentDate=DateTime.Parse("2002-09-01").ToString(), themeColor = "green", isActive=true}
            };
                students.ForEach(s => context.Students.Add(s));
                context.SaveChanges();

                var events = new List<Event>
            {
                new Event{subject="subject1", StudentId = 1, description="description", start=DateTime.Parse("2019-12-09 05:50 PM").ToString("yyyy-MM-ddTHH:mm"), end=DateTime.Parse("2019-12-09 06:50 PM").ToString("yyyy-MM-ddTHH:mm")},
                new Event{subject="subject2", StudentId = 1, description="description", start=DateTime.Parse("2019-12-08 01:50 PM").ToString("yyyy-MM-ddTHH:mm"), end=DateTime.Parse("2019-12-09 02:50 PM").ToString("yyyy-MM-ddTHH:mm")},
                new Event{subject="subject3", StudentId = 1,description="description", start=DateTime.Parse("2019-12-07 02:50 PM").ToString("yyyy-MM-ddTHH:mm"), end=DateTime.Parse("2019-12-09 03:50 PM").ToString("yyyy-MM-ddTHH:mm")},

            };
                events.ForEach(e => context.Events.Add(e));
                context.SaveChanges();

            }
        }

}