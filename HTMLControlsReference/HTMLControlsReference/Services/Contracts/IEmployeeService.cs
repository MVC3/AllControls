using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTMLControlsReference.Models;

namespace HTMLControlsReference.Services.Contracts
{
    public interface IEmployeeService
    {
        /// <summary>
        /// jhjkhjkhkjh
        /// </summary>
        /// <returns></returns>
        List<Employee> GetEmployees();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployee(int id);
        bool Create(Employee employee);
        //bool Delete(int id);
        bool Delete(Employee employee);
        bool Update(Employee employee);
    }

}