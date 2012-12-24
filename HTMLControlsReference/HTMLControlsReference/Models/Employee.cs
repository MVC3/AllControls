using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HTMLControlsReference.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string Address {get; set;}
        public DateTime? DateOfBirth { get; set; }
        public DateTime? HiredDate { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public virtual JobTitle JobTitle { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
        public virtual ICollection<WorkingDay> WorkingDays { get; set; }
        public virtual Department Department { get; set; }
        public virtual City City { get; set; }
        public virtual State State { get; set; }
        
    }
}