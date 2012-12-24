using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTMLControlsReference.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace HTMLControlsReference.Models
{
    public class EmpDBContext : DbContext, IEmpDBContext
    {
        public EmpDBContext()
            : base()
        {
        }

        public EmpDBContext(string strDBConnection)
            : base(strDBConnection)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<City> Cities { get; set;}
        public DbSet<State> States { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<WorkingDay> WorkingDays { get; set; }

        public void TestMethos()
        { 
            int a, b = 0;
            a = b / 1; 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<State>().HasMany(s=>s.City).WithRequired(c=>c.State);
            modelBuilder.Entity<Employee>().HasMany(e => e.WorkingDays);
            modelBuilder.Entity<Employee>().HasMany(e => e.Shifts);
        }


    }
}