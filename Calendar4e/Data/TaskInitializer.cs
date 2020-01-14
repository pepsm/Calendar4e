using System;
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
                    new Student{Username="username",Password = Hashing.HashPassword("password"),EnrollmentDate=DateTime.Parse("2020-01-01 01:50 PM").ToString("yyyy-MM-ddThh:mm tt"), ThemeColor = "rgb(222, 71, 29)", IsActive=true},
                    new Student{Username="admin",Password = Hashing.HashPassword("admin"),EnrollmentDate=DateTime.Parse("2020-01-14 08:50 PM").ToString("yyyy-MM-ddThh:mm tt"), ThemeColor = "rgb(200, 71, 29)", IsActive=true}
                };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

          
            var tasks = new List<Task>
                {
                    new Task{subject="Clean the room",Student = students.Single(s => s.Username == "username"), description="Koko should clean his room!", start=DateTime.Parse("2020-01-07 12:00").ToString("yyyy-MM-ddThh:mm"), end=DateTime.Parse("2020-01-08 13:00").ToString("yyyy-MM-ddThh:mm"), allDay = true},
                    new Task{subject="Cook",Student = students.Single(s => s.Username == "username"), description="Gosho will cook tonight", start=DateTime.Parse("2020-01-09").ToString("yyyy-MM-dd"), end=DateTime.Parse("2020-01-10").ToString("yyyy-MM-dd"), allDay = true},
                    new Task{subject="Wash the dishes",Student = students.Single(s => s.Username == "username"),description="description", start=DateTime.Parse("2020-01-22").ToString("yyyy-MM-dd"), end=DateTime.Parse("2020-01-23").ToString("yyyy-MM-dd"), allDay = true},
                };
            tasks.ForEach(t => context.Tasks.Add(t));
            context.SaveChanges();


            var complaints = new List<Complaint>
                {
                    new Complaint { Title = "complaint1", Description = "description1", Date = DateTime.Parse("2020-01-08 05:50 PM").ToString("yyyy-MM-ddTHH:mm"), Student = students.Single(s => s.Username == "username"), DirectedToUser = "user1"}
                };
            complaints.ForEach(c => context.Complaints.Add(c));
            context.SaveChanges();


            var rules = new List<HouseRule>
                {
                    new HouseRule { Description = "Do your chores"},
                    new HouseRule { Description = "You are not allowed to bring pets"},
                    new HouseRule { Description = "Be in bed before 21:00"},
                    new HouseRule { Description = "You are not allowed to have fun"},
                };
            rules.ForEach(r => context.HouseRules.Add(r));
            context.SaveChanges();

            var roles = new List<Role>()
            {
                new Role{ RoleName = RoleType.Admin.ToString()},
                new Role{ RoleName = RoleType.User.ToString()}
            };
            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            context.SaveChanges();

            var userRoles = new List<UserRoleMappingModel>()
            {
                new UserRoleMappingModel {Student = students.Single(s => s.Username == "username"), Role = roles.Single(r => r.RoleName == RoleType.User.ToString())},
                new UserRoleMappingModel {Student = students.Single(s => s.Username == "admin"), Role = roles.Single(r => r.RoleName == RoleType.Admin.ToString())}
            };
            userRoles.ForEach(u => context.UserRoles.Add(u));
            context.SaveChanges();
        }
    }
}