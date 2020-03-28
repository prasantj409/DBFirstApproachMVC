using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLModel;
using DataLayer;

namespace DBFirstMVC.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRepository empRep;

        public HomeController()
        {
            empRep = new EmployeeRepository();
        }
        // GET: Home
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            int id = empRep.AddEmployee(employee);

            if(id>0)
            {
                ViewBag.message = "Employee Added.";
                ModelState.Clear();
            }
            return View();
        }

        public ActionResult GetAllEmployees()
        {
            var employees = empRep.showAllEmployees();
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            var employee = empRep.GetEmployee(id);
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var employee = empRep.GetEmployee(id);
            return View(employee);
        }


        [HttpPost]
        public ActionResult Edit(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                empRep.UpdateEmployee(employee);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            empRep.DeleteEmployee(id);
            return RedirectToAction("GetAllEmployees");
        }


    }
}