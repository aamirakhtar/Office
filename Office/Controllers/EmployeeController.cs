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
            
            var employees = oe.Employees.ToList();
            ViewBag.msg = TempData["msg"];
            
            return View(employees);
        }
        #region Without model
        //public ActionResult CreateEmployee()
        //{
        //    OfficeEntities oe = new OfficeEntities();
        //    ViewBag.departments = oe.Departments.ToList();

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CreateEmployee(FormCollection fc)
        //{
        //    string name = fc["name"];
        //    int departmentId = int.Parse(fc["departmentId"]);
        //    int age = int.Parse(fc["age"]);
        //    string designation = fc["designation"];
        //    string address = fc["address"];
        //    string gender = fc["gender"];

        //    Employee emp = new Employee()
        //    {
        //        Name = name,
        //        DepartmentId = departmentId,
        //        Age = age,
        //        Designation = designation,
        //        Address = address,
        //        Gender = gender
        //    };

        //    OfficeEntities oe = new OfficeEntities();
        //    //oe.Employees.Add(emp);
        //    oe.Entry(emp).State = System.Data.Entity.EntityState.Added;
        //    oe.SaveChanges();

        //    TempData["msg"] = "Successfully added";

        //    return RedirectToAction("Index");
        //}

        //public ActionResult EditEmployee(int id)
        //{
        //    OfficeEntities oe = new OfficeEntities();
        //    ViewBag.departments = oe.Departments.ToList();

        //    ViewBag.employee = oe.Employees.Single(emp => emp.Id == id);

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult EditEmployee(FormCollection fc)
        //{
        //    int id = int.Parse(fc["id"]);
        //    string name = fc["name"];
        //    int departmentId = int.Parse(fc["departmentId"]);
        //    int age = int.Parse(fc["age"]);
        //    string designation = string.IsNullOrEmpty(fc["designation"]) ? "" : fc["designation"];
        //    string address = fc["address"];
        //    string gender = fc["gender"];

        //    Employee emp = new Employee()
        //    {
        //        Id = id,
        //        Name = name,
        //        DepartmentId = departmentId,
        //        Age = age,
        //        Designation = designation,
        //        Address = address,
        //        Gender = gender
        //    };

        //    OfficeEntities oe = new OfficeEntities();
        //    oe.Entry(emp).State = System.Data.Entity.EntityState.Modified;
        //    oe.SaveChanges();

        //    TempData["msg"] = "Successfully updated";

        //    return RedirectToAction("Index");
        //}
        #endregion

        public ActionResult CreateEmployee()
        {
            OfficeEntities oe = new OfficeEntities();
            ViewBag.departments = oe.Departments.ToList();

            Employee model = new Employee();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee model)
        {
            OfficeEntities oe = new OfficeEntities();
            oe.Entry(model).State = System.Data.Entity.EntityState.Added;
            oe.SaveChanges();

            TempData["msg"] = "Successfully added";

            return RedirectToAction("Index");
        }

        public ActionResult EditEmployee(int id)
        {
            OfficeEntities oe = new OfficeEntities();
            ViewBag.departments = oe.Departments.ToList();

            Employee model = oe.Employees.Single(emp => emp.Id == id);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {
            OfficeEntities oe = new OfficeEntities();
            oe.Entry(model).State = System.Data.Entity.EntityState.Modified;
            oe.SaveChanges();

            TempData["msg"] = "Successfully updated";

            return RedirectToAction("Index");
        }

        public ActionResult DeleteEmployee(int id)
        {
            OfficeEntities oe = new OfficeEntities();
            Employee model = oe.Employees.Single(emp => emp.Id == id);
            oe.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            oe.SaveChanges();

            TempData["msg"] = "Successfully updated";

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            OfficeEntities oe = new OfficeEntities();
            Employee model = oe.Employees.Single(emp => emp.Id == id);
            return View(model);
        }
    }
}