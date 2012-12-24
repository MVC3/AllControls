using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HTMLControlsReference.Models;
using Ninject.Web.Common;
using Ninject;
using System.Reflection;
using HTMLControlsReference.Services.Implementations;
using HTMLControlsReference.Services.Contracts;

namespace HTMLControlsReference
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
           
            //change the scope of EmpDBContext to singleton scope
            kernel.Bind<IEmpDBContext>().To<EmpDBContext>().InRequestScope();
            kernel.Bind<IEmployeeService>().To<EmployeeService>().InRequestScope();
            kernel.Bind<ICityService>().To<CityService>().InRequestScope();
            kernel.Bind<IStateService>().To<StateService>().InRequestScope();
            kernel.Bind<IJobService>().To<JobService>().InRequestScope();
            kernel.Bind<IDepartmentService>().To<DepartmentService>().InRequestScope();
            kernel.Bind<IShiftService>().To<ShiftsService>().InRequestScope();
            kernel.Bind<IWorkingDayService>().To<WorkingdaysService>().InRequestScope();

            return kernel;
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<EmpDBContext>(null);

            EmpDBContext db = new EmpDBContext();
            db.Database.CreateIfNotExists();
            
        }


        protected void Session_Start()
        { 


        
        }
    }
}