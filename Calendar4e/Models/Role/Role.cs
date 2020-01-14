using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calendar4e.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public string RoleName { get; set; }
    }
}