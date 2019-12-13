using System;
using System.ComponentModel.DataAnnotations;

namespace Calendar4e.Models
{
    public class Complaint
    {
        [Key]
        public Int64 id { get; set; }

        public String title { get; set; }

        public String description { get; set; }
        public String date { get; set; }
        public String email { get; set; }
    }
}