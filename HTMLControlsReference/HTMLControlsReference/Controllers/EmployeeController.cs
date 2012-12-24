using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTMLControlsReference.Models;
using HTMLControlsReference.ViewModels;
using HTMLControlsReference.Services.Contracts;


namespace HTMLControlsReference.Controllers
{ 
    public class EmployeeController : Controller
    {
        private IEmpDBContext db;
        private IEmployeeService _empService;
        private IStateService _stateService;
        private ICityService _cityService;
        private IJobService _jobService;
        private IDepartmentService _departmentService;
        private IShiftService _shiftService;
        private IWorkingDayService _workingdayService;
        

        public EmployeeController(IEmpDBContext empDBContext, IEmployeeService empService, ICityService cityService, IStateService stateService, IJobService jobService, IDepartmentService departmentService, IWorkingDayService workingdaysService, IShiftService shiftsService)
        {
            db = empDBContext;
            _empService = empService;
            _stateService = stateService;
            _cityService = cityService;
            _jobService = jobService;
            _departmentService = departmentService;
            _workingdayService = workingdaysService;
            _shiftService = shiftsService;
        }

        public ActionResult Index()
        {

            return View(GetEmployeeVMList());
        }

        private List<EmployeeVM> GetEmployeeVMList()
        {    
            List<EmployeeVM> objEmpVMList = new List<EmployeeVM>();
            EmployeeVM objEmpVM;
            foreach (Employee objEmp in _empService.GetEmployees())
            {
                objEmpVM = new EmployeeVM();
                objEmpVM.EmployeeID = objEmp.EmployeeID;
                objEmpVM.FirstName = objEmp.FirstName;
                objEmpVM.LastName = objEmp.LastName;
                objEmpVM.DateOfBirth = objEmp.DateOfBirth;
                objEmpVM.HiredDate = objEmp.HiredDate;
                objEmpVM.Phone = objEmp.Phone;

                objEmpVM.Email = objEmp.Email;
                if (objEmp.Gender == 1)
                    objEmpVM.Gender = Globals.Gender.Male;
                else if(objEmp.Gender ==2)
                    objEmpVM.Gender = Globals.Gender.Female;

                objEmpVM.UserName = objEmp.UserName;
                objEmpVM.Password = objEmp.Password;
                objEmpVM.Zipcode = objEmp.Zipcode;
                objEmpVM.Address = objEmp.Address;
                objEmpVMList.Add(objEmpVM);

            }            
            return objEmpVMList;
        }
       
        [HttpGet]
        public ActionResult Create()
        {
            EmployeeVM objEmpVM = new EmployeeVM();
            objEmpVM = FillLists(objEmpVM);
            return View(objEmpVM);
        }

        private EmployeeVM FillLists(EmployeeVM objEmpVM)
        {

            int stateid = 0;
            objEmpVM.AllCity = new SelectList(_cityService.GetAllCities(stateid), "CityID", "CityName");
            objEmpVM.AllDepartment = new SelectList(_departmentService.getAllDepartments(), "DepartmentID", "Name");
            objEmpVM.AllJobs = new SelectList(_jobService.getAllJobs(), "JobID", "JobTitleName");
            objEmpVM.AllState = new SelectList(_stateService.GetAllStates(), "StateID", "StateName");
            objEmpVM.AllWorkingDays = new SelectList(_workingdayService.getAllWorkingDays(), "WorkingDayID", "WorkingDays");
            objEmpVM.Shifts = new List<CheckBoxViewModel>();

            foreach (Shift s in _shiftService.getAllShifts())
                objEmpVM.Shifts.Add(new CheckBoxViewModel(s.ShiftID, s.ShiftType));
            return objEmpVM;
        }

