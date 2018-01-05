using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzMove.Controllers
{
    public class AdHocController : Controller
    {
        // GET: AdHoc
        public ActionResult Index()
        {
            //ViewBag.Vehicles = new Models.Vehicle().GetVehicles();
            //ViewBag.Employees = new Models.EmployeeInfo().GetEmployeeInfo();
            return View();
        }
    }
}