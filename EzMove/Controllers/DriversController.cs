using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EzMove.Business;

namespace EzMove.Controllers
{
    public class DriversController : Controller
    {
        private IDriverService _driverservice;
        public DriversController(IDriverService driverservice)
        {
            this._driverservice = driverservice;
        }
        // GET: Drivers
        public ActionResult Index()
        {
            return View();
        }
    }
}