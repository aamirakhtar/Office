using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Office.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomeIndexSubmit()
        {
            string userName = Request.Form["userName"];
            string password = Request.Form["password"];
            int departmentType = int.Parse(Request.Form["departmentType"]);


            //string connString = ConfigurationManager.ConnectionStrings["DefaultConn"].ToString();
            //SqlConnection conn = new SqlConnection(connString);
            //SqlCommand command = new SqlCommand("insert into department values(@Name,@Description)", conn);
            //command.CommandType = System.Data.CommandType.StoredProcedure;

            //command.Parameters.AddWithValue("@Name", userName);
            //command.Parameters.AddWithValue("@Description", "hello");
            //conn.Open();
            //var reader = command.ExecuteNonQuery();
            //conn.Close();

            return RedirectToAction("Index");
        }
    }

    public class DepartmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}