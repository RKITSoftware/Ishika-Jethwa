using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using versioning.Models;

namespace versioning.Controllers
{
    public class EmployeesV1Controller : ApiController
    {
        public List<EmployeeV1> EmployeeList = new List<EmployeeV1>
        {
            new EmployeeV1 {ID = 1 , Name ="Ishika" , City= "Dwarka", IsActive = true},
            new EmployeeV1 {ID = 2 , Name ="Deven" , City= "Mumbai", IsActive = false},
            new EmployeeV1 {ID = 3 , Name ="Gopal" , City= "Rajkot", IsActive = false},
            new EmployeeV1 {ID = 4 , Name ="Ganesh" , City= "Surat", IsActive = true},
            new EmployeeV1 {ID = 5 , Name ="Madhav" , City= "Ahmedabad", IsActive = true}

        };
        // GET: api/Employees
        public List<EmployeeV1> Get()
        {
            return EmployeeList;
        }

    }
}
