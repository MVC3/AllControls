using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HTMLControlsReference.Models
{
    public interface IEmpDBContext
    {

        DbSet<Employee> Employees { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<State> States { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<JobTitle> JobTitles { get; set; }
        DbSet<Shift> Shifts { get; set; }
        DbSet<WorkingDay> WorkingDays { get; set; }

        int SaveChanges();

        DbEntityEntry Entry(object entity);

        void Dispose();
    }
}
