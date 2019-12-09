using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calandar4eApp.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime enrollmentDate { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}