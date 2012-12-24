using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTMLControlsReference.Models;
using System.Data.Entity;

namespace HTMLControlsReference.Controllers
{
    public class HomeController : Controller
    {
        //private EmpDBContext db = new EmpDBContext(@"Server=.;Database=HTMLControls;Trusted_Connection=True;User Id=SQLMaster;Password=SQLMaster");
        //private IEmpDBContext _db;

        //public HomeController(IEmpDBContext db)
        //{
        //    _db = db;
        //}

        public ActionResult Index()
        {                       
            //ViewBag.Message = "Welcome Admin !";
            //TempData["status"] = "Testing status message";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
