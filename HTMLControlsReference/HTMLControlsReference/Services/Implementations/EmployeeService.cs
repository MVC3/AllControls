using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTMLControlsReference.Services.Contracts;
using HTMLControlsReference.ViewModels;
using HTMLControlsReference.Models;
using System.Web.Mvc;
using System.Data;

namespace HTMLControlsReference.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private IEmpDBContext _dataService;
        //to initialize the database connection, using the ctor
        public EmployeeService(IEmpDBContext empDBContext)
        {
            _dataService = empDBContext;
        }

        public List<Employee> GetEmployees()
        {
            return _dataService.Employees.ToList();
        }

      

        public Models.Employee GetEmployee(int id)
        {
            return _dataService.Employees.Where(e => e.EmployeeID == id).SingleOrDefault();
        }

        public bool Create(Employee employee)
        {

            try { 

                _dataService.Employees.Add(employee);
                _dataService.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                //throw (ex);
                return false;
            }

        }

        public bool Delete(Employee employee)
        {
            try {
                _dataService.Employees.Remove(employee);
                _dataService.SaveChanges();
                return true;
            }

            catch (Exception exception)
            { return false; }

        }

        public bool Update(Employee employee)
        {
            try {

                _dataService.Entry(employee).State = EntityState.Modified;
                _dataService.SaveChanges();
                return true;            
            }
            catch (Exception ex)
            { return false; }
            
        }
    }
}