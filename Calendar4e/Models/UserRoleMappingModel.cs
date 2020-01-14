using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calendar4e.Models
{
    public class UserRoleMappingModel
    {

        [Key]
        public int ID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Role Role { get; set; }
    }
}