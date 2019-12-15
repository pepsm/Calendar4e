using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calendar4e.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string themeColor { get; set; }
        public string enrollmentDate { get; set; }
        public virtual ICollection<Task> tasks { get; set; }
        public bool isActive { get; set; }
    }
}