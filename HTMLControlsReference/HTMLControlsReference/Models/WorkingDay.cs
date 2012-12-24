using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTMLControlsReference.Models
{
    public class WorkingDay
    {
        public int WorkingDayID { get; set; }
        public string WorkingDays { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}