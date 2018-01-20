using EzMove.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzMove.Controllers
{
    public class AdHocController : Controller
    {
        private IEmployeeService EmployeeService;
        public AdHocController(IEmployeeService EmployeeService)
        {
            this.EmployeeService = EmployeeService;
        }
        // GET: AdHoc
        public ActionResult Index()
        {
            ViewBag.Vehicles = EmployeeService.GetVechileInfo();
            ViewBag.Employees = EmployeeService.GetEmployeeByShift("all", 0);
            return View();
        }
    }
}