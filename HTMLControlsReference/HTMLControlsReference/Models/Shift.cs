using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HTMLControlsReference.Models
{
    public class Shift
    {
        [Key]
        public int ShiftID { get; set; }
        public string ShiftType { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}