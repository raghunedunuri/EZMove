using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EzMove.Business;
using EzMove.Contracts;

namespace EzMove.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        // GET: Employees
        public ActionResult Index()
        {
            return View(this._employeeService.GetEmployeeByShift("All", 0));
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            return View(this._employeeService.GetEmployeeInfo(id));
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View(this._employeeService.GetEmployeeInfo(id));
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var newAddress = new EZMoveAddress
                {
                    AddressLine1 = collection["Address.AddressLine1"],
                    AddressLine2 = collection["Address.AddressLine2"],
                    Street = collection["Address.Street"],
                    City = collection["Address.City"],
                    State = collection["Address.State"],
                    Country = collection["Address.Country"],
                    PinCode = collection["Address.PinCode"],
                    LandMark = collection["Address.LandMark"]
                };
                // TODO: Add update logic here
                _employeeService.UpdateEmployeeAddress(id, newAddress);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
