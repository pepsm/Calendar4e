using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calandar4eApp.Models
{
    public class Event
    {
        public int EventID { get; set; }

        public int StudentID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }
        public string themeColor { get; set; }

        public virtual Student Student { get; set; }
    }
}