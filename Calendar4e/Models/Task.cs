﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calendar4e.Models
{
    public class Task
    {
        
        [Key]
        public Int64 TaskID { get; set; }

        public String subject { get; set; }

        public String description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-ddThh\\:mm tt}", ApplyFormatInEditMode = true)]
        public String start { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-ddThh\\:mm tt}", ApplyFormatInEditMode = true)]

        public String end { get; set; }
        
        public bool allDay { get; set; } = false;

        public String color { get; set; } = "rgb(128, 128, 128)";
        public virtual Student Student { get; set; }

    }
}