        public JsonResult getState(int stateID)
        {
            EmployeeVM objEmpVM = new EmployeeVM();
            objEmpVM.AllCity = new SelectList(_cityService.GetAllCities(stateID), "CityID", "CityName");
            //var cities = objEmpVM.AllCity.Select(c => c.Text);
            return Json(objEmpVM.AllCity , JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                Employee objEmp = new Employee();
                objEmp.EmployeeID = employeeVM.EmployeeID;
                objEmp.FirstName = employeeVM.FirstName;
                objEmp.LastName = employeeVM.LastName;
                objEmp.Address = employeeVM.Address + employeeVM.Addressline;
                objEmp.DateOfBirth = employeeVM.DateOfBirth;
                objEmp.HiredDate = employeeVM.HiredDate;
                objEmp.Email = employeeVM.Email;
                objEmp.Phone = employeeVM.Phone;
                objEmp.Zipcode = employeeVM.Zipcode;
                objEmp.UserName = employeeVM.UserName;
                objEmp.Password = employeeVM.Password;

                objEmp.ConfirmPassword = employeeVM.ConfirmPassword;

                objEmp.State = _stateService.GetState(employeeVM.SelectedStateID);
                objEmp.City = _cityService.GetCity(employeeVM.SelectedCityID);
                objEmp.JobTitle = _jobService.getJob(employeeVM.SelectedJobID);
                objEmp.Department = _departmentService.getDepartment(employeeVM.SelectedDeptID);

                
                objEmp.Gender = Convert.ToInt16(employeeVM.Gender);

                //City city = _cityService.GetCity(employeeVM.SelectedCityID);

                //State state = _stateService.GetState(employeeVM.SelectedStateID);

                //JobTitle Job = db.JobTitles.Where(j => j.JobID == employeeVM.SelectedJobID).SingleOrDefault();

                //Department Dept = db.Departments.Where(d => d.DepartmentID == employeeVM.SelectedDeptID).SingleOrDefault();

                objEmp.WorkingDays = new List<WorkingDay>();
                foreach (int id in employeeVM.SelectedWorkingDayIDs)
                {
                    WorkingDay workingdays = _workingdayService.getSelectedWorkingday(id);
                    objEmp.WorkingDays.Add(workingdays);
                    
                }

                objEmp.Shifts = new List<Shift>();
                foreach (int selectedId in employeeVM.Shifts.Where(s => s.Checked == true).Select( x=>x.ID))
                {
                    Shift shift = _shiftService.getShift(selectedId);
                    objEmp.Shifts.Add(shift);
                }

                //db.Employees.Add(objEmp);
                if (_empService.Create(objEmp) == true)
                    ViewData["Status"] = "Employee " + objEmp.FirstName + "saved successfully";
                else
                    ViewData["Status"] = "Unexpected error occurred while saving employee " + objEmp.FirstName;
                //_empService.Create(objEmp);

                return RedirectToAction("Index");
            }
            else
                employeeVM = FillLists(employeeVM);

            return View(employeeVM);
        }

        //Get ActionMethod
        public ActionResult Delete(int id)
        {
            EmployeeVM objEmpVM = new EmployeeVM();
            Employee objEmp = _empService.GetEmployee(id);
            objEmpVM.EmployeeID = objEmp.EmployeeID;
            objEmpVM.FirstName = objEmp.FirstName;
            objEmpVM.LastName = objEmp.LastName;
            objEmpVM.DateOfBirth = objEmp.DateOfBirth;
            objEmpVM.HiredDate = objEmp.HiredDate;

            if (objEmp.Gender == 1)
                objEmpVM.Gender = Globals.Gender.Male;
            else if (objEmp.Gender == 2)
                objEmpVM.Gender = Globals.Gender.Female;
            
            return View(objEmpVM);
            
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee objEmp = _empService.GetEmployee(id);
            if (_empService.Delete(objEmp) == true)

                if (_empService.Delete(objEmp) == true)
                    ViewData["Status"] = "Employee deleted successfully";
                else
                    ViewData["Status"] = "Unexpected error occurred while deleting the employee ";
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee objEmp = _empService.GetEmployee(id);
            EmployeeVM objEmpVM = new EmployeeVM();
            objEmpVM.EmployeeID = objEmp.EmployeeID;
            objEmpVM.FirstName = objEmp.FirstName;
            objEmpVM.LastName = objEmp.LastName;
            objEmpVM.Address = objEmp.Address;
            objEmpVM.DateOfBirth = objEmp.DateOfBirth;
            objEmpVM.HiredDate = objEmp.HiredDate;
            objEmpVM.Email = objEmp.Email;
            objEmpVM.Phone = objEmp.Phone;
            objEmpVM.Zipcode = objEmp.Zipcode;
            objEmpVM.UserName = objEmp.UserName;
            objEmpVM.Password = objEmp.Password;
            objEmpVM.ConfirmPassword = objEmp.ConfirmPassword;

            if (objEmp.Gender == 1)
                objEmpVM.Gender = Globals.Gender.Male;
            else if (objEmp.Gender == 2)
                objEmpVM.Gender = Globals.Gender.Female;


            objEmpVM = FillListsEdit(objEmpVM);

            objEmpVM.AllCity = new SelectList(_cityService.GetAllCities(objEmp.State.StateID), "CityID", "CityName");
            objEmpVM.Shifts = new List<CheckBoxViewModel>();
            foreach (Shift shift in _shiftService.getAllShifts())
            {
                objEmpVM.Shifts.Add(new CheckBoxViewModel(shift.ShiftID, shift.ShiftType, objEmp.Shifts.Select( s => s.ShiftID).Contains(shift.ShiftID)? true: false));
            }


            objEmpVM.SelectedCityID = objEmp.City.CityID;
            objEmpVM.SelectedStateID = objEmp.State.StateID;
            objEmpVM.SelectedJobID = objEmp.JobTitle.JobID;
            objEmpVM.SelectedDeptID = objEmp.Department.DepartmentID;

            objEmpVM.SelectedWorkingDayIDs = new List<int>();
            foreach (int workingDayId in objEmp.WorkingDays.Select(w => w.WorkingDayID))
            {
                objEmpVM.SelectedWorkingDayIDs.Add(workingDayId);
            }



            
            return View(objEmpVM);
        }

      

