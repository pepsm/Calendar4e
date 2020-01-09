using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calendar4e.Models
{
    public class Complaint
    {
        [Key]
        public Int64 ID { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Date { get; set; }
        public String Email { get; set; }

    }
}