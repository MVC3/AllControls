using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTMLControlsReference.Models;
using HTMLControlsReference.Services.Contracts;
using HTMLControlsReference.ViewModels;

namespace HTMLControlsReference.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private IEmpDBContext _dataService;

         public DepartmentService(IEmpDBContext departmentDBContext)
        {
            _dataService = departmentDBContext;
        }

        public List<Department> getAllDepartments()
        {
            return _dataService.Departments.ToList();
        }

        public Department getDepartment(int id)
        {
            return _dataService.Departments.Where(d => d.DepartmentID == id).SingleOrDefault();
        }
    }
}