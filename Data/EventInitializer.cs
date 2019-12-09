using Calandar4eApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calandar4eApp.Data
{
    public class EventInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EventContext>
    {
        protected override void Seed(EventContext context)
        {
            var students = new List<Student>
            {
                new Student{Name="Alonso",enrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{Name="Anand",enrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{Name="Barzdukas",enrollmentDate=DateTime.Parse("2002-09-01")}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var events = new List<Event>
            {
                new Event{Subject="subject2",StudentID=2, Description="description", startDate=DateTime.Parse("2019-12-07"), endDate=DateTime.Parse("2019-12-07"), themeColor="blue"},
                new Event{Subject="subject3",StudentID=2,Description="description", startDate=DateTime.Parse("2019-12-08"), endDate=DateTime.Parse("2019-12-08"), themeColor="green"},
                new Event{Subject="subject4",StudentID=3, Description="description", startDate=DateTime.Parse("2019-12-12"), endDate=DateTime.Parse("2019-12-12"), themeColor="red"},
                new Event{Subject="subject5",StudentID=3, Description="description", startDate=DateTime.Parse("2019-12-01"), endDate=DateTime.Parse("2019-12-01"), themeColor="red"}
            };
            events.ForEach(s => context.Events.Add(s));
            context.SaveChanges();


        }
    }
}