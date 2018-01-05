using EzMove.Business;
using EzMove.Contracts;
using EzMove.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzMove.Controllers
{
    public class HomeController : Controller
    {
        IDashboardService DashboardService;
        public HomeController(IDashboardService dashboardService)
        {
            this.DashboardService = dashboardService;
        }

        public ActionResult Index()
        {
            DashboardInfo dInfo = DashboardService.GetDashBoardInfo();
            return View(dInfo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }        
    }
}