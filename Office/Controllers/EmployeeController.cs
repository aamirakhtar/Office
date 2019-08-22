using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Office.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            OfficeEntities oe = new OfficeEntities();
            //ViewData["employees"] = oe.Employees.ToList();
            ViewBag.employees = oe.Employees.ToList();
            ViewBag.msg = TempData["msg"];

            return View();
        }

        public ActionResult CreateEmployee()
        {
            OfficeEntities oe = new OfficeEntities();
            ViewBag.departments = oe.Departments.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(FormCollection fc)
        {
            string name = fc["name"];
            int departmentId = int.Parse(fc["departmentId"]);
            int age = int.Parse(fc["age"]);
            string designation = fc["designation"];
            string address = fc["address"];
            string gender = fc["gender"];

            Employee emp = new Employee()
            {
                Name = name,
                DepartmentId = departmentId,
                Age = age,
                Designation = designation,
                Address = address,
                Gender = gender
            };
            
            OfficeEntities oe = new OfficeEntities();
            oe.Employees.Add(emp);
            oe.SaveChanges();

            TempData["msg"] = "Successfully added";

            return RedirectToAction("Index");
        }
    }
}