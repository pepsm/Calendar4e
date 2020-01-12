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
        public int ID { get; set; }
        public virtual Student Student { get; set; }
        public String Description { get; set; }

        [DataType(DataType.Date)]
        public String Date { get; set; }

        public String Email { get; set; }
        public virtual Student DirectedToUser { get; set; }

    }
}