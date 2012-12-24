using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTMLControlsReference.Models;

namespace HTMLControlsReference.Services.Contracts
{
    public interface IDepartmentService
    {
        List<Department> getAllDepartments();
        Department getDepartment(int id);
    }
}