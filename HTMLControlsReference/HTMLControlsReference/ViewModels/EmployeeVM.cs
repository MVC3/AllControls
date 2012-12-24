using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTMLControlsReference.Models;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace HTMLControlsReference.ViewModels
{
    public class EmployeeVM
    {
        public int EmployeeID { get; set; }

        string RegexName = "[a-zA-Z0-9.]*";
        [Display(Name = "First Name")]
        [RegularExpression("[a-zA-Z0-9.]*", ErrorMessage = "Please enter only apphabets or numbers")]
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression("[a-zA-Z0-9.]*", ErrorMessage = "Please enter only apphabets or numbers")]
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [RegularExpression("[a-zA-Z0-9./-]*", ErrorMessage = "Address accepts alphanumerics and special characters like ./ and - only")]
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }

        [RegularExpression("[a-zA-Z0-9./-]*", ErrorMessage = "Address accepts alphanumerics and special characters like ./ and - only")]
        public string Addressline { get; set; }

        [Display(Name = "Date of Birth")]
        // string RegExDate = (@"^((0[1-9])|(1[0-2])\/(0[1-9])|(1[0-2]))\/(\d{4})$";
       // [RegularExpression(@"^((0[1-9])|(1[0-2]))\/(\d{4})$", ErrorMessage = "Please enter date in mm/yyyy format")]
        [Required(ErrorMessage = "Please enter date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Hired Date")]
        //[RegularExpression(@"^((0[1-9])|(1[0-2]))\/(\d{4})$", ErrorMessage = "Please enter date in mm/dd/yyyy format")]
        [Required(ErrorMessage = "Please enter date of hire")]
        public DateTime? HiredDate { get; set; }

        [RegularExpression(@"\d{5}", ErrorMessage = "Please enter proper Zipcode XXXXX")]
        [Required(ErrorMessage = "Please enter zipCode")]
        public int Zipcode { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Please enter proper Email Address steack@sauce.com")]
        [Required(ErrorMessage = "Please enter email address")]
        public string Email { get; set; }

        //@"\d{3}\-\d{3}\-\d{4}"
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter proper Phone number xxxxxxxxxx")]
        [Required(ErrorMessage = "Please enter phone number")]
        public string Phone { get; set; }

        [Display(Name="User Name")]
        [RegularExpression(@"[a-zA-Z0-9.]*", ErrorMessage = "Username accepts alphanumerics only")]
        [Required(ErrorMessage = "Please enter userName")]
        public string UserName { get; set; }

        [RegularExpression(@"[a-zA-Z0-9@._]*", ErrorMessage = "password accepts alphanumerics and some special characters like @ . and _")]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [RegularExpression(@"[a-zA-Z0-9@._]*", ErrorMessage = "password accepts alphanumerics and some special characters like @ . and _")]
        [Required(ErrorMessage = "Please enter the password again for confirmation")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select gender")]
        public Globals.Gender Gender { get; set; }

        [Display(Name = "Job Title")]
        //, Required(ErrorMessage = "Please Select the Job Title")]
        public IEnumerable<SelectListItem> AllJobs { get; set; }
        public int SelectedJobID { get; set; }

        [Display(Name = "Working Shifts")]
        //, Required(ErrorMessage = "Please Select the Shifts")]
        public List<CheckBoxViewModel> Shifts { get; set; }

        [Display(Name = "Working Days")]
        //, Required(ErrorMessage = "Please Select the Working Days")]
        public IEnumerable<SelectListItem> AllWorkingDays { get; set; }
        public List<int> SelectedWorkingDayIDs { get; set; }

        [Display(Name = "Department")]
        //, Required(ErrorMessage = "Please Select the Department")]
        public IEnumerable<SelectListItem> AllDepartment { get; set; }
        public int SelectedDeptID { get; set; }

        [Display(Name = "City")]
        public IEnumerable<SelectListItem> AllCity { get; set; }
        public int SelectedCityID { get; set; }

        [Display(Name = "State")]
        //, Required(ErrorMessage="Please Select the State")]
        public IEnumerable<SelectListItem> AllState { get; set; }
        public int SelectedStateID { get; set; }
    }
}