         private EmployeeVM FillListsEdit(EmployeeVM objEmpVM)
        {
            objEmpVM.AllDepartment = new SelectList(_departmentService.getAllDepartments(), "DepartmentID", "Name");
            objEmpVM.AllJobs = new SelectList( _jobService.getAllJobs(), "JobID", "JobTitleName");
            objEmpVM.AllState = new SelectList(_stateService.GetAllStates(), "StateID", "StateName");
            objEmpVM.AllWorkingDays = new SelectList(_workingdayService.getAllWorkingDays(), "WorkingDayID", "WorkingDays");
             
            return objEmpVM;
        }


        [HttpPost]
        public ActionResult Edit(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                Employee objEmp = new Employee();
                objEmp.EmployeeID = employeeVM.EmployeeID;
                objEmp.FirstName = employeeVM.FirstName;
                objEmp.LastName = employeeVM.LastName;
                objEmp.Address = employeeVM.Address + employeeVM.Addressline;
                objEmp.DateOfBirth = employeeVM.DateOfBirth;
                objEmp.HiredDate = employeeVM.HiredDate;
                objEmp.Email = employeeVM.Email;
                objEmp.Phone = employeeVM.Phone;
                objEmp.Zipcode = employeeVM.Zipcode;
                objEmp.UserName = employeeVM.UserName;
                objEmp.Password = employeeVM.Password;

                objEmp.ConfirmPassword = employeeVM.ConfirmPassword;

                objEmp.State = _stateService.GetState(employeeVM.SelectedStateID);
                objEmp.City = _cityService.GetCity(employeeVM.SelectedCityID);
                objEmp.JobTitle = _jobService.getJob(employeeVM.SelectedJobID);
                objEmp.Department = _departmentService.getDepartment(employeeVM.SelectedDeptID);


                objEmp.Gender = Convert.ToInt16(employeeVM.Gender);

                objEmp.WorkingDays = new List<WorkingDay>();
                foreach (int id in employeeVM.SelectedWorkingDayIDs)
                {
                    WorkingDay workingdays = _workingdayService.getSelectedWorkingday(id);
                    objEmp.WorkingDays.Add(workingdays);

                }

                objEmp.Shifts = new List<Shift>();
                foreach (int id in employeeVM.Shifts.Where(s => s.Checked == true).Select(x=>x.ID))
                {
                    Shift shift = _shiftService.getShift(id);
                    objEmp.Shifts.Add(shift);
                }

                //db.Entry(objEmp).State = EntityState.Modified;
                //db.SaveChanges();
                if (_empService.Update(objEmp) == true)
                    //ViewData["Status"] = "Employee " + objEmp.FirstName + "saved successfully";
                    TempData["status"] = "Employee   " + objEmp.FirstName + "   saved successfully";
                else
                   // ViewData["Status"] = "Unexpected error occurred while saving employee " + objEmp.FirstName;
                    TempData["status"] = "Unexpected error occurred while saving employee   " + objEmp.FirstName;

                return RedirectToAction("Index");
            }
            else
            {
                employeeVM = FillListsEdit(employeeVM);
                employeeVM.AllCity = new SelectList(_cityService.GetAllCities(employeeVM.SelectedStateID), "CityID", "CityName");
            }

            return View(employeeVM);

        }

       protected override void Dispose(bool disposing)
        {
            //db.Dispose();
                      
            base.Dispose(disposing);
        }
    }
}