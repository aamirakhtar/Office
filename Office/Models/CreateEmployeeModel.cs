using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Office.Models
{
    public class CreateEmployeeModel
    {
        public Employee employee { get; set; }
        public List<Department> departments { get; set; }

        public CreateEmployeeModel()
        {
            employee = new Employee();
            departments = new List<Department>();
        }
    }
}