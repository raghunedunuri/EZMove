using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EzMove.Business;

namespace EzMove.Controllers
{
    public class LoginController : Controller
    {
        private IShiftService _shiftService;
        public LoginController(IShiftService shiftService)
        {
            this._shiftService = shiftService;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View(/*_shiftService.GetShifts()*/);
        }
    }
}