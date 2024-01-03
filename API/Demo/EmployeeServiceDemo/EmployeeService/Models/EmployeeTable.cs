using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeService.Models
{
    public class EmployeeTable
    {
        public int p01f01 { get; set; } // employee_id
        public string p01f02 { get; set; } // first_name
        public string p01f03 { get; set; } // last_name
        public string p01f04 { get; set; } // department
        public decimal p01f05 { get; set; } // salary
    }
}