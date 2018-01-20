using EzMove.Business;
using EzMove.Models;
using OpenXml.Excel.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzMove.Controllers
{
    public class RosterController : Controller
    {
        private IEmployeeService EmployeeService;

        public RosterController(IEmployeeService EmployeeService)
        {
            this.EmployeeService = EmployeeService;
        }
        // GET: Roster
        public ActionResult Index()
        {
            ViewBag.Employees =  EmployeeService.GetEmployeeByShift("all",0);
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _fileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Uploads/Shifts"), _fileName);
                    file.SaveAs(_path);
                    ShowGrid(ReadFile(_path));
                }                
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View("Index");
            }
            return View("Index");
        }

        private ViewResult ShowGrid(DataTable dt)
        {
            ViewBag.ExcelEmployees = dt.ToEntities<Shift>().ToList();
            return View();
        }

        private DataTable ReadFile(string _path)
        {
            DataTable dtShifts = new DataTable();
            try
            {
                using (var reader = new ExcelDataReader(_path))
                    dtShifts.Load(reader);
            }
            catch (Exception ex)
            {

            }
            return dtShifts;
        }

        public ActionResult GetEmployeeInfo()
        {
            return View(EmployeeService.GetEmployeeByShift("all", 0));
        }
        public ActionResult Details(Int32 EmployeeID)
        {
            var employeeInfo = EmployeeService.GetEmployeeInfo(EmployeeID);
            return View(employeeInfo);
        }
    }